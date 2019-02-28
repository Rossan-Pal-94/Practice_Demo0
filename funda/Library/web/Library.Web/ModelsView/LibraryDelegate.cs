using System.Collections.Generic;

namespace Library.Web
{
    public class LibraryDelegate
    {
        /// <summary>
        /// Delegate method, responsible for delegate printing information to the specific methods according to need 
        /// </summary>
        /// <param name="title"></param>
        /// <param name="authors"></param>
        public delegate void Notification(List<Book> sucessFull, List<Book> failure, Dictionary<string, string> mapping);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="msg"></param>
        public delegate void WriteOnConsole(string msg);
    }
}
