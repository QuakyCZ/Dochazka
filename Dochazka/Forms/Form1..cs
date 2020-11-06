using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading;
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

        private DateTime listedDate = DateTime.Now;

        private bool initialization = true;

        public Form1() {
            EnabledChanged += OnEnabled;
            InitializeComponent();
            studentsInListView = new Dictionary<Student, ListViewItem>();
            InitComboBoxes();
            InitCallbacks();
            InitStudentsList();
            UpdateStudents();
            initialization = false;
        }

        private void OnEnabled(object sender, EventArgs e) {
            if (Enabled) {
                ColorStundentList();
            }
        }

        private void InitCallbacks() {
            OnStudentAddedAction += OnStudentAddedCallback;
            OnStudentRemovedAction += OnStudentRemovedCallback;
            OnPresenceChangedAction += OnPresenceChangedCallback;
        }

        private void InitComboBoxes() {
            yearComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            monthComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            for (int i = DateTime.Now.Year + 1; i > DateTime.Now.Year - 2; i--) {
                yearComboBox.Items.Add(i.ToString());
            }
            yearComboBox.SelectedIndex = 1;

            string month = "";
            for (int i = 0; i < DateTimeFormatInfo.CurrentInfo.MonthNames.Length;i++) {
                month = DateTimeFormatInfo.CurrentInfo.MonthNames[i];
                if(!string.IsNullOrEmpty(month))
                    monthComboBox.Items.Add(month);
            }

            monthComboBox.SelectedIndex = DateTime.Now.Month-1;
        }
        
        private void InitStudentsList() {
            dayIndexes.Clear();
            studentsList.Items.Clear();
            studentsList.Columns.Clear();
            studentsList.Sorting = SortOrder.Ascending;
            studentsList.Columns.Add("Jméno",200);
            int index = 1;
            for (int i = 1; i <= DateTime.DaysInMonth(listedDate.Year, listedDate.Month); i++) {
                DateTime day = new DateTime(listedDate.Year,listedDate.Month,i);
                if (day.DayOfWeek != DayOfWeek.Saturday && day.DayOfWeek != DayOfWeek.Sunday) {
                    studentsList.Columns.Add(i.ToString(), 30);
                    dayIndexes.Add(index,i);
                    index++;
                }
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
                    int days = DateTime.DaysInMonth(listedDate.Year, listedDate.Month);
                    string[] itemData = new string[days + 1];
                    itemData[0] = student.Name;
                    foreach (Presence presence in student.Presences) {
                        Console.WriteLine(presence.Date);
                        if (presence.Date.Year == listedDate.Year && presence.Date.Month == listedDate.Month) {
                            int i;
                            if((i=FindIndexInDayIndexes(presence.Date.Day))!=-1)
                                itemData[i] = PresenceTypeEnum.ToString(presence.Type, true);
                        }
                    }

                    ListViewItem item = new ListViewItem(itemData);
                    studentsList.Items.Add(item);
                    studentsInListView.Add(student, item);
                }
            }
            ColorStundentList();
        }

        private void ColorStundentList() {
            for(int i = 0; i < studentsList.Items.Count; i++) {
                ListViewItem item = studentsList.Items[i];
                
                if (i % 2 == 0) {
                    item.BackColor = Color.Gainsboro;
                }
                else {
                    item.BackColor = Color.White;
                }
            }
        }
        #region FORM INTERACTIONS

        //////////////////////////////
        ///
        ///    FORM INTERACTIONS
        ///
        //////////////////////////////


        private int FindIndexInDayIndexes(int day) {
            foreach (int i in dayIndexes.Keys) {
                if (dayIndexes[i] == day) return i;
            }
            return -1;
        }

        private void studentsList_MouseDoubleClick(object sender, MouseEventArgs e) {
            Console.WriteLine("Click");
            ListViewHitTestInfo hit = studentsList.HitTest(studentsList.PointToClient(Control.MousePosition));
            int day = 0;
            if (hit.Item.SubItems.IndexOf(hit.SubItem) > 0) {
                day = dayIndexes[hit.Item.SubItems.IndexOf(hit.SubItem)];
            }
            DateTime dt = listedDate;
            if (day != 0)
            {
                dt = new DateTime(listedDate.Year, listedDate.Month, day);
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