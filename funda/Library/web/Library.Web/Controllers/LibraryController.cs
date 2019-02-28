using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System;
using LibraryApp.Models;
using System.Net;
using System.Net.Http;

namespace LibraryWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LibraryController : ControllerBase
    {
        Library _library;
        public LibraryController(Library library)
        {
            _library = library;
        }
        // GET api/library
        [HttpGet]
        public ActionResult<IEnumerable<Book>> Get()
        {
            if (_library == null || _library.GetBooks() == null || _library.GetBooks().Count == 0)
            {
                return NotFound();
            }
            return Ok(_library.GetBooks());
        }

        // GET api/library/439023483
        [HttpGet("{isbn}")]
        public ActionResult<IEnumerable<Book>> GetById(string isbn)
        {
            List<Book> books = _library.Search(b => string.Equals(b.ISBN, isbn, StringComparison.OrdinalIgnoreCase));
            if(books == null || books.Count == 0)
            {
                return NotFound();
            }
            return Ok(books);
        }

        // POST api/library
        [HttpPost]
        public ActionResult<string> Post([FromBody] Book book)
        {
            try
            {
                _library.AddBook(book.ISBN, book.title, book.authors, book.language, book.pages, book.yearOfPublishing);
                return Ok(book);
            }
            catch(InvalidBookException IBE)
            {
                return new HttpResponseMessage("Your message here");
            }
        }

        // PUT api/library/5
        [HttpPut("{isbn}")]
        public ActionResult<string> Put(string isbn, [FromBody] Book book)
        {
            if (_library.Update(isbn, book) != -1)
                return Ok("Updated SucessFully");
            return NotFound();
        }

        // DELETE api/library/5
        [HttpDelete("{isbn}")]
        public ActionResult<string> Delete(string isbn)
        {
            if (_library.DeleteBook(isbn) != -1)
                return Ok("Deleted SucessFully");
            return NotFound();
        }
    }
}
