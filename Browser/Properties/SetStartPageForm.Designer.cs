using System.Windows.Forms;

namespace Browser.Properties
{
    partial class SetStartPageForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxURL = new System.Windows.Forms.TextBox();
            this.SaveURLBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Home Page URL";
            // 
            // textBoxURL
            // 
            this.textBoxURL.Location = new System.Drawing.Point(12, 59);
            this.textBoxURL.Name = "textBoxURL";
            this.textBoxURL.Size = new System.Drawing.Size(232, 23);
            this.textBoxURL.TabIndex = 1;
            // 
            // SaveURLBtn
            // 
            this.SaveURLBtn.Location = new System.Drawing.Point(65, 88);
            this.SaveURLBtn.Name = "SaveURLBtn";
            this.SaveURLBtn.Size = new System.Drawing.Size(124, 23);
            this.SaveURLBtn.TabIndex = 2;
            this.SaveURLBtn.Text = "Update Home Page";
            this.SaveURLBtn.UseVisualStyleBackColor = true;
            this.SaveURLBtn.Click += new System.EventHandler(this.SaveURLBtn_Click);
            // 
            // SetStartPageForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(256, 168);
            this.Controls.Add(this.SaveURLBtn);
            this.Controls.Add(this.textBoxURL);
            this.Controls.Add(this.label1);
            this.Name = "SetStartPageForm";
            this.Text = "Set Home Page";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label label1;
        private TextBox textBoxURL;
        private Button SaveURLBtn;
    }
}