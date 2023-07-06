using Browser;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;

namespace BrowserTests
{
    [TestClass]
    public class BookmarkTests
    {

        private IWebBrowser browser;
        public BookmarkTests()
        {
            File.Delete("testbookmarks.txt");
            browser = new WebBrowser("testhistory.txt", "testbookmarks.txt", "teststart.txt");

        }

        [TestMethod]
        public void TestAddBookmark()
        {
            Bookmark b = new Bookmark("Heriot-Watt Website", "hw.ac.uk");
            browser.AddBookmark(b);

            Assert.AreEqual(1, browser.getBookmarkList().Count);
            Bookmark retrieved = browser.getBookmarkList()[0];
            Assert.IsNotNull(retrieved);
            Assert.AreEqual("Heriot-Watt Website", retrieved.name);
            Assert.AreEqual("hw.ac.uk", retrieved.url);
        }

        [TestMethod]
        public void TestBookmarkSaving()
        {
            File.Delete("testbookmarks.txt");
            browser = new WebBrowser("testhistory.txt", "testbookmarks.txt", "teststart.txt");

            browser.AddBookmark(new Bookmark("HW", "hw.ac.uk"));

            // Create a new browser instance (to test that file loading works)
            browser = new WebBrowser("testhistory.txt", "testbookmarks.txt", "teststart.txt");

            Assert.AreEqual(1, browser.getBookmarkList().Count);
            Bookmark retrieved = browser.getBookmarkList()[0];

            Assert.IsNotNull(retrieved);
            Assert.AreEqual("HW", retrieved.name);
            Assert.AreEqual("hw.ac.uk", retrieved.url);

        }

    }
}
