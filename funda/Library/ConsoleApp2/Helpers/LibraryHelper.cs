using LibraryApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using static LibraryApp.Models.LibraryDelegate;

namespace LibraryApp.Helper
{
    class LibraryHelper
    {        
        /// <summary>
        /// 
        /// </summary>
        public static WriteOnConsole WriteOnConsole = new WriteOnConsole(Program.DisplayMsg);

        /// <summary>
        /// 
        /// </summary>
        public static void DisplayMenu()
        {
            WriteOnConsole("1: Update Book Details In Library \n2: To See Lists Of Available Books In Library \n3: To Search records in library by any category \n4: To Exit From Program");
        }

        /// <summary>
        /// 
        /// </summary>
        public static void DispalaySerchMenu()
        {
            WriteOnConsole("1: Search By ISBN \n2: Search By Title\n3: Search By Language\n4: Search By Year Of Publish\n5: Search By Authors");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <param name="library"></param>
        private static void SearchCriteria(int key, Library library)
        {
            switch (key)
            {
                case 1:
                    EnterData("ISBN", library);                                 break;
                case 2:
                    EnterData("Title", library);                                break;
                case 5:
                    EnterData("Author", library);                               break;
                case 3:
                    EnterData("Language", library);                             break;
                case 4:
                    EnterData("Year Of Publish", library);                      break;
                default:
                    WriteOnConsole("Invalid!, Try again");
                    DispalaySerchMenu();
                    SearchCriteria(int.Parse(Console.ReadLine()), library);     break;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        /// <param name="library"></param>
        private static void EnterData(string data, Library library)
        {
            WriteOnConsole("Enter Value For " + data);
            string value = Console.ReadLine();
            var listOfRecorsFound = SearchResult(value, data, library);
            ShowRecords(listOfRecorsFound);
            WriteOnConsole("If you want to search by other category, enter any key otherwise n");
            char ch = (char)Console.ReadKey().KeyChar;
            WriteOnConsole("");
            if (ch != 'n')
            {
                DispalaySerchMenu();
                SearchCriteria(int.Parse(Console.ReadLine()), library);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <param name="pattern"></param>
        /// <param name="library"></param>
        /// <returns></returns>
        private static List<Book> SearchResult(string value, string pattern, Library library)
        {
            switch (pattern)
            {
                case "ISBN":
                    return library.Search(b => string.Equals(b.ISBN, value, StringComparison.OrdinalIgnoreCase));
                case "Title":
                    return library.Search(b => string.Equals(b.title, value, StringComparison.OrdinalIgnoreCase));
                case "Author":
                    return library.Search(b => b.authors.Any(a => a.ToString().IndexOf(value, StringComparison.OrdinalIgnoreCase) >= 0));                                
                case "Language":
                    return library.Search(b => string.Equals(b.language, value, StringComparison.OrdinalIgnoreCase));
                case "yearOfPublishing":
                    return library.Search(b => string.Equals(b.yearOfPublishing.ToString(), value, StringComparison.OrdinalIgnoreCase));
                default:
                    return null;
            }
        }

        /// <summary>
        /// Display lists of author of a book
        /// </summary>
        /// <param name="authors"></param>
        /// <returns></returns>
        private static string ListOfAuthors(List<Author> authors)
        {
            return string.Join(" : ", authors);
        }

        /// <summary>
        /// Display lists of books available in library
        /// </summary>
        /// <param name="library"></param>
        private static void ListOfbooks(Library library)
        {
            List<Book> books = library.GetBooks();
            if (books.Count == 0)
            {
                WriteOnConsole("Right Now Libray Contains Nothing!, Check After Some Time, Thank You.....");
                return;
            }
            ShowRecords(books);
        }

        private static void ShowRecords(List<Book> books)
        {
            WriteOnConsole("Number of records found " + books.Count);
            if (books.Count != 0)
            {
                WriteOnConsole($"SBIN{"",-12} Title{"",-43} Authors{"",-40} Language{"",-10} Pages{"",-5} Year Of Publish{"",-2}");
            }
            WriteOnConsole("");
            foreach (Book book in books)
            {
                
                WriteOnConsole($"{book.ISBN, -12} {book.title, -43} {ListOfAuthors(book.authors), -56} {book.language, -18} {book.pages, -12} {book.yearOfPublishing, -2}");
            }
        }

        /// <summary>
        /// This method is responsible to add book in library
        /// </summary>
        /// <param name="library"></param>
        private static void UpdateLibrary(Library library)
        {
            List<Book> sucessFull = new List<Book>();
            List<Book> failure = new List<Book>();
            Dictionary<string, string> mapping = new Dictionary<string, string>();
            Notification notify = new Notification(LibraryHelper.Confirmation);
            List<BookModelView> books = DataReaderHelper.CsvBookReader();
            List<Author> authors = DataReaderHelper.CsvAuthorReader();
            //List<Book> books = DataReaderHelper.JsonBookReader();

            foreach (var book in books)
            {
                var bookAuthors = authors
                        .Where(a => a.ISBN == book.ISBN)
                        .ToList();
                try
                {
                    library.AddBook(book.ISBN, book.title, bookAuthors, book.language, book.pages.Value, book.yearOfPublishing.Value);
                    sucessFull.Add(new Book(book.ISBN, book.title, bookAuthors, book.language, book.pages.Value, book.yearOfPublishing.Value));
                }
                catch (Exception ex)
                {
                    mapping.Add(book.ISBN, (ex.Message.ToString()));
                    failure.Add(new Book(book.ISBN, book.title, bookAuthors, book.language, book.pages.Value, book.yearOfPublishing.Value));
                }
                //finally
                //{
                //    continue;
                //}
            }
            WriteOnConsole("");
            notify(sucessFull, failure, mapping);
        }

        /// <summary>
        /// Method to print notification that book is added.
        /// </summary>
        /// <param name="title"></param>
        /// <param name="author"></param>
        private static void Confirmation(List<Book> sucessFull, List<Book> failure, Dictionary<string, string> mapping)
        {
            WriteOnConsole($"Number Of Sucessfully Added Books {sucessFull.Count}");
            if (sucessFull.Count != 0)
            {
                WriteOnConsole($"Title {"",-45}  Authors");
            }
            foreach (var book in sucessFull)
            {
                WriteOnConsole($"{book.title, -45} : {ListOfAuthors(book.authors)}");
            }
            WriteOnConsole("");
            WriteOnConsole($"Number Of Failures {failure.Count}");
            if (failure.Count != 0)
            {
                WriteOnConsole($"Title {"",-45}  Authors{"", -30} Exception");
            }
            foreach (var book in failure)
            {
                foreach (var entry in mapping)
                {
                    if(string.Equals(entry.Key, book.ISBN))
                    {
                        WriteOnConsole($"{book.title,-45} : {ListOfAuthors(book.authors), -40} {entry.Value}");
                    }
                }
                
            }
        }


        public static void LibraryExecutionStart()
        {
            Library library = new Library();
            while (true)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                DisplayMenu();
                Console.ResetColor();
                WriteOnConsole("");
                int choice = int.Parse(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        Console.ForegroundColor = ConsoleColor.Blue;                 
                        UpdateLibrary(library);
                        Console.ResetColor();
                        WriteOnConsole("");                                                 break;
                    case 2:
                        Console.ForegroundColor = ConsoleColor.DarkCyan;                       
                        ListOfbooks(library);
                        Console.ResetColor();
                        WriteOnConsole("");                                                 break;
                    case 3:
                        Console.ForegroundColor = ConsoleColor.DarkGray;
                        DispalaySerchMenu();
                        int key = int.Parse(Console.ReadLine());
                        SearchCriteria(key, library);
                        Console.ResetColor();
                        WriteOnConsole("");                                                 break;
                    case 4:
                        Environment.Exit(0);
                        break;
                    default:
                        WriteOnConsole("Invalid!, Try Again");                              break;
                }
            }
        }
    }
}
