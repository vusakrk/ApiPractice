using ApiPractice.DAL;
using ApiPractice.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ApiPractice.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly AppDbContext _context;

        public BookController(AppDbContext context)
        {
            _context = context;
        }
        // GET: api/<BookController>
        [HttpGet]
        public ActionResult Get()
        {
            var book = _context.Books.ToList();
            if (book == null)
                return NotFound();
            return Ok(book);
        }

        // GET api/<BookController>/5
        [HttpGet]
        [Route("{id}")]
        public ActionResult Get(int id)
        {
            var book = _context.Books.FirstOrDefault(b => b.Id == id);
            if (book == null)
                return NotFound();
            return Ok(book);
        }

        // POST api/<BookController>
        [HttpPost]
        public ActionResult Post([FromBody] Book book)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            _context.Books.Add(book);
            _context.SaveChanges();

            return Ok(book);
        }

        // PUT api/<BookController>/5
        [HttpPut]
        [Route("{id}")]
        public ActionResult Put(int id, [FromBody] Book book)
        {

            var updateBook = _context.Books.Find(book.Id);
            updateBook.Title = book.Title;
            _context.Books.Update(updateBook);
            _context.SaveChanges();
            return Ok(book);
        }

        //DELETE api/<BookController>/5
        [HttpDelete]
        [Route("{id}")]
        public IActionResult Delete(int id)
        {
            var book = _context.Books.Find(id);
            _context.Books.Remove(book);
            _context.SaveChanges();

            return Ok(book);
        }
    }
}
