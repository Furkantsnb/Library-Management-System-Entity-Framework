using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Entitys
{
    // Kitap varlığı
    public class Book
    {

        public int BookId { get; set; }
        public string Title { get; set; }
        public int AuthorId { get; set; }
        public Author Author { get; set; }
        public string Publisher { get; set; }
        public string ISBN { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public string Language { get; set; }
    }
}