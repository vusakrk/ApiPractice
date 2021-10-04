using ApiPractice.DAL;
using ApiPractice.DTO;
using ApiPractice.Models;
using ApiPractice.Services.Interface;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiPractice.Services.Implementation
{
    public class BookService:IBookService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        public BookService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        int IBookService.Create(BookDTO book)
        {
            var newBook = _mapper.Map<Book>(book);
            _context.Books.Add(newBook);
            _context.SaveChanges();
            return newBook.Id;
        }

        BookDTO IBookService.Delete(int id)
        {
            var bookDb = _context.Books.FirstOrDefault(p => p.Id == id);
            if (bookDb == null)
                return null;
            _context.Books.Remove(bookDb);
            _context.SaveChanges();
            return _mapper.Map<BookDTO>(bookDb);
        }

        BookDTO IBookService.Edit(int id, BookDTO book)
        {
            var bookDb = _context.Books.FirstOrDefault(p => p.Id == id);
            if (bookDb == null)
                return null;
            book.Id = bookDb.Id;
            _mapper.Map(book, bookDb);
            _context.SaveChanges();
            return book;
        }

        BookDTO IBookService.GetBook(int id)
        {
            var bookDb = _context.Books.FirstOrDefault(p => p.Id == id);
            if (bookDb == null)
                return null;
            return _mapper.Map<BookDTO>(bookDb);
        }

        IEnumerable<BookDTO> IBookService.GetBooks()
        {
            var books = _context.Books.ToList();
            return _mapper.Map<List<BookDTO>>(books);
        }
    }
}
