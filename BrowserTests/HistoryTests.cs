using Browser;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrowserTests
{
    [TestClass]
    public class HistoryTests
    {

        [TestMethod]
        public void TestBackButton()
        {
            IWebBrowser browser = new WebBrowser("testhistory.txt", "testbookmarks.txt", "teststart.txt");

            browser.GoToPage("google.com");
            browser.GoToPage("microsoft.com");
            browser.GoToPage("hw.ac.uk");

            Assert.AreEqual("http://hw.ac.uk", browser.CurrentURL);
            browser.Back();
            Assert.AreEqual("http://microsoft.com", browser.CurrentURL);
        }

        [TestMethod]
        public void TestForwardButton()
        {
            IWebBrowser browser = new WebBrowser("testhistory.txt", "testbookmarks.txt", "teststart.txt");

            browser.GoToPage("google.com");
            browser.GoToPage("microsoft.com");
            browser.GoToPage("hw.ac.uk");

            browser.Back();
            browser.Forward();

            Assert.AreEqual("http://hw.ac.uk", browser.CurrentURL);

        }

        [TestMethod]
        public void TestHistoryItems()
        {
            File.Delete("testhistory.txt");
            IWebBrowser browser = new WebBrowser("testhistory.txt", "testbookmarks.txt", "teststart.txt");

            browser.GoToPage("google.com");
            browser.GoToPage("hw.ac.uk");

            IList<string> history = browser.getHistory();
            Assert.AreEqual(2, history.Count);

            Assert.AreEqual("http://google.com", history[0]);
            Assert.AreEqual("http://hw.ac.uk", history[1]);
        }

        [TestMethod]
        public void TestPersistentHistory()
        {
            File.Delete("testhistory.txt");
            IWebBrowser browser = new WebBrowser("testhistory.txt", "testbookmarks.txt", "teststart.txt");

            browser.GoToPage("google.com");
            browser.GoToPage("hw.ac.uk");

            browser = new WebBrowser("testhistory.txt", "testbookmarks.txt", "teststart.txt");

            IList<string> history = browser.getHistory();

            Assert.AreEqual(2, history.Count);

            Assert.AreEqual("http://google.com", history[0]);
            Assert.AreEqual("http://hw.ac.uk", history[1]);
        }

        public void TestHistoryClear()
        {
            File.Delete("testhistory.txt");
            IWebBrowser browser = new WebBrowser("testhistory.txt", "testbookmarks.txt", "teststart.txt");

            browser.GoToPage("google.com");
            browser.GoToPage("hw.ac.uk");

            browser.ClearHistory();

            Assert.AreEqual(0, browser.getHistory().Count);
        }
    }
}
