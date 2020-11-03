using System.Windows.Forms;

namespace Dochazka {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }

        private void AddStudentBtn_MouseClick(object sender, MouseEventArgs e) {
            AddStudentForm newStudentForm = new AddStudentForm();
            newStudentForm.ShowDialog();
        }
    }
}