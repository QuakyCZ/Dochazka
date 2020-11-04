using System;
using System.Windows.Forms;
using Dochazka.Utils;
using Dochazka.Utils.DatabaseEntities;

namespace Dochazka {
    public partial class AddStudentForm : Form {
        public AddStudentForm() {
            InitializeComponent();
            AddBtn.Enabled = false;
        }
        
        private void AddBtn_Click(object sender, EventArgs e) {
            
            StudentEntity student = new StudentEntity();
            student.SetName(textBox1.Text);
            var table = new StudentsTable();
            try {
                table.Add(student);
                table.SaveChanges();
            }
            catch (Exception exception) {
                Console.WriteLine(exception);
                MessageBox.Show( "Nastala chyba databaze.","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }

            Close();
        }
        
        private void CloseBtn_Click(object sender, EventArgs e) {
            Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e) {
            if(string.IsNullOrEmpty(textBox1.Text))
                AddBtn.Enabled = false;
            else AddBtn.Enabled = true;
        }
    }
}