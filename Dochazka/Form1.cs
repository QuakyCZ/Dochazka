using System;
using System.IO;
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
            using (StudentDbContext db = new StudentDbContext())
            {
                DbSet<StudentEntity> students = db.Students;
                foreach (var student in students)
                {
                    studentsList.Items.Add(student.Name);
                }
            }

        }

        private void ExportDataButtonClick(object sender, EventArgs e) {
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.Filter = "SQLite database files (*.db)|*.db";

            DialogResult result = dialog.ShowDialog();
            if (result == DialogResult.OK) {
                File.Copy(Program.DBPATH, dialog.FileName);
            }
        }

        private void importDataBtn_Click(object sender, EventArgs e) {
            if (MessageBox.Show(
                "Stávající data budou smazána a nahrazena novými. Přejete si pokračovat?",
                "Varovani",
                MessageBoxButtons.YesNo) == DialogResult.No) {
                return;
            }

            try {
                OpenFileDialog dialog = new OpenFileDialog();
                dialog.Filter = "SQLite database files (*.db)|*.db";
                if (dialog.ShowDialog() == DialogResult.OK) {
                    File.Copy(dialog.FileName, Program.DBPATH, true);
                }
                UpdateStudents();
            }
            catch(Exception exception) {
                Console.WriteLine(exception);
                MessageBox.Show("Při importu došlo k problému.", "Chyba", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}