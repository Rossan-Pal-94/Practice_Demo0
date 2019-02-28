using Newtonsoft.Json;
using System.Collections.Generic;

/// <summary>
/// Library Application it contains books and their details
/// </summary>
namespace Library.Web
{
    /// <summary>
    /// 
    /// </summary>
    public class Book
    {
        public string ISBN
        {
            get;
            private set;
        } 
        /// <summary>
        /// Book title
        /// </summary>
        public string title
        {
            get;
            private set;
        }

        /// <summary>
        /// List<Author> of book
        /// </summary>
        public List<Author> authors
        {
            get;
            private set;
        }

        /// <summary>
        /// Publishing year of book
        /// </summary>
        public int yearOfPublishing
        {
            get;
            private set;
        }

        public string language
        {
            get;
            private set;
        }

        public int pages
        {
            get;
            private set;
        }

        /// <summary>
        /// Constructor of book responsible to construct book object
        /// </summary>
        /// <param name="title"></param>
        /// <param name="authors"></param>
        /// <param name="yop"></param>
        [JsonConstructor]
        public Book(string ISBN, string title, List<Author> authors, string language, int pages, int yearOfPublishing)
        {
            this.ISBN = ISBN;this.title = title;this.authors = authors;this.language = language;this.pages = pages;this.yearOfPublishing = yearOfPublishing;
        }

        /// <summary>
        /// Validate that authors has valid data, if yes return true, otherwise false
        /// </summary>
        /// <param name="authors"></param>
        /// <returns></returns>
        public static bool Valid(List<Author> authors)
        {
            bool flag = true;
            if (authors == null)
                flag = false;
            foreach (Author author in authors)
            {
                if (string.IsNullOrEmpty(author.firstName) || string.IsNullOrEmpty(author.lastName))
                    flag = false;
            }
            return flag;
        }
    }
}
