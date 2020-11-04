using System.Windows.Forms;
using Dochazka.Utils;
using Dochazka.Utils.DatabaseEntities;
using Microsoft.EntityFrameworkCore;

namespace Dochazka {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
            UpdateStudents();
        }

        private void AddStudentBtn_MouseClick(object sender, MouseEventArgs e) {
            AddStudentForm newStudentForm = new AddStudentForm();
            newStudentForm.ShowDialog();
            UpdateStudents();
        }

        private void UpdateStudents() {
            studentsList.Items.Clear();
            DbSet<StudentEntity> students = new StudentDbContext().Students;
            foreach (var student in students) {
                studentsList.Items.Add(student.Name);
            }
        }
    }
}