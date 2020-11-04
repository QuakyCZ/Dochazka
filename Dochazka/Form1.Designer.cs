namespace Dochazka {
    partial class Form1 {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }

            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.AddStudentBtn = new System.Windows.Forms.Button();
            this.studentsList = new System.Windows.Forms.ListView();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // AddStudentBtn
            // 
            this.AddStudentBtn.BackColor = System.Drawing.Color.Lime;
            this.AddStudentBtn.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("AddStudentBtn.BackgroundImage")));
            this.AddStudentBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.AddStudentBtn.FlatAppearance.BorderSize = 0;
            this.AddStudentBtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Lime;
            this.AddStudentBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.AddStudentBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.AddStudentBtn.Location = new System.Drawing.Point(686, 14);
            this.AddStudentBtn.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.AddStudentBtn.Name = "AddStudentBtn";
            this.AddStudentBtn.Size = new System.Drawing.Size(100, 82);
            this.AddStudentBtn.TabIndex = 0;
            this.AddStudentBtn.UseVisualStyleBackColor = false;
            this.AddStudentBtn.MouseClick += new System.Windows.Forms.MouseEventHandler(this.AddStudentBtn_MouseClick);
            // 
            // studentsList
            // 
            this.studentsList.HideSelection = false;
            this.studentsList.Location = new System.Drawing.Point(15, 32);
            this.studentsList.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.studentsList.MultiSelect = false;
            this.studentsList.Name = "studentsList";
            this.studentsList.Size = new System.Drawing.Size(653, 403);
            this.studentsList.TabIndex = 1;
            this.studentsList.UseCompatibleStateImageBehavior = false;
            this.studentsList.DoubleClick += new System.EventHandler(this.markAbsent);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 15);
            this.label1.TabIndex = 3;
            this.label1.Text = "label1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.studentsList);
            this.Controls.Add(this.AddStudentBtn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Dochazka";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.ListView studentsList;

        private System.Windows.Forms.Button AddStudentBtn;

        #endregion
        private System.Windows.Forms.Label label1;
    }
}