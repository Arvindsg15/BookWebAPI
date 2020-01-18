using BookWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BookWebAPI.Controllers
{
    public class BookController : ApiController
    {
        // creating book of array
        Book[] books = new Book[]
        {
           new Book() {Id=1,Author="Billy Goat",Price=100, Title="Spider without Duty" },
           new Book() {Id=2,Author="Billy Goat", Price=200,Title="Gaints and Theives" },
           new Book() {Id=3,Author="Billy Goat", Price=300,Title="Wisdom" },
           new Book() {Id=4,Author="Billy Goat", Price=400,Title="Fortune" }
        };


        // GET: api/Book
        public IHttpActionResult Get()
        {
            return Ok(books);
        }

        // GET: api/Book/5
        public IHttpActionResult Get(int id)
        {
            Book book = books.FirstOrDefault<Book>(b => b.Id == id);

            if(book==null)
            {
                return NotFound();
            }

            return Ok(book);
        }

        // POST: api/Book
        public IHttpActionResult Post([FromBody]Book newBook)
        {
            // converting array book to list
            List<Book> booklist = books.ToList();
            newBook.Id = booklist.Count + 1;
            booklist.Add(newBook);
            return Ok(booklist.ToList());
        }

        // PUT: api/Book/5
        public IHttpActionResult Put(int id, [FromBody]Book updatebook)
        {
            Book book = books.FirstOrDefault<Book>(b => b.Id == id);
            if (book==null)
            {
                return NotFound();
            }

            book.Id = updatebook.Id;
            book.Author = updatebook.Author;
            book.Price = updatebook.Price;
            book.Title = updatebook.Title;

            return Ok(books);

        }

        // DELETE: api/Book/5
        public IHttpActionResult Delete(int id)
        {
            // converting array book to list
            List<Book> booklist = books.ToList();
            Book booktoremove = books.FirstOrDefault<Book>(b => b.Id == id);
            booklist.Remove(booktoremove);
            return Ok(booklist.ToList());
        }
    }
}
