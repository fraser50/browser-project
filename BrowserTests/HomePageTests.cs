using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Browser;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BrowserTests
{
    [TestClass]
    public class HomePageTests
    {
        [TestMethod]
        public void HomePageTest()
        {
            File.Delete("teststart.txt");
            IWebBrowser browser = new WebBrowser("testhistory.txt", "testbookmarks.txt", "teststart.txt");

            browser.startPage = "google.com";

            // Create a new browser to load the startPage from disk

            browser = new WebBrowser("testhistory.txt", "testbookmarks.txt", "teststart.txt");

            Assert.AreEqual("google.com", browser.startPage);
        }
    }
}
