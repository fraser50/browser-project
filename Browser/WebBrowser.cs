using Browser;
using System;
using System.Collections.Generic;
using System.Drawing.Configuration;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Security.Policy;

namespace Browser
{
    public class WebBrowser : IWebBrowser
    {
        private List<string> history;
        private List<string> tmpHistory; // This stores the history for the current browsing session only (used to allow the user to go back and forward)
        private int tmpIndex = -1; // Current position in temporary history

        private List<Bookmark> bookmarks;

        private HttpClient client;
        private string currentURL = "";

        private string historyfile;
        private string bookmarkfile;
        private string startfile;

        private string? StartPage;
        public string? startPage
        {
            get
            {
                return StartPage;

            }
            set
            {
                StartPage = value;

                StreamWriter sw = new StreamWriter(startfile);
                sw.WriteLine(value);
                sw.Close();
            }
        }

        private const string DEFAULT_START_PAGE = "hw.ac.uk";

        public IWebBrowser.PageLoad? pageLoad { get; set; }
        public IWebBrowser.BookmarkRefresh? bookmarkRefresh { get; set; }
        public IWebBrowser.HistoryAdd? historyAdd { get; set; }
        public IWebBrowser.HistoryRefresh? historyRefresh { get; set; }
        public IWebBrowser.HistoryControlUpdate? historyControlUpdate { get; set; }
        public string CurrentURL
        {
            get
            {
                return currentURL;
            }
        }

        public WebBrowser(string historyfile, string bookmarkfile, string startfile)
        {
            history = new List<string>();
            tmpHistory = new List<string>();

            bookmarks = new List<Bookmark>();

            this.historyfile = historyfile;
            this.bookmarkfile = bookmarkfile;
            this.startfile = startfile;

            client = new HttpClient();

            StreamReader sr;
            string? line;


            try
            {
                sr = new StreamReader(historyfile);
                line = sr.ReadLine();

                while (line != null)
                {
                    history.Add(line);
                    line = sr.ReadLine();
                }

                sr.Close();
            }
            catch (FileNotFoundException) { } // If the file doesn't exist, just ignore it

            try
            {
                sr = new StreamReader(bookmarkfile);
                line = sr.ReadLine();

                while (line != null)
                {
                    // Bookmarks are split into two parts: the name and the url, they are separated by a tab
                    string[] parts = line.Split('\t');

                    string name = parts[0];
                    string url = parts[1];

                    bookmarks.Add(new Bookmark(name, url));
                    line = sr.ReadLine();

                }

                sr.Close();
            }
            catch (FileNotFoundException) { } // If the file doesn't exist, just ignore it

            // Load start page

            try
            {
                sr = new StreamReader(startfile);
                line = sr.ReadLine();
                sr.Close();

                StartPage = line;

            }
            catch (FileNotFoundException)
            {
                startPage = DEFAULT_START_PAGE;
            }
        }

        private void saveHistory()
        {
            StreamWriter sw = new StreamWriter(historyfile);

            foreach (string s in history)
            {
                sw.WriteLine(s);
            }

            sw.Close();
        }

        public void GoToPage(string url, bool updateHistory, bool updateTmpHistory)
        {
            try
            {
                string lowerURL = url.ToLower();

                // If the url does not specify either http or https, pick http:// by default
                if (!(lowerURL.StartsWith("http://") || lowerURL.StartsWith("https://")))
                {
                    url = "http://" + url;
                }

                HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, url);
                HttpResponseMessage rsp = client.Send(request);

                HttpStatusCode statusCode = rsp.StatusCode;
                HttpContent content = rsp.Content;

                Stream contentStream = content.ReadAsStream();

                StreamReader sr = new StreamReader(contentStream);
                string body = sr.ReadToEnd();

                contentStream.Close();

                currentURL = url;

                // Find the title of the page (if one is set)

                string lowerContent = body.ToLower();

                int startTitle = lowerContent.IndexOf("<title>");
                int endTitle = lowerContent.IndexOf("</title>");

                string title = "";

                // Extract the title from the HTML
                if (startTitle != -1 && endTitle != -1 && startTitle < endTitle)
                {
                    title = body.Substring(startTitle + 7, endTitle - startTitle - 7);
                }

                title = title.Replace("\n", "");

                // If the response isn't successful, set the title to the description of the status code
                if (!rsp.IsSuccessStatusCode)
                {
                    switch ((int)statusCode)
                    {
                        default:
                            title = "Other Status Code";
                            break;

                        case 400:
                            title = "Bad Request";
                            break;

                        case 403:
                            title = "Forbidden";
                            break;

                        case 404:
                            title = "Not Found";
                            break;
                    }
                }

                if (updateHistory) AddHistory(url);

                if (pageLoad != null) pageLoad((int)statusCode, body, url, title);

                if (updateTmpHistory)
                {

                    // If the user loads a page within the middle of the temporary history, all pages after are deleted (can't go forward after changing history)
                    if (tmpIndex < tmpHistory.Count - 1)
                    {
                        tmpHistory.RemoveRange(tmpIndex + 1, tmpHistory.Count - tmpIndex - 1);
                    }

                    tmpIndex++;
                    tmpHistory.Add(url);
                }

                // Notify any history control update handlers whether forward and back are available
                if (historyControlUpdate != null) historyControlUpdate(tmpIndex < tmpHistory.Count - 1, tmpIndex > 0);

            }
            catch (HttpRequestException e)
            {
                if (pageLoad != null) pageLoad(-1, e.Message, url, "");

            }
            catch (InvalidOperationException)
            {
                if (pageLoad != null) pageLoad(-1, "Invalid URL (check that the url is correctly formatted)", url, "");
            }
        }

        public void GoToPage(string url)
        {
            GoToPage(url, true, true);
        }

        public void SaveBookmarks()
        {
            StreamWriter sw = new StreamWriter(bookmarkfile);

            foreach (Bookmark bm in bookmarks)
            {
                // Using a tab character since a user is likely to put a space in the name
                sw.WriteLine(bm.name + '\t' + bm.url);
            }

            sw.Close();
        }

        public void AddBookmark(Bookmark b)
        {
            bookmarks.Add(b);
            if (bookmarkRefresh != null)
            {
                bookmarkRefresh();
            }

            SaveBookmarks();
        }

        public IList<Bookmark> getBookmarkList()
        {
            return bookmarks;
        }

        private void AddHistory(string url)
        {
            history.Add(url);
            if (historyAdd != null)
            {
                historyAdd(url);
            }

            // TODO: Think of a better way of saving history other than re-saving the file every time a new bookmark is added

            StreamWriter sw = new StreamWriter(historyfile);

            foreach (string u in history)
            {
                sw.WriteLine(u);
            }

            sw.Close();

        }

        public void Back()
        {
            if (tmpIndex > 0)
            {
                tmpIndex--;
                GoToPage(tmpHistory[tmpIndex], false, false);
            }
        }

        public void Forward()
        {
            if (tmpIndex < tmpHistory.Count)
            {
                tmpIndex++;
                GoToPage(tmpHistory[tmpIndex], false, false);
            }
        }

        struct DLResult
        {
            public string url;
            public int statusCode;
            public long downloadedBytes;
        }

        public void BulkDownload(string filename)
        {
            List<string> urls = new List<string>();

            try
            {
                StreamReader sr = new StreamReader(filename);

                string? line = sr.ReadLine();
                while (line != null)
                {
                    urls.Add(line);
                    line = sr.ReadLine();
                }

                sr.Close();

            }
            catch (FileNotFoundException)
            {
                return;
            }

            List<DLResult> results = new List<DLResult>();

            // Download each URL
            int counter = 0;

            foreach (string u in urls)
            {
                try
                {
                    string url = u;
                    string lowerURL = url.ToLower();

                    // If the url does not specify either http or https, pick http:// by default
                    if (!(lowerURL.StartsWith("http://") || lowerURL.StartsWith("https://")))
                    {
                        url = "http://" + url;
                    }
                    HttpRequestMessage message = new HttpRequestMessage(HttpMethod.Get, url);

                    HttpResponseMessage rsp = client.Send(message);

                    HttpContent content = rsp.Content;
                    Stream s = content.ReadAsStream();

                    long contentSize = s.Length;

                    // Write the file to disk
                    Stream file = File.OpenWrite(counter + ".bin");

                    s.CopyTo(file);

                    s.Close();
                    file.Close();

                    counter++;

                    int statusCode = (int)rsp.StatusCode;

                    DLResult result = new DLResult();

                    result.url = url;
                    result.statusCode = statusCode;
                    result.downloadedBytes = contentSize;

                    results.Add(result);
                }
                catch (HttpRequestException) { }
                catch (InvalidOperationException) { }
                catch (UriFormatException) { }
            }

            string resultStr = "";

            foreach (DLResult result in results)
            {
                resultStr += result.statusCode + " " + result.downloadedBytes + " " + result.url + "\n";
            }

            // TODO: Consider doing this a different way
            if (pageLoad != null)
            {
                pageLoad(200, resultStr, "", "Bulk Download Results");
            }

        }

        public void ClearHistory()
        {
            history.Clear();
            if (historyRefresh != null)
            {
                historyRefresh();
            }

            saveHistory();
        }

        public IList<string> getHistory()
        {
            return history;
        }
    }
}