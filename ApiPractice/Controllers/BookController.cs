using ApiPractice.DAL;
using ApiPractice.DTO;
using ApiPractice.Models;
using ApiPractice.Services.Interface;
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
        private readonly IBookService _bookService;

        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }
        // GET: api/<BookController>
        [HttpGet]
        public ActionResult GetBooks()
        {
            return Ok(_bookService.GetBooks());
        }

        // GET api/<BookController>/5
        [HttpGet]
        [Route("{id}")]
        public ActionResult GetBook(int id)
        {
            var book = _bookService.GetBook(id);
            if (book == null)
                return NotFound();
            return Ok(book);
        }

        // POST api/<BookController>
        [HttpPost]
        public ActionResult Create([FromBody] BookDTO book)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            _bookService.Create(book);
            return Ok(book);
        }

        // PUT api/<BookController>/5
        [HttpPut]
        [Route("{id}")]
        public ActionResult Edit(int id, [FromBody] BookDTO book)
        {

            if (!ModelState.IsValid)
                return BadRequest();
            return Ok(_bookService.Edit(id, book));
        }

        //DELETE api/<BookController>/5
        [HttpDelete]
        [Route("{id}")]
        public IActionResult Delete(int id)
        {
            return Ok(_bookService.Delete(id));
        }
    }
}
