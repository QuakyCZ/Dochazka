using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Dochazka.Utils;
using Dochazka.Utils.DatabaseEntities;
using Microsoft.EntityFrameworkCore;

namespace Dochazka
{
    public partial class Form1 : Form
    {
        List<Student> students;
        public Form1()
        {
            InitializeComponent();
            students = new List<Student>();
            UpdateStudents();
            label1.Text = "Dnes je " + DateTime.Now.ToLongDateString();
        }

        private void AddStudentBtn_MouseClick(object sender, MouseEventArgs e)
        {
            AddStudentForm newStudentForm = new AddStudentForm();
            newStudentForm.ShowDialog();
            UpdateStudents();
        }

        private void UpdateStudents()
        {
            studentsList.Items.Clear();
            DbSet<StudentEntity> studentstable = new StudentDbContext().Students;
            foreach (var student in studentstable)
            {
                students.Add(new Student(student.Id, studentsList.Items.Count, student.Name));
                studentsList.Items.Add(student.Name);
                if (students[students.Count - 1].Present)
                    studentsList.Items[studentsList.Items.Count - 1].BackColor = Color.Green;
                else
                    studentsList.Items[studentsList.Items.Count - 1].BackColor = Color.Red;
            }
        }

        private void markAbsent(object sender, EventArgs e)
        {
            int id = studentsList.SelectedItems[0].Index;
            foreach (Student student in students)
            {
                if (id == student.LVID)
                {
                    student.markAbsent(DateTime.Now.ToShortDateString());
                    studentsList.Items[id].BackColor = studentsList.Items[id].BackColor == Color.Green ? Color.Red : Color.Green;
                    return;
                }
            }
        }
    }
}