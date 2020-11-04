using System.ComponentModel;

namespace Dochazka {
    partial class WriteAbsenceForm {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
            this.studentsNameLabel = new System.Windows.Forms.Label();
            this.toolStripDropDown1 = new System.Windows.Forms.ToolStripDropDown();
            this.absenceTypeBox = new System.Windows.Forms.ComboBox();
            this.saveBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // studentsNameLabel
            // 
            this.studentsNameLabel.Anchor = ((System.Windows.Forms.AnchorStyles) (((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.studentsNameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (238)));
            this.studentsNameLabel.Location = new System.Drawing.Point(80, 9);
            this.studentsNameLabel.Name = "studentsNameLabel";
            this.studentsNameLabel.Size = new System.Drawing.Size(209, 49);
            this.studentsNameLabel.TabIndex = 0;
            this.studentsNameLabel.Text = "Jmeno Studenta";
            this.studentsNameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // toolStripDropDown1
            // 
            this.toolStripDropDown1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Flow;
            this.toolStripDropDown1.Name = "toolStripDropDown1";
            this.toolStripDropDown1.Size = new System.Drawing.Size(2, 4);
            // 
            // absenceTypeBox
            // 
            this.absenceTypeBox.Anchor = ((System.Windows.Forms.AnchorStyles) (((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.absenceTypeBox.FormattingEnabled = true;
            this.absenceTypeBox.Location = new System.Drawing.Point(107, 98);
            this.absenceTypeBox.Name = "absenceTypeBox";
            this.absenceTypeBox.Size = new System.Drawing.Size(163, 21);
            this.absenceTypeBox.TabIndex = 2;
            this.absenceTypeBox.Text = "Typ absence";
            // 
            // saveBtn
            // 
            this.saveBtn.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.saveBtn.Location = new System.Drawing.Point(80, 160);
            this.saveBtn.Name = "saveBtn";
            this.saveBtn.Size = new System.Drawing.Size(209, 49);
            this.saveBtn.TabIndex = 3;
            this.saveBtn.Text = "Uložit";
            this.saveBtn.UseVisualStyleBackColor = true;
            this.saveBtn.Click += new System.EventHandler(this.saveBtn_Click);
            // 
            // WriteAbsenceForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(380, 256);
            this.Controls.Add(this.saveBtn);
            this.Controls.Add(this.absenceTypeBox);
            this.Controls.Add(this.studentsNameLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "WriteAbsenceForm";
            this.Text = "Zápis Absence";
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Button saveBtn;
        private System.Windows.Forms.Label studentsNameLabel;

        private System.Windows.Forms.ComboBox absenceTypeBox;
        private System.Windows.Forms.ToolStripDropDown toolStripDropDown1;

        #endregion
    }
}