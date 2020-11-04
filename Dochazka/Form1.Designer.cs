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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.souborToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportDataButton = new System.Windows.Forms.ToolStripMenuItem();
            this.importDataBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // AddStudentBtn
            // 
            this.AddStudentBtn.BackColor = System.Drawing.Color.Lime;
            this.AddStudentBtn.BackgroundImage = ((System.Drawing.Image) (resources.GetObject("AddStudentBtn.BackgroundImage")));
            this.AddStudentBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.AddStudentBtn.FlatAppearance.BorderSize = 0;
            this.AddStudentBtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Lime;
            this.AddStudentBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int) (((byte) (0)))), ((int) (((byte) (192)))), ((int) (((byte) (0)))));
            this.AddStudentBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.AddStudentBtn.Location = new System.Drawing.Point(588, 41);
            this.AddStudentBtn.Name = "AddStudentBtn";
            this.AddStudentBtn.Size = new System.Drawing.Size(86, 71);
            this.AddStudentBtn.TabIndex = 0;
            this.AddStudentBtn.UseVisualStyleBackColor = false;
            this.AddStudentBtn.MouseClick += new System.Windows.Forms.MouseEventHandler(this.AddStudentBtn_MouseClick);
            // 
            // studentsList
            // 
            this.studentsList.Location = new System.Drawing.Point(13, 41);
            this.studentsList.Name = "studentsList";
            this.studentsList.Size = new System.Drawing.Size(560, 337);
            this.studentsList.TabIndex = 1;
            this.studentsList.UseCompatibleStateImageBehavior = false;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {this.souborToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(686, 24);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // souborToolStripMenuItem
            // 
            this.souborToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {this.exportDataButton, this.importDataBtn});
            this.souborToolStripMenuItem.Name = "souborToolStripMenuItem";
            this.souborToolStripMenuItem.Size = new System.Drawing.Size(57, 20);
            this.souborToolStripMenuItem.Text = "Soubor";
            // 
            // exportDataButton
            // 
            this.exportDataButton.Image = ((System.Drawing.Image) (resources.GetObject("exportDataButton.Image")));
            this.exportDataButton.Name = "exportDataButton";
            this.exportDataButton.Size = new System.Drawing.Size(160, 22);
            this.exportDataButton.Text = "Exportovat Data";
            this.exportDataButton.Click += new System.EventHandler(this.ExportDataButtonClick);
            // 
            // importDataBtn
            // 
            this.importDataBtn.Image = ((System.Drawing.Image) (resources.GetObject("importDataBtn.Image")));
            this.importDataBtn.Name = "importDataBtn";
            this.importDataBtn.Size = new System.Drawing.Size(160, 22);
            this.importDataBtn.Text = "Importovat Data";
            this.importDataBtn.Click += new System.EventHandler(this.importDataBtn_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(686, 390);
            this.Controls.Add(this.studentsList);
            this.Controls.Add(this.AddStudentBtn);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Dochazka";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.ToolStripMenuItem importDataBtn;

        private System.Windows.Forms.ToolStripMenuItem exportDataButton;

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem souborToolStripMenuItem;

        private System.Windows.Forms.ListView studentsList;

        private System.Windows.Forms.Button AddStudentBtn;

        #endregion
    }
}