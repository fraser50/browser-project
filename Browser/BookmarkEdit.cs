using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Browser
{
    public partial class BookmarkEdit : Form
    {
        private IWebBrowser browser;
        private Bookmark? currentBookmark;
        public BookmarkEdit(IWebBrowser browser)
        {
            InitializeComponent();
            this.browser = browser;

            browser.bookmarkRefresh += OnBookmarkRefresh;

            populateEntries();
        }

        public void populateEntries()
        {
            // Clear any existing bookmarks
            bookmarkList.Items.Clear();

            foreach (Bookmark bm in browser.getBookmarkList())
            {
                bookmarkList.Items.Add(bm.name);
            }
        }

        private void bookmarkList_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = bookmarkList.SelectedIndex;

            //Don't do anything if the user doesn't click an item
            if (index == -1)
            {
                return;
            }
            Bookmark selectedBookmark = browser.getBookmarkList()[index];
            currentBookmark = selectedBookmark;

            // Update text with current bookmark
            textBoxName.Text = selectedBookmark.name;
            textBoxURL.Text = selectedBookmark.url;

            // Enable textboxes and button
            textBoxName.Enabled = true;
            textBoxURL.Enabled = true;
            saveBMBtn.Enabled = true;
            deleteBtn.Enabled = true;

        }

        private void saveBMBtn_Click(object sender, EventArgs e)
        {
            Bookmark selectedBookmark = browser.getBookmarkList()[bookmarkList.SelectedIndex];

            selectedBookmark.name = textBoxName.Text;
            selectedBookmark.url = textBoxURL.Text;

            // Refresh bookmarks
            if (browser.bookmarkRefresh != null) browser.bookmarkRefresh();

            browser.SaveBookmarks();
        }

        private void OnBookmarkRefresh()
        {
            populateEntries();

            if (currentBookmark != null && browser.getBookmarkList().Contains(currentBookmark))
            {
                bookmarkList.SelectedIndex = browser.getBookmarkList().IndexOf(currentBookmark);

                textBoxName.Text = currentBookmark.name;
                textBoxURL.Text = currentBookmark.url;

            } else
            {
                bookmarkList.SelectedIndex = -1;

                textBoxName.Text = "";
                textBoxURL.Text = "";

                textBoxName.Enabled = false;
                textBoxURL.Enabled = false;
                saveBMBtn.Enabled = false;
                deleteBtn.Enabled = false;
            }
        }

        private void BookmarkEdit_Close(object sender, EventArgs e)
        {
            browser.bookmarkRefresh -= OnBookmarkRefresh;

        }

        private void deleteBtn_Click(object sender, EventArgs e)
        {
            if (currentBookmark != null)
            {
                browser.getBookmarkList().Remove(currentBookmark);

                if (browser.bookmarkRefresh != null) browser.bookmarkRefresh();

                browser.SaveBookmarks();
            }
        }
    }
}
