using ApiPractice.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiPractice.DTO
{
    public class BookDTO:BaseDTO
    {
        public string Title { get; set; }
        public List<BookAuthor> BookAuthor { get; set; }
    }
}
