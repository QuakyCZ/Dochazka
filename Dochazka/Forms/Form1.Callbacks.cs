using System;
using System.Globalization;
using System.Windows.Forms;
using Dochazka.Utils;
using Dochazka.Utils.DatabaseEntities;

namespace Dochazka {
    public partial class Form1 {
        private void OnStudentAddedCallback(Student student) {
            string[] arr = new string[DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month) + 1];
            arr[0] = student.Name;
            ListViewItem newItem = new ListViewItem(arr);
            studentsInListView.Add(student, studentsList.Items.Add(newItem));
            ColorStundentList();
        }

        private void OnStudentRemovedCallback(Student student) {
            if (studentsInListView.ContainsKey(student)) {
                studentsList.Items.Remove(studentsInListView[student]);
                studentsInListView.Remove(student);
            }
            ColorStundentList();
        }

        private void OnPresenceChangedCallback(Student student, Presence presence) {
            Console.WriteLine(presence);
            DateTime date = presence.Date;
            ListViewItem item = studentsInListView[student];
            ListViewItem.ListViewSubItemCollection itemData = item.SubItems;
            itemData[FindIndexInDayIndexes(date.Day)] = new ListViewItem.ListViewSubItem(item, PresenceTypeEnum.ToString(presence.Type, true));
        }
        
        private void dateValueChangedCallback(object sender, EventArgs e) {
            if (initialization)
                return;
            int year = Int32.Parse(yearComboBox.SelectedItem.ToString());
            int month = monthComboBox.SelectedIndex+1;
            Console.WriteLine(year + " " + month);
            listedDate = new DateTime(year,month,1);
            InitStudentsList();
            UpdateStudents();
            ColorStundentList();
        }
    }
}