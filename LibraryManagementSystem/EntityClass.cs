using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem
{
    // Kütüphane varlığı
    public class Library
    {

        public int LibraryId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Contact { get; set; }
    }

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

    // Öğrenci varlığı
    public class Student
    {

        public int StudentId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int StudentNumber { get; set; }
        public string Department { get; set; }
        public string Contact { get; set; }

        public List<Borrowing> Borrowings { get; set; } // Ödünç aldığı kitapların listesi

        public Student()
        {
            Borrowings = new List<Borrowing>(); // Boş bir ödünç alma listesi oluşturulur
        }
    }

    // Ödünç Alma İşlemi varlığı
    public class Borrowing
    {

        public int BorrowingId { get; set; }
        public int StudentId { get; set; }
        public Student Student { get; set; }
        public int BookId { get; set; }
        public Book Book { get; set; }
        public DateTime BorrowDate { get; set; }
        public DateTime ReturnDate { get; set; }
    }

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

    // Kategori varlığı
    public class Category
    {

        public int CategoryId { get; set; }
        public string Name { get; set; }
    }
}
