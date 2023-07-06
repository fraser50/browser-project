using Browser;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BrowserTests
{
    [TestClass]
    public class HTTPStatusCodeTests
    {
        private IWebBrowser browser;
        private int statusCode = -1;
        private string title = "";
        private string content = "";

        public HTTPStatusCodeTests()
        {
            browser = new WebBrowser("testhistory.txt", "testbookmarks.txt", "teststart.txt");
            browser.pageLoad += HandleGoToPage;
        }

        [TestMethod]
        public void TestHTTP200Response()
        {
            clearFields();
            browser.GoToPage("google.com");

            Assert.AreEqual("Google", title);
            Assert.AreEqual(200, statusCode);
        }

        [TestMethod]
        public void TestHTTP403Response()
        {
            clearFields();

            browser.GoToPage("httpstat.us/403");

            Assert.AreEqual(403, statusCode);
            Assert.AreEqual("Forbidden", title);
        }

        [TestMethod]
        public void TestHTTP404Response()
        {
            clearFields();

            browser.GoToPage("httpstat.us/404");

            Assert.AreEqual(404, statusCode);
            Assert.AreEqual("Not Found", title);

        }

        private void HandleGoToPage(int responseCode, string contents, string url, string title)
        {
            this.statusCode = responseCode;
            this.title = title;
            this.content = contents;
        }

        private void clearFields()
        {
            this.statusCode = -1;
            this.title = "";
            this.content = "";
        }
    }
}