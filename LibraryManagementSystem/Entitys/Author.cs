using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Entitys
{
    // Yazar varlığı
    public class Author
    {

        public int AuthorId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime BirthDate { get; set; }

        public List<Book> Books { get; set; } // Kitapların listesi

        public Author()
        {
            Books = new List<Book>(); // Boş bir kitap listesi oluşturulur
        }
    }
}
