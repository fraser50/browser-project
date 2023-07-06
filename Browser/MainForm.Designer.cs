using System.Windows.Forms;

namespace Browser
{
    partial class Browser
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.urlBar = new System.Windows.Forms.TextBox();
            this.goBtn = new System.Windows.Forms.Button();
            this.pageTitle = new System.Windows.Forms.Label();
            this.statusLbl = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.setStartPageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.homePageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bulkDownloadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clearHistoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bookmarksToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addBookmarkToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.EditToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.historyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.backBtn = new System.Windows.Forms.Button();
            this.forwardBtn = new System.Windows.Forms.Button();
            this.pageContent = new System.Windows.Forms.TextBox();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // urlBar
            // 
            this.urlBar.Location = new System.Drawing.Point(76, 57);
            this.urlBar.Name = "urlBar";
            this.urlBar.Size = new System.Drawing.Size(624, 23);
            this.urlBar.TabIndex = 0;
            // 
            // goBtn
            // 
            this.goBtn.Location = new System.Drawing.Point(706, 57);
            this.goBtn.Name = "goBtn";
            this.goBtn.Size = new System.Drawing.Size(75, 23);
            this.goBtn.TabIndex = 1;
            this.goBtn.Text = "Go";
            this.goBtn.UseVisualStyleBackColor = true;
            this.goBtn.Click += new System.EventHandler(this.goBtn_Click);
            // 
            // pageTitle
            // 
            this.pageTitle.AutoSize = true;
            this.pageTitle.Location = new System.Drawing.Point(76, 39);
            this.pageTitle.Name = "pageTitle";
            this.pageTitle.Size = new System.Drawing.Size(29, 15);
            this.pageTitle.TabIndex = 3;
            this.pageTitle.Text = "Title";
            this.pageTitle.Visible = false;
            // 
            // statusLbl
            // 
            this.statusLbl.AutoSize = true;
            this.statusLbl.Location = new System.Drawing.Point(643, 39);
            this.statusLbl.Name = "statusLbl";
            this.statusLbl.Size = new System.Drawing.Size(39, 15);
            this.statusLbl.TabIndex = 4;
            this.statusLbl.Text = "Status";
            this.statusLbl.Visible = false;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.optionsToolStripMenuItem,
            this.bookmarksToolStripMenuItem,
            this.historyToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 5;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // optionsToolStripMenuItem
            // 
            this.optionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.setStartPageToolStripMenuItem,
            this.homePageToolStripMenuItem,
            this.bulkDownloadToolStripMenuItem,
            this.clearHistoryToolStripMenuItem});
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            this.optionsToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.optionsToolStripMenuItem.Text = "Options";
            // 
            // setStartPageToolStripMenuItem
            // 
            this.setStartPageToolStripMenuItem.Name = "setStartPageToolStripMenuItem";
            this.setStartPageToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.H)));
            this.setStartPageToolStripMenuItem.Size = new System.Drawing.Size(198, 22);
            this.setStartPageToolStripMenuItem.Text = "Set Home Page";
            this.setStartPageToolStripMenuItem.Click += new System.EventHandler(this.setStartPageToolStripMenuItem_Click);
            // 
            // homePageToolStripMenuItem
            // 
            this.homePageToolStripMenuItem.Name = "homePageToolStripMenuItem";
            this.homePageToolStripMenuItem.Size = new System.Drawing.Size(198, 22);
            this.homePageToolStripMenuItem.Text = "Home Page";
            this.homePageToolStripMenuItem.Click += new System.EventHandler(this.homePageToolStripMenuItem_Click);
            // 
            // bulkDownloadToolStripMenuItem
            // 
            this.bulkDownloadToolStripMenuItem.Name = "bulkDownloadToolStripMenuItem";
            this.bulkDownloadToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.B)));
            this.bulkDownloadToolStripMenuItem.Size = new System.Drawing.Size(198, 22);
            this.bulkDownloadToolStripMenuItem.Text = "Bulk Download";
            this.bulkDownloadToolStripMenuItem.Click += new System.EventHandler(this.bulkDownloadToolStripMenuItem_Click);
            // 
            // clearHistoryToolStripMenuItem
            // 
            this.clearHistoryToolStripMenuItem.Name = "clearHistoryToolStripMenuItem";
            this.clearHistoryToolStripMenuItem.Size = new System.Drawing.Size(198, 22);
            this.clearHistoryToolStripMenuItem.Text = "Clear History";
            this.clearHistoryToolStripMenuItem.Click += new System.EventHandler(this.clearHistoryToolStripMenuItem_Click);
            // 
            // bookmarksToolStripMenuItem
            // 
            this.bookmarksToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addBookmarkToolStripMenuItem,
            this.EditToolStripMenuItem});
            this.bookmarksToolStripMenuItem.Name = "bookmarksToolStripMenuItem";
            this.bookmarksToolStripMenuItem.Size = new System.Drawing.Size(73, 20);
            this.bookmarksToolStripMenuItem.Text = "Favourites";
            // 
            // addBookmarkToolStripMenuItem
            // 
            this.addBookmarkToolStripMenuItem.Name = "addBookmarkToolStripMenuItem";
            this.addBookmarkToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.A)));
            this.addBookmarkToolStripMenuItem.Size = new System.Drawing.Size(191, 22);
            this.addBookmarkToolStripMenuItem.Text = "Add Favourite";
            this.addBookmarkToolStripMenuItem.Click += new System.EventHandler(this.addBookmarkToolStripMenuItem_Click);
            // 
            // EditToolStripMenuItem
            // 
            this.EditToolStripMenuItem.Name = "EditToolStripMenuItem";
            this.EditToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.E)));
            this.EditToolStripMenuItem.Size = new System.Drawing.Size(191, 22);
            this.EditToolStripMenuItem.Text = "Edit Favourites";
            this.EditToolStripMenuItem.Click += new System.EventHandler(this.editToolStripMenuItem_Click);
            // 
            // historyToolStripMenuItem
            // 
            this.historyToolStripMenuItem.Name = "historyToolStripMenuItem";
            this.historyToolStripMenuItem.Size = new System.Drawing.Size(57, 20);
            this.historyToolStripMenuItem.Text = "History";
            // 
            // backBtn
            // 
            this.backBtn.Enabled = false;
            this.backBtn.Location = new System.Drawing.Point(10, 56);
            this.backBtn.Name = "backBtn";
            this.backBtn.Size = new System.Drawing.Size(27, 23);
            this.backBtn.TabIndex = 6;
            this.backBtn.Text = "<";
            this.backBtn.UseVisualStyleBackColor = true;
            this.backBtn.Click += new System.EventHandler(this.backBtn_Click);
            // 
            // forwardBtn
            // 
            this.forwardBtn.Enabled = false;
            this.forwardBtn.Location = new System.Drawing.Point(43, 56);
            this.forwardBtn.Name = "forwardBtn";
            this.forwardBtn.Size = new System.Drawing.Size(27, 23);
            this.forwardBtn.TabIndex = 7;
            this.forwardBtn.Text = ">";
            this.forwardBtn.UseVisualStyleBackColor = true;
            this.forwardBtn.Click += new System.EventHandler(this.forwardBtn_Click);
            // 
            // pageContent
            // 
            this.pageContent.Location = new System.Drawing.Point(12, 85);
            this.pageContent.Multiline = true;
            this.pageContent.Name = "pageContent";
            this.pageContent.ReadOnly = true;
            this.pageContent.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.pageContent.Size = new System.Drawing.Size(769, 353);
            this.pageContent.TabIndex = 8;
            this.pageContent.Visible = false;
            this.pageContent.WordWrap = false;
            // 
            // Browser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.pageContent);
            this.Controls.Add(this.forwardBtn);
            this.Controls.Add(this.backBtn);
            this.Controls.Add(this.statusLbl);
            this.Controls.Add(this.pageTitle);
            this.Controls.Add(this.goBtn);
            this.Controls.Add(this.urlBar);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Browser";
            this.Text = "Web Browser";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TextBox urlBar;
        private Button goBtn;
        private Label pageTitle;
        private Label statusLbl;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem optionsToolStripMenuItem;
        private ToolStripMenuItem bookmarksToolStripMenuItem;
        private ToolStripMenuItem EditToolStripMenuItem;
        private ToolStripMenuItem addBookmarkToolStripMenuItem;
        private ToolStripMenuItem historyToolStripMenuItem;
        private Button backBtn;
        private Button forwardBtn;
        private ToolStripMenuItem setStartPageToolStripMenuItem;
        private ToolStripMenuItem homePageToolStripMenuItem;
        private TextBox pageContent;
        private ToolStripMenuItem bulkDownloadToolStripMenuItem;
        private ToolStripMenuItem clearHistoryToolStripMenuItem;
    }
}