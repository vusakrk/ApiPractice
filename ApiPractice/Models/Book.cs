using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiPractice.Models
{
    public class Book:BaseEntity
    {
        public string Title { get; set; }
        public List<BookAuthor> BookAuthor { get; set; }
    }
}
