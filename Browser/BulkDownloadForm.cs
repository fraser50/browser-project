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
    public partial class BulkDownloadForm : Form
    {
        private IWebBrowser browser;
        public BulkDownloadForm(IWebBrowser browser)
        {
            InitializeComponent();

            this.browser = browser;
        }

        private void bulkDLBtn_Click(object sender, EventArgs e)
        {
            browser.BulkDownload(textBoxfname.Text);
            Close();
        }
    }
}
