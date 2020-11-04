using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Dochazka.Utils;
using Dochazka.Utils.DatabaseEntities;

namespace Dochazka {
    public partial class WriteAbsenceForm : Form {
        private Student _student;
        private DateTime _dateTime;
        private Dictionary<string,PresenceType> presences = new Dictionary<string, PresenceType>();
        public WriteAbsenceForm(Student student, DateTime dateTime) {
            InitializeComponent();
            _student = student;
            _dateTime = dateTime;
            presences.Add("Přítomen",PresenceType.Present);
            presences.Add("Nepřítomen",PresenceType.Absent);
            presences.Add("Omluven",PresenceType.Excused);
            absenceTypeBox.Items.Add("Přítomen");
            absenceTypeBox.Items.Add("Nepřítomen");
            absenceTypeBox.Items.Add("Omluven");
            studentsNameLabel.Text = student.Name;
            
        }

        private void saveBtn_Click(object sender, EventArgs e) {
            Presence presence = new Presence();
            presence.Student = _student;
            presence.Date = _dateTime.ToShortDateString();
            if (presences.ContainsKey(absenceTypeBox.SelectedItem.ToString())) {
                presence.Type = presences[absenceTypeBox.SelectedItem.ToString()];
                try {
                    using (StudentDbContext db = new StudentDbContext()) {
                        db.Attach(_student);
                        db.Presences.Add(presence);
                        db.SaveChanges();
                    }
                }
                catch (Exception exception) {
                    Console.WriteLine(exception);
                    MessageBox.Show("Absenci nebylo možné uložit.", "Chyba", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }

                Close();
            }
            else {
                MessageBox.Show("Vyberte typ absence!", "Chyba", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }
    }
}