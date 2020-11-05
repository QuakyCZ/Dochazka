using System;
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
    }
}