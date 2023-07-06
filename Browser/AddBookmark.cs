using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Browser
{
    public partial class AddBookmark : Form
    {
        private IWebBrowser browser;
        public AddBookmark(string url, IWebBrowser browser)
        {
            InitializeComponent();
            textBoxURL.Text = url;
            this.browser = browser;
        }

        private void AddBtn_Click(object sender, EventArgs e)
        {
            browser.AddBookmark(new Bookmark(textBoxName.Text, textBoxURL.Text));
            this.Close();

        }
    }
}
