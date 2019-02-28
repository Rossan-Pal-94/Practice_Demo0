using Microsoft.EntityFrameworkCore.Internal;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Library.Web
{
    /// <summary>
    /// 
    /// </summary>
    public class Library
    {
        /// <summary>
        /// Variable to holds the lists of books available in library
        /// </summary>
        List<Book> books;

        /// <summary>
        /// Constructor of library class
        /// </summary>
        public Library()
        {
            using (StreamReader r = new StreamReader("Books.json"))
            {
                string json = r.ReadToEnd();
                books = (JsonConvert.DeserializeObject<List<Book>>(json));
            }
        }

        /// <summary>
        /// Method to add books in library
        /// </summary>
        /// <param title="title"></param>
        /// <param title="author"></param>
        /// <param title="yop"></param>
        public void AddBook(string isbn, string title, List<Author> authors, string language, int pages, int yop)
        {
            if (string.IsNullOrWhiteSpace(title) && !Book.Valid(authors) && yop < 1950 && pages < 0 && string.IsNullOrWhiteSpace(language))
                throw new InvalidBookException("Invalid Book title, It should not be nulll or empty" + "\n" + "Invalid Author Name firstName and lastName, It should not be empty or null" + "\n" + "Invalid Year of publition, It should be greater than 1950");
            else if (!Book.Valid(authors) && yop < 1950)
                throw new InvalidBookException("Invalid Author Name firstName and lastName, It should not be empty or null" + "\n" + "Invalid Year of publition, It should be greater than 1950");
            else if (string.IsNullOrWhiteSpace(title) && !Book.Valid(authors))
                throw new InvalidBookException("Invalid Book title, It should not be nulll or empty" + "\n" + "Invalid Author Name firstName and lastName, It should not be empty or null");
            else if (string.IsNullOrWhiteSpace(title))
                throw new InvalidBookException("Invalid Book title, It should not be nulll or empty");
            else if (!Book.Valid(authors))
                throw new InvalidBookException("Invalid Author Name firstName and lastName, It should not be empty or null");
            else if (yop < 1950)
                throw new InvalidBookException("Invalid Year of publition, It should be greater than 1950");
            else if (pages <= 0)
                throw new InvalidBookException("Pages must be greater than 0");
            Book book = new Book(isbn, title, authors, language, pages, yop);
            books.Add(book);
        }

        /// <summary>
        /// Returns lists of books available in library
        /// </summary>
        /// <returns></returns>
        public List<Book> GetBooks()
        {
            return books;
        }

        ///// <summary>
        ///// returns number of books present in library
        ///// </summary>
        ///// <returns></returns>
        //public int BooksCount()
        //{
        //    return books.Count;
        //}

        /// <summary>
        /// 
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        public List<Book> Search(Func<Book, bool> condition)
        {
            IEnumerable<Book> result = books.Where(condition);
            return result.ToList();
        }
    }
}
