using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Browser
{
    public interface IWebBrowser
    {
        public delegate void PageLoad(int responseCode, string contents, string url, string title);
        public delegate void BookmarkRefresh();
        public delegate void HistoryAdd(string url);
        public delegate void HistoryRefresh();
        public delegate void HistoryControlUpdate(bool forwardAvailable, bool backwardAvailable);

        public string? startPage { get; set; }

        public PageLoad? pageLoad { get; set; }
        public BookmarkRefresh? bookmarkRefresh { get; set; }
        public HistoryAdd? historyAdd { get; set; }
        public HistoryRefresh? historyRefresh { get; set; }
        public HistoryControlUpdate? historyControlUpdate { get; set; }

        public string CurrentURL { get; }

        /// <summary>
        /// This method tells the browser to navigate to the given page.
        /// </summary>
        /// <param name="url">The URL to navigate to</param>
        /// <param name="updateHistory">Whether the page visit should be stored in the persistent history</param>
        /// <param name="updateTmpHistory">Whether the visit should be in the temporary history (used for forward and back)</param>
        public void GoToPage(string url, bool updateHistory, bool updateTmpHistory);
        
        /// <summary>
        /// This method tells the browser to navigate to the given page, both persistant and non-persistant history will be updated.
        /// </summary>
        /// <param name="url">The URL to navigate to</param>
        public void GoToPage(string url);
        /// <summary>
        /// Saves the bookmarks
        /// </summary>
        public void SaveBookmarks();
        
        /// <summary>
        /// Adds a bookmark, and saves them
        /// </summary>
        /// <param name="b">The bookmark to add</param>
        public void AddBookmark(Bookmark b);

        /// <summary>
        /// Gets the list of bookmarks
        /// </summary>
        /// <returns>The list of bookmarks</returns>
        public IList<Bookmark> getBookmarkList();

        /// <summary>
        /// Gets the list of history items
        /// </summary>
        /// <returns>A list of URLs (strings)</returns>
        public IList<string> getHistory();

        /// <summary>
        /// Clears the history
        /// </summary>
        public void ClearHistory();

        /// <summary>
        /// Moves back in the current session history
        /// </summary>

        public void Back();

        /// <summary>
        /// Moves forward in the current session history
        /// </summary>
        public void Forward();


        /// <summary>
        /// Tells the browser to bulk download the files in the given file
        /// </summary>
        /// <param name="filename">The name of the file to find URLs in</param>
        public void BulkDownload(string filename);
    }
}
