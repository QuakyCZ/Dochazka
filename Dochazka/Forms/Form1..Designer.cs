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
            this.zobrazitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.neomluvenouAbsenciToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nápovědaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.návodToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.referenceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nahlásitChybuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.removeStudentBtn = new System.Windows.Forms.Button();
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
            this.studentsList.FullRowSelect = true;
            this.studentsList.GridLines = true;
            this.studentsList.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.studentsList.HideSelection = false;
            this.studentsList.Location = new System.Drawing.Point(22, 41);
            this.studentsList.Name = "studentsList";
            this.studentsList.Size = new System.Drawing.Size(560, 323);
            this.studentsList.TabIndex = 1;
            this.studentsList.UseCompatibleStateImageBehavior = false;
            this.studentsList.View = System.Windows.Forms.View.Details;
            this.studentsList.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.studentsList_MouseDoubleClick);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {this.souborToolStripMenuItem, this.zobrazitToolStripMenuItem, this.nápovědaToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
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
            this.importDataBtn.Click += new System.EventHandler(this.ImportDataBtn_Click);
            // 
            // zobrazitToolStripMenuItem
            // 
            this.zobrazitToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {this.neomluvenouAbsenciToolStripMenuItem});
            this.zobrazitToolStripMenuItem.Name = "zobrazitToolStripMenuItem";
            this.zobrazitToolStripMenuItem.Size = new System.Drawing.Size(62, 20);
            this.zobrazitToolStripMenuItem.Text = "Zobrazit";
            // 
            // neomluvenouAbsenciToolStripMenuItem
            // 
            this.neomluvenouAbsenciToolStripMenuItem.Name = "neomluvenouAbsenciToolStripMenuItem";
            this.neomluvenouAbsenciToolStripMenuItem.Size = new System.Drawing.Size(121, 22);
            this.neomluvenouAbsenciToolStripMenuItem.Text = "Statistiky";
            this.neomluvenouAbsenciToolStripMenuItem.Click += new System.EventHandler(this.ShowUnexcusedAbsenceBtnClick);
            // 
            // nápovědaToolStripMenuItem
            // 
            this.nápovědaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {this.návodToolStripMenuItem, this.referenceToolStripMenuItem, this.nahlásitChybuToolStripMenuItem});
            this.nápovědaToolStripMenuItem.Name = "nápovědaToolStripMenuItem";
            this.nápovědaToolStripMenuItem.Size = new System.Drawing.Size(73, 20);
            this.nápovědaToolStripMenuItem.Text = "Nápověda";
            // 
            // návodToolStripMenuItem
            // 
            this.návodToolStripMenuItem.Name = "návodToolStripMenuItem";
            this.návodToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
            this.návodToolStripMenuItem.Text = "Návod";
            // 
            // referenceToolStripMenuItem
            // 
            this.referenceToolStripMenuItem.Name = "referenceToolStripMenuItem";
            this.referenceToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
            this.referenceToolStripMenuItem.Text = "Reference";
            // 
            // nahlásitChybuToolStripMenuItem
            // 
            this.nahlásitChybuToolStripMenuItem.Name = "nahlásitChybuToolStripMenuItem";
            this.nahlásitChybuToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
            this.nahlásitChybuToolStripMenuItem.Text = "Nahlásit chybu";
            // 
            // removeStudentBtn
            // 
            this.removeStudentBtn.BackColor = System.Drawing.Color.Red;
            this.removeStudentBtn.BackgroundImage = ((System.Drawing.Image) (resources.GetObject("removeStudentBtn.BackgroundImage")));
            this.removeStudentBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.removeStudentBtn.FlatAppearance.BorderSize = 0;
            this.removeStudentBtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Red;
            this.removeStudentBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int) (((byte) (192)))), ((int) (((byte) (0)))), ((int) (((byte) (0)))));
            this.removeStudentBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.removeStudentBtn.Location = new System.Drawing.Point(588, 129);
            this.removeStudentBtn.Name = "removeStudentBtn";
            this.removeStudentBtn.Size = new System.Drawing.Size(86, 71);
            this.removeStudentBtn.TabIndex = 3;
            this.removeStudentBtn.UseVisualStyleBackColor = false;
            this.removeStudentBtn.MouseClick += new System.Windows.Forms.MouseEventHandler(this.RemoveStudentBtn_MouseClick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(686, 390);
            this.Controls.Add(this.removeStudentBtn);
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

        private System.Windows.Forms.ToolStripMenuItem neomluvenouAbsenciToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem zobrazitToolStripMenuItem;

        private System.Windows.Forms.Button removeStudentBtn;

        private System.Windows.Forms.ToolStripMenuItem nahlásitChybuToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nápovědaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem návodToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem referenceToolStripMenuItem;

        private System.Windows.Forms.ToolStripMenuItem importDataBtn;

        private System.Windows.Forms.ToolStripMenuItem exportDataButton;

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem souborToolStripMenuItem;

        private System.Windows.Forms.ListView studentsList;

        private System.Windows.Forms.Button AddStudentBtn;

        #endregion
    }
}