using ApiPractice.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiPractice.Services.Interface
{
    public interface IBookService
    {
        IEnumerable<BookDTO> GetBooks();
        BookDTO GetBook(int id);
        int Create(BookDTO book);
        BookDTO Edit(int id,BookDTO book);
        BookDTO Delete(int id);
    }
}
