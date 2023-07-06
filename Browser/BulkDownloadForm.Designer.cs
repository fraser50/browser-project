using System.Windows.Forms;

namespace Browser
{
    partial class BulkDownloadForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.textBoxfname = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.bulkDLBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBoxfname
            // 
            this.textBoxfname.Location = new System.Drawing.Point(12, 37);
            this.textBoxfname.Name = "textBoxfname";
            this.textBoxfname.Size = new System.Drawing.Size(147, 23);
            this.textBoxfname.TabIndex = 0;
            this.textBoxfname.Text = "bulk.txt";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(105, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "Bulk download file";
            // 
            // bulkDLBtn
            // 
            this.bulkDLBtn.Location = new System.Drawing.Point(12, 77);
            this.bulkDLBtn.Name = "bulkDLBtn";
            this.bulkDLBtn.Size = new System.Drawing.Size(147, 23);
            this.bulkDLBtn.TabIndex = 2;
            this.bulkDLBtn.Text = "Start Bulk Download";
            this.bulkDLBtn.UseVisualStyleBackColor = true;
            this.bulkDLBtn.Click += new System.EventHandler(this.bulkDLBtn_Click);
            // 
            // BulkDownloadForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(171, 107);
            this.Controls.Add(this.bulkDLBtn);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxfname);
            this.Name = "BulkDownloadForm";
            this.Text = "Bulk Download Settings";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TextBox textBoxfname;
        private Label label1;
        private Button bulkDLBtn;
    }
}