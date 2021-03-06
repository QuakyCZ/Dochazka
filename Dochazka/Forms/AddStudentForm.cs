﻿using System;
using System.Windows.Forms;
using Dochazka.Utils;
using Dochazka.Utils.DatabaseEntities;

namespace Dochazka {
    public partial class AddStudentForm : Form {
        public Student NewStudent { get; private set; }
        public AddStudentForm() {
            InitializeComponent();
            AddBtn.DialogResult = DialogResult.OK;
            CloseBtn.DialogResult = DialogResult.Cancel;
            AddBtn.Enabled = false;
        }
        
        private void AddBtn_Click(object sender, EventArgs e) {
            
            NewStudent = new Student();
            NewStudent.Name = textBox1.Text;
            try {
                using (StudentDbContext db = new StudentDbContext())
                {
                    db.Students.Add(NewStudent);
                    db.SaveChanges();
                }
                DialogResult = DialogResult.OK;
            }
            catch (Exception exception) {
                Console.WriteLine(exception);
                MessageBox.Show( "Nastala chyba databaze.","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
            
            Close();
        }
        
        private void CloseBtn_Click(object sender, EventArgs e) {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e) {
            if(string.IsNullOrEmpty(textBox1.Text))
                AddBtn.Enabled = false;
            else AddBtn.Enabled = true;
        }
    }
}