using System.Linq;
using System.Windows.Forms;
using Dochazka.Utils;
using Dochazka.Utils.DatabaseEntities;

namespace Dochazka {
    public partial class Form1 {
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
                    Student student = null;
                    studentsInListView.Keys.ToList().ForEach(x => {
                        if (studentsInListView[x] == item) {
                            student = x;
                            return;
                        }
                    });
                    if(student == null) return;
                    db.Attach(student);
                    db.Entry(student).Collection(x=>x.Presences).Load();
                    student.Presences.ForEach(x => {
                        db.Presences.Remove(x);
                    });
                    db.Students.Remove(student);
                    OnStudentRemovedAction.Invoke(student);
                }
                db.SaveChanges();
            }
        }
    }
}