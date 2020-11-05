using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Dochazka.Utils;
using Dochazka.Utils.DatabaseEntities;
using Microsoft.EntityFrameworkCore;

namespace Dochazka {
    public partial class Form1 : Form {
        public delegate void OnStudentAdded(Student student);

        public delegate void OnStudentRemoved(Student student);

        public OnStudentAdded OnStudentAddedAction;
        public OnStudentRemoved OnStudentRemovedAction;

        public delegate void OnPresenceChanged(Student student, Presence presence);

        public OnPresenceChanged OnPresenceChangedAction;

        private Dictionary<Student, ListViewItem> studentsInListView = new Dictionary<Student, ListViewItem>();

        public Form1() {
            InitializeComponent();
            InitCallbacks();
            InitStudentsList();
            UpdateStudents();
        }

        private void InitCallbacks() {
            OnStudentAddedAction += OnStudentAddedCallback;
            OnStudentRemovedAction += OnStudentRemovedCallback;
            OnPresenceChangedAction += OnPresenceChangedCallback;
        }

        #region FORM INTERACTIONS

        //////////////////////////////
        ///
        ///    FORM INTERACTIONS
        ///
        //////////////////////////////
        private void AddStudentBtn_MouseClick(object sender, MouseEventArgs e) {
            AddStudentForm newStudentForm = new AddStudentForm();
            if (newStudentForm.ShowDialog() == DialogResult.OK) {
                OnStudentAddedAction.Invoke(newStudentForm.NewStudent);
            }
        }

        private void RemoveStudentBtn_MouseClick(object sender, MouseEventArgs e) {
            if (studentsList.SelectedItems.Count == 0) {
                MessageBox.Show("Vyberte v tabulce řádek studenta.", "Smazat studenta", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                return;
            }

            if (studentsList.SelectedItems.Count > 0) {
                if (MessageBox.Show("Chystáte se smazat " + studentsList.SelectedItems.Count + " studentů. Pokračovat?",
                    "Warning",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning)
                    == DialogResult.Cancel) return;
            }

            using (StudentDbContext db = new StudentDbContext()) {
                foreach (ListViewItem item in studentsList.SelectedItems) {
                    foreach (Student student in studentsInListView.Keys) {
                        if (studentsInListView[student] == item) {
                            student.Presences.ForEach(x => {
                                db.Presences.Remove(x);
                            });
                            db.Students.Remove(student);
                            OnStudentRemovedAction.Invoke(student);
                        }
                    }
                }
                db.SaveChanges();
            }
        }

        private void InitStudentsList() {
            studentsList.Sorting = SortOrder.Ascending;
            studentsList.Columns.Add("Jméno", 200);
            for (int i = 1; i <= DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month); i++) {
                studentsList.Columns.Add(i.ToString(), 50);
            }
        }

        private void UpdateStudents() {
            studentsList.Items.Clear();
            studentsInListView.Clear();
            using (StudentDbContext db = new StudentDbContext()) {
                DbSet<Student> students = db.Students;
                foreach (var student in students) {
                    // Fetch presences of student
                    db.Entry(student).Collection(x => x.Presences).Load();
                    Console.WriteLine(student.Presences.Count);
                    int days = DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month);
                    string[] itemData = new string[days + 1];
                    itemData[0] = student.Name;
                    foreach (Presence presence in student.Presences) {
                        Console.WriteLine(presence.Date);
                        if (presence.Date.Year == DateTime.Now.Year && presence.Date.Month == DateTime.Now.Month) {
                            itemData[presence.Date.Day] = PresenceTypeEnum.ToString(presence.Type, true);
                        }
                    }

                    ListViewItem item = new ListViewItem(itemData);
                    studentsList.Items.Add(item);
                    studentsInListView.Add(student, item);
                }
            }
        }

        private void studentsList_MouseDoubleClick(object sender, MouseEventArgs e) {
            Console.WriteLine("Click");
            ListViewItem studentItem = studentsList.FocusedItem;
            Student newStudent = null;
            foreach (Student student in studentsInListView.Keys) {
                if (student.Name == studentItem.Text) {
                    newStudent = student;
                    break;
                }
            }

            if (newStudent != null) {
                WriteAbsenceForm writeAbsenceForm = new WriteAbsenceForm(newStudent);
                if (writeAbsenceForm.ShowDialog() == DialogResult.OK) {
                    OnPresenceChangedAction.Invoke(newStudent, writeAbsenceForm.Presence);
                }
            }
        }

        #endregion

        #region MENU BUTTONS

        //////////////////////////////
        ///
        /// MENU BUTTONS
        ///
        /// //////////////////////////
        private void ExportDataButtonClick(object sender, EventArgs e) {
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.Filter = "SQLite database files (*.db)|*.db";

            DialogResult result = dialog.ShowDialog();
            if (result == DialogResult.OK) {
                File.Copy(Program.DBPATH, dialog.FileName);
            }
        }

        private void importDataBtn_Click(object sender, EventArgs e) {
            if (MessageBox.Show(
                "Stávající data budou smazána a nahrazena novými. Přejete si pokračovat?",
                "Varovani",
                MessageBoxButtons.YesNo) == DialogResult.No) {
                return;
            }

            try {
                OpenFileDialog dialog = new OpenFileDialog();
                dialog.Filter = "SQLite database files (*.db)|*.db";
                if (dialog.ShowDialog() == DialogResult.OK) {
                    File.Copy(dialog.FileName, Program.DBPATH, true);
                }

                UpdateStudents();
            }
            catch (Exception exception) {
                Console.WriteLine(exception);
                MessageBox.Show("Při importu došlo k problému.", "Chyba", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        #region CALLBACKS

        //////////////////////////////////////
        ///
        ///  CALLBACKS
        ///
        /// ////////////////////////////////// 
        private void OnStudentAddedCallback(Student student) {
            string[] arr = new string[DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month) + 1];
            arr[0] = student.Name;
            ListViewItem newItem = new ListViewItem(arr);
            studentsInListView.Add(student, studentsList.Items.Add(newItem));
        }

        private void OnStudentRemovedCallback(Student student) {
            if (studentsInListView.ContainsKey(student)) {
                studentsList.Items.Remove(studentsInListView[student]);
                studentsInListView.Remove(student);
            }
        }

        private void OnPresenceChangedCallback(Student student, Presence presence) {
            Console.WriteLine(presence);
            DateTime date = presence.Date;
            ListViewItem item = studentsInListView[student];
            ListViewItem.ListViewSubItemCollection itemData = item.SubItems;
            itemData[date.Day] = new ListViewItem.ListViewSubItem(item, PresenceTypeEnum.ToString(presence.Type, true));
        }

        #endregion
    }
}