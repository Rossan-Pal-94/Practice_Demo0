using System;
using LibraryApp;
using LibraryApp.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LibraryUnitTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            Library library = new Library();
            library.AddBook("C", "Dipti", 1998);
            library.AddBook("Java", "Nageshwara", 2005);
            library.AddBook("C#", "kudvenkat", 2007);

            Library library1 = library;
            Assert.AreEqual(library.BooksCount(), library1.BooksCount());
        }
    }
}
