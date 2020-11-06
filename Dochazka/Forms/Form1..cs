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

        private Dictionary<Student, ListViewItem> studentsInListView;
        private Dictionary<int,int> dayIndexes = new Dictionary<int, int>();

        public Form1() {
            InitializeComponent();
            studentsInListView = new Dictionary<Student, ListViewItem>();
            InitCallbacks();
            InitStudentsList();
            UpdateStudents();
        }

        private void InitCallbacks() {
            OnStudentAddedAction += OnStudentAddedCallback;
            OnStudentRemovedAction += OnStudentRemovedCallback;
            OnPresenceChangedAction += OnPresenceChangedCallback;
        }
        private void InitStudentsList() {
            studentsList.Sorting = SortOrder.Ascending;
            studentsList.Columns.Add("Jméno",200);
            DateTime dateTimeNow = DateTime.Now;
            int index = 1;
            for (int i = 1; i <= DateTime.DaysInMonth(dateTimeNow.Year, dateTimeNow.Month); i++) {
                DateTime date = new DateTime(dateTimeNow.Year,dateTimeNow.Month,i);
                if (date.DayOfWeek != DayOfWeek.Saturday && date.DayOfWeek != DayOfWeek.Sunday) {
                    studentsList.Columns.Add(i.ToString(), 30);
                    dayIndexes.Add(index,i);
                    index++;
                }
            }
        }

        #region FORM INTERACTIONS

        //////////////////////////////
        ///
        ///    FORM INTERACTIONS
        ///
        //////////////////////////////

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
            ListViewHitTestInfo hit = studentsList.HitTest(studentsList.PointToClient(Control.MousePosition));
            int day = 0;
            if (hit.Item.SubItems.IndexOf(hit.SubItem) > 0) {
                day = dayIndexes[hit.Item.SubItems.IndexOf(hit.SubItem)];
            }
            DateTime dt = DateTime.Now;
            if (day != 0)
            {
                dt = new DateTime(DateTime.Now.Year, DateTime.Now.Month, day);
            }
            ListViewItem studentItem = studentsList.FocusedItem;
            Student newStudent = null;
            foreach (Student student in studentsInListView.Keys) {
                if (student.Name == studentItem.Text) {
                    newStudent = student;
                    break;
                }
            }

            if (newStudent != null) {
                WriteAbsenceForm writeAbsenceForm = new WriteAbsenceForm(newStudent, dt);
                if (writeAbsenceForm.ShowDialog() == DialogResult.OK) {
                    OnPresenceChangedAction.Invoke(newStudent, writeAbsenceForm.Presence);
                }
            }
        }

        #endregion
    }
}