using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Windows.Forms;
using Dochazka.Utils;
using Dochazka.Utils.DatabaseEntities;

namespace Dochazka {
    public partial class WriteAbsenceForm : Form {
        private Student _student;
        private DateTime _dateTime;
        public Presence Presence { get; private set; }
        private Dictionary<string,PresenceType> presences = new Dictionary<string, PresenceType>();
        public WriteAbsenceForm(Student student) {
            InitializeComponent();
            saveBtn.DialogResult = DialogResult.OK;
            _student = student;
            presences.Add(PresenceTypeEnum.ToString(PresenceType.Present),PresenceType.Present);
            presences.Add(PresenceTypeEnum.ToString(PresenceType.Absent),PresenceType.Absent);
            presences.Add(PresenceTypeEnum.ToString(PresenceType.Excused),PresenceType.Excused);
            int first = absenceTypeBox.Items.Add(PresenceTypeEnum.ToString(PresenceType.Present));
            absenceTypeBox.Items.Add(PresenceTypeEnum.ToString(PresenceType.Absent));
            absenceTypeBox.Items.Add(PresenceTypeEnum.ToString(PresenceType.Excused));
            absenceTypeBox.SelectedIndex = first;
            studentsNameLabel.Text = student.Name;
            
        }

        private bool GetPresence() {
            using (StudentDbContext db = new StudentDbContext()) {
                db.Attach(_student);
                db.Entry(_student).Collection(s=>s.Presences)
                    .Query().Where(p=>(p.Date.Equals(_dateTime))).Load();

                if (_student.Presences.Count != 0) {
                    Presence = _student.Presences.Find(x=>x.Date.Equals(_dateTime));
                }

                if (Presence == null) {
                    Presence = new Presence();
                    return false;
                }
                return true;
            }
        }

        private void saveBtn_Click(object sender, EventArgs e) {
            _dateTime = dateTimePicker1.Value;
            _dateTime = DateTime.Parse(_dateTime.ToShortDateString());
            bool newPresence = GetPresence()==false;
            
            if (presences.ContainsKey(absenceTypeBox.Text)) {
                Presence.Type = presences[absenceTypeBox.Text];
                try {
                    using (StudentDbContext db = new StudentDbContext()) {
                        db.Attach(_student);
                        if (newPresence) {
                            _student.Presences.Add(Presence);
                            Presence.Date = _dateTime;
                            Presence.Student = _student;
                            db.Add(Presence);
                        }

                        else {
                            db.Presences.Update(Presence);
                        }

                        db.SaveChanges();
                        Console.WriteLine(Presence.ToString());
                    }
                }
                catch (Exception exception) {
                    Console.WriteLine(exception);
                    MessageBox.Show("Prezenci nebylo možné uložit.", "Chyba", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }

                Close();
            }
            else {
                MessageBox.Show("Prezence " + absenceTypeBox.SelectedText + " neexistuje!", "Chyba", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }
    }
}