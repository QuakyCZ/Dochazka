using System.ComponentModel;

namespace Dochazka {
    partial class AbsencesForm {
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
            this.closeBtn = new System.Windows.Forms.Button();
            this.presenceList = new System.Windows.Forms.ListView();
            this.savePDFBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // closeBtn
            // 
            this.closeBtn.Anchor = ((System.Windows.Forms.AnchorStyles) (((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.closeBtn.Location = new System.Drawing.Point(697, 84);
            this.closeBtn.Name = "closeBtn";
            this.closeBtn.Size = new System.Drawing.Size(97, 66);
            this.closeBtn.TabIndex = 1;
            this.closeBtn.Text = "Zavřít";
            this.closeBtn.UseVisualStyleBackColor = true;
            this.closeBtn.Click += new System.EventHandler(this.CloseBtn_Click);
            // 
            // presenceList
            // 
            this.presenceList.Anchor = ((System.Windows.Forms.AnchorStyles) (((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left)));
            this.presenceList.FullRowSelect = true;
            this.presenceList.GridLines = true;
            this.presenceList.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.presenceList.HideSelection = false;
            this.presenceList.Location = new System.Drawing.Point(12, 12);
            this.presenceList.Name = "presenceList";
            this.presenceList.Size = new System.Drawing.Size(679, 488);
            this.presenceList.TabIndex = 3;
            this.presenceList.UseCompatibleStateImageBehavior = false;
            this.presenceList.View = System.Windows.Forms.View.Details;
            // 
            // savePDFBtn
            // 
            this.savePDFBtn.Anchor = ((System.Windows.Forms.AnchorStyles) (((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.savePDFBtn.Location = new System.Drawing.Point(697, 12);
            this.savePDFBtn.Name = "savePDFBtn";
            this.savePDFBtn.Size = new System.Drawing.Size(97, 66);
            this.savePDFBtn.TabIndex = 4;
            this.savePDFBtn.Text = "Uložit PDF";
            this.savePDFBtn.UseVisualStyleBackColor = true;
            this.savePDFBtn.Click += new System.EventHandler(this.savePDFBtn_Click);
            // 
            // AbsencesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(806, 512);
            this.Controls.Add(this.savePDFBtn);
            this.Controls.Add(this.presenceList);
            this.Controls.Add(this.closeBtn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "AbsencesForm";
            this.Text = "Prezence";
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Button savePDFBtn;

        private System.Windows.Forms.ListView presenceList;

        private System.Windows.Forms.Button closeBtn;

        #endregion
    }
}