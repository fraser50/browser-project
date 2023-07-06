using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Browser.Properties
{
    public partial class SetStartPageForm : Form
    {
        private IWebBrowser browser;
        public SetStartPageForm(IWebBrowser browser)
        {
            InitializeComponent();
            
            this.browser = browser;

            textBoxURL.Text = browser.CurrentURL;
        }

        private void SaveURLBtn_Click(object sender, EventArgs e)
        {
            browser.startPage = textBoxURL.Text;
        }
    }
}
