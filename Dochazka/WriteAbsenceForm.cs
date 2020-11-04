using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Dochazka.Utils;
using Dochazka.Utils.DatabaseEntities;

namespace Dochazka {
    public partial class WriteAbsenceForm : Form {
        private StudentEntity _studentEntity;
        private DateTime _dateTime;
        private Dictionary<string,PresenceType> presences = new Dictionary<string, PresenceType>();
        public WriteAbsenceForm(StudentEntity studentEntity, DateTime dateTime) {
            InitializeComponent();
            _studentEntity = studentEntity;
            _dateTime = dateTime;
            presences.Add("Přítomen",PresenceType.Present);
            presences.Add("Nepřítomen",PresenceType.Absent);
            presences.Add("Omluven",PresenceType.Excused);
            absenceTypeBox.Items.Add("Přítomen");
            absenceTypeBox.Items.Add("Nepřítomen");
            absenceTypeBox.Items.Add("Omluven");
            studentsNameLabel.Text = studentEntity.Name;
            
        }

        private void saveBtn_Click(object sender, EventArgs e) {
            PresenceEntity presenceEntity = new PresenceEntity();
            presenceEntity.Student = _studentEntity;
            presenceEntity.Date = _dateTime.ToShortDateString();
            if (presences.ContainsKey(absenceTypeBox.SelectedItem.ToString())) {
                presenceEntity.Type = presences[absenceTypeBox.SelectedItem.ToString()];
                try {
                    using (PresenceDbContext db = new PresenceDbContext()) {
                        db.Add(presenceEntity);
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