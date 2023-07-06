using Browser.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Browser
{
    public partial class Browser : Form
    {
        private IWebBrowser browser;
        private List<ToolStripMenuItem> bookmarkOptions;
        public Browser()
        {
            InitializeComponent();
            browser = new WebBrowser("history.txt", "bookmarks.txt", "startpage.txt");
            browser.pageLoad += LoadPageHandler;
            browser.bookmarkRefresh += OnBookmarkRefresh;
            browser.historyRefresh += OnHistoryRefresh;
            browser.historyAdd += OnHistoryAdd;
            browser.historyControlUpdate += OnHistoryControlUpdate;

            bookmarkOptions = new List<ToolStripMenuItem>();

            browser.bookmarkRefresh(); // TODO: Consider doing this a different way
            browser.historyRefresh();

            if (browser.startPage != null)
            {
                browser.GoToPage(browser.startPage);
            }
        }

        private void goBtn_Click(object sender, EventArgs e)
        {
            string url = urlBar.Text;

            browser.GoToPage(url);
        }

        private void LoadPageHandler(int code, string body, string url, string title)
        {
            // Set page contents
            pageContent.Lines = body.Split('\n');
            pageContent.Visible = true;

            // Show status code (TODO: Include human readable error)
            statusLbl.Text = code.ToString();
            statusLbl.Visible = true;

            // Update url
            urlBar.Text = url;
            pageTitle.Text = title;
            pageTitle.Visible = true;
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BookmarkEdit editBookmark = new BookmarkEdit(browser);
            editBookmark.Show();
        }

        private void addBookmarkToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddBookmark addBookmark = new AddBookmark(browser.CurrentURL, browser);
            addBookmark.Show(this);
        }

        private void OnBookmarkRefresh()
        {
            // Clear out any existing bookmarks in the dropdown menu
            foreach (ToolStripMenuItem item in bookmarkOptions)
            {
                bookmarksToolStripMenuItem.DropDownItems.Remove(item);
            }

            bookmarkOptions.Clear();

            // Add bookmark options
            foreach (Bookmark bookmark in browser.getBookmarkList())
            {
                ToolStripMenuItem item = new ToolStripMenuItem();
                item.Text = bookmark.name;
                item.Click += new EventHandler((object? sender, EventArgs e) =>
                {
                    urlBar.Text = bookmark.url;
                    browser.GoToPage(bookmark.url);
                });

                bookmarksToolStripMenuItem.DropDownItems.Add(item);
                bookmarkOptions.Add(item);
            }


        }

        private void OnHistoryRefresh()
        {
            historyToolStripMenuItem.DropDownItems.Clear();

            // Display history in reverse order (newest history item at the top)
            foreach (string url in browser.getHistory().Reverse())
            {
                ToolStripMenuItem item = new ToolStripMenuItem();
                item.Text = url;
                item.Click += new EventHandler((object? sender, EventArgs e) =>
                {
                    urlBar.Text = url;
                    browser.GoToPage(url, false, true);
                });

                historyToolStripMenuItem.DropDownItems.Add(item);
            }
        }

        private void OnHistoryAdd(string url)
        {
            ToolStripMenuItem item = new ToolStripMenuItem();
            item.Text = url;
            item.Click += new EventHandler((object? sender, EventArgs e) =>
            {
                urlBar.Text = url;
                browser.GoToPage(url);
            });

            ToolStripItemCollection collection = historyToolStripMenuItem.DropDownItems;

            // Insert history item at the start of the list
            collection.Insert(0, item);
            
        }

        private void OnHistoryControlUpdate(bool forwardAvailable, bool backwardAvailable)
        {
            forwardBtn.Enabled = forwardAvailable;
            backBtn.Enabled = backwardAvailable;
        }

        private void forwardBtn_Click(object sender, EventArgs e)
        {
            browser.Forward();
        }

        private void backBtn_Click(object sender, EventArgs e)
        {
            browser.Back();
        }

        private void setStartPageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SetStartPageForm form = new SetStartPageForm(browser);
            form.Show();
        }

        private void homePageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (browser.startPage != null)
            {
                browser.GoToPage(browser.startPage);

            } else
            {
                // TODO: Perhaps show a dialog box notifying the user there is no start page set
            }
        }

        private void bulkDownloadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BulkDownloadForm form = new BulkDownloadForm(browser);
            form.Show();
        }

        private void clearHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            browser.ClearHistory();
        }
    }
}