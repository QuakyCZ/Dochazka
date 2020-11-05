using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Dochazka.Utils;
using Dochazka.Utils.DatabaseEntities;

namespace Dochazka {
    public partial class AbsencesForm : Form {
        private List<string[]> lines = new List<string[]>();
        public AbsencesForm() {
            InitializeComponent();
            InitTable();
            ShowValues();
        }

        

        private void InitTable() {
            presenceList.Sorting = SortOrder.Ascending;
            presenceList.Columns.Add("Jméno", 200);
            presenceList.Columns.Add("Přítomen", 100);
            presenceList.Columns.Add("Neomluvená absence", 100);
            presenceList.Columns.Add("Omluvená absence", 100);
            presenceList.Columns.Add("Absence celkem", 100);
        }
        
        private void ShowValues() {
            using (StudentDbContext db = new StudentDbContext()) {
                foreach (Student student in db.Students) {
                    db.Attach(student);
                    db.Entry(student).Collection(s=>s.Presences).Load();
                    string[] arr = new string[presenceList.Columns.Count];
                    arr[0] = student.Name;
                    int present = GetPresenceCount(student, PresenceType.Present);
                    int absent = GetPresenceCount(student, PresenceType.Absent);
                    int excused = GetPresenceCount(student, PresenceType.Excused);
                    int totalAbsence = absent + excused;
                    arr[1] = present.ToString();
                    arr[2] = absent.ToString();
                    arr[3] = excused.ToString();
                    arr[4] = totalAbsence.ToString();
                    presenceList.Items.Add(new ListViewItem(arr));
                    lines.Add(arr);
                }
            }
        }

        private int GetPresenceCount(Student stundent, PresenceType type) {
            int count = 0;
            stundent.Presences.ForEach(x => {
                if (x.Type.Equals(type)) {
                    count++;
                }
            });
            return count;
        }
    }
}