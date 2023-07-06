using System.Windows.Forms;

namespace Browser
{
    partial class BookmarkEdit
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
            this.bookmarkList = new System.Windows.Forms.ListBox();
            this.saveBMBtn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.textBoxURL = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.deleteBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // bookmarkList
            // 
            this.bookmarkList.FormattingEnabled = true;
            this.bookmarkList.ItemHeight = 15;
            this.bookmarkList.Location = new System.Drawing.Point(26, 34);
            this.bookmarkList.Name = "bookmarkList";
            this.bookmarkList.Size = new System.Drawing.Size(120, 304);
            this.bookmarkList.TabIndex = 0;
            this.bookmarkList.SelectedIndexChanged += new System.EventHandler(this.bookmarkList_SelectedIndexChanged);
            // 
            // saveBMBtn
            // 
            this.saveBMBtn.Enabled = false;
            this.saveBMBtn.Location = new System.Drawing.Point(185, 248);
            this.saveBMBtn.Name = "saveBMBtn";
            this.saveBMBtn.Size = new System.Drawing.Size(176, 23);
            this.saveBMBtn.TabIndex = 1;
            this.saveBMBtn.Text = "Save Changes";
            this.saveBMBtn.UseVisualStyleBackColor = true;
            this.saveBMBtn.Click += new System.EventHandler(this.saveBMBtn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(184, 115);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 15);
            this.label1.TabIndex = 2;
            this.label1.Text = "Name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(185, 172);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(28, 15);
            this.label2.TabIndex = 3;
            this.label2.Text = "URL";
            // 
            // textBoxName
            // 
            this.textBoxName.Enabled = false;
            this.textBoxName.Location = new System.Drawing.Point(185, 133);
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new System.Drawing.Size(176, 23);
            this.textBoxName.TabIndex = 4;
            // 
            // textBoxURL
            // 
            this.textBoxURL.Enabled = false;
            this.textBoxURL.Location = new System.Drawing.Point(185, 190);
            this.textBoxURL.Name = "textBoxURL";
            this.textBoxURL.Size = new System.Drawing.Size(176, 23);
            this.textBoxURL.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(173, 58);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(190, 15);
            this.label3.TabIndex = 6;
            this.label3.Text = "Please click on a favourite to edit it";
            // 
            // deleteBtn
            // 
            this.deleteBtn.Enabled = false;
            this.deleteBtn.Location = new System.Drawing.Point(233, 289);
            this.deleteBtn.Name = "deleteBtn";
            this.deleteBtn.Size = new System.Drawing.Size(75, 23);
            this.deleteBtn.TabIndex = 7;
            this.deleteBtn.Text = "Delete";
            this.deleteBtn.UseVisualStyleBackColor = true;
            this.deleteBtn.Click += new System.EventHandler(this.deleteBtn_Click);
            // 
            // BookmarkEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(417, 369);
            this.Controls.Add(this.deleteBtn);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBoxURL);
            this.Controls.Add(this.textBoxName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.saveBMBtn);
            this.Controls.Add(this.bookmarkList);
            this.Name = "BookmarkEdit";
            this.Text = "Edit Favourites";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.BookmarkEdit_Close);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ListBox bookmarkList;
        private Button saveBMBtn;
        private Label label1;
        private Label label2;
        private TextBox textBoxName;
        private TextBox textBoxURL;
        private Label label3;
        private Button deleteBtn;
    }
}