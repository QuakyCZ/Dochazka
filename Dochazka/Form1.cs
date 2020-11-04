using System;
using System.Collections.Generic;
using System.IO;
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

        private Dictionary<Student, ListViewItem> studentsInListView = new Dictionary<Student, ListViewItem>();

        public Form1() {
            InitializeComponent();
            OnStudentAddedAction += OnStudentAddedCallback;
            OnStudentRemovedAction += OnStudentRemovedCallback;
            InitStudentsList();
            UpdateStudents();
        }

        #region FORM INTERACTIONS

        //////////////////////////////
        ///
        ///    FORM INTERACTIONS
        ///
        //////////////////////////////

        
        private void AddStudentBtn_MouseClick(object sender, MouseEventArgs e) {
            AddStudentForm newStudentForm = new AddStudentForm();
            newStudentForm.ShowDialog();
            OnStudentAddedAction.Invoke(newStudentForm.NewStudent);
        }

        private void RemoveStudentBtn_MouseClick(object sender, MouseEventArgs e) {
            throw new NotImplementedException("RemoveStudentBtn_MouseClick not implemented");
        }

        private void UpdateStudents() {
            studentsList.Items.Clear();
            studentsInListView.Clear();
            using (StudentDbContext db = new StudentDbContext())
            {
                DbSet<Student> students = db.Students;
                foreach (var student in students) {
                    studentsInListView.Add(student,studentsList.Items.Add(student.Name));
                }
            }
        }

        private void InitStudentsList()
        {
            studentsList.Sorting = SortOrder.Ascending;
            studentsList.Columns.Add("Jméno",200);
            studentsList.Columns.Add("Absence", 100);
        }
        
        private void studentsList_MouseDoubleClick(object sender, MouseEventArgs e) {

            ListViewItem studentItem = studentsList.FocusedItem;
            Student newStudent = null;
            foreach (Student student in studentsInListView.Keys) {
                if (student.Name == studentItem.Text) {
                    newStudent = student;
                    break;
                }
            }

            if (newStudent != null) {
                WriteAbsenceForm writeAbsenceForm = new WriteAbsenceForm(newStudent, dateTimePicker.Value);
                writeAbsenceForm.ShowDialog();
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
            catch(Exception exception) {
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
            studentsInListView.Add(student,studentsList.Items.Add(student.Name));
        }

        private void OnStudentRemovedCallback(Student student) {
            if (studentsInListView.ContainsKey(student)) {
                studentsList.Items.Remove(studentsInListView[student]);
            }
        }
        #endregion

        
    }
}