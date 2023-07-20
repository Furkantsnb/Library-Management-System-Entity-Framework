using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace LibraryManagementSystem
{
   

    // Kütüphane Yönetim Sistemi
 public class LibraryManagementSystem
 {
    private LibraryManagementContext context;

    public LibraryManagementSystem()
    {
        context = new LibraryManagementContext();
    }

    // Kütüphane kaynağı ekleme
    public void AddBook(Book book)
    {
        context.Books.Add(book);
        context.SaveChanges();
    }

    // Kütüphane kaynağı silme
    public void RemoveBook(Book book)
    {
        context.Books.Remove(book);
        context.SaveChanges();
    }

    // Öğrenci numarasına göre öğrenciyi getirme
    public Student GetStudentByNumber(int studentNumber)
    {
            return context.Students.FirstOrDefault(s => s.StudentNumber == studentNumber);
    }

        // Öğrenci ekleme
        public void AddStudent(Student student)
    {
        context.Students.Add(student);
        context.SaveChanges();
    }

    // Öğrenci silme
    public void RemoveStudent(Student student)
    {
        context.Students.Remove(student);
        context.SaveChanges();
    }

    // Ödünç alma işlemi yapma
    public void BorrowBook(Student student, Book book, DateTime borrowDate, DateTime returnDate)
    {
        var borrowing = new Borrowing
        {
            StudentId = student.StudentId,
            BookId = book.BookId,
            BorrowDate = borrowDate,
            ReturnDate = returnDate
        };
        context.Borrowings.Add(borrowing);
        context.SaveChanges();
    }

    // Ödünç alma işlemi iptal etme
    public void ReturnBook(Student student, Book book)
    {
        var borrowing = context.Borrowings.FirstOrDefault(b => b.StudentId == student.StudentId && b.BookId == book.BookId);
        if (borrowing != null)
        {
            context.Borrowings.Remove(borrowing);
            context.SaveChanges();
        }
    }

    // Kitap başlığına göre kitabı getirme
    public Book GetBookByTitle(string bookTitle)
    {
         return context.Books.FirstOrDefault(b => b.Title == bookTitle);
    }

        // Yazar ekleme
        public void AddAuthor(Author author)
    {
        context.Authors.Add(author);
        context.SaveChanges();
    }

    // Yazar silme
    public void RemoveAuthor(Author author)
    {
        context.Authors.Remove(author);
        context.SaveChanges();
    }

    // Kategori ekleme
    public void AddCategory(Category category)
    {
        context.Categories.Add(category);
        context.SaveChanges();
    }

    // Kategori silme
    public void RemoveCategory(Category category)
    {
        context.Categories.Remove(category);
        context.SaveChanges();
    }

    // Kategori adına göre kategoriyi getirme
    public Category GetCategoryByName(string categoryName)
    {
     return context.Categories.FirstOrDefault(c => c.Name == categoryName);
    }


        // Kütüphane bilgilerini güncelleme
        public void UpdateLibrary(string name, string address, string contact)
    {
        var library = context.Libraries.FirstOrDefault();
        if (library != null)
        {
            library.Name = name;
            library.Address = address;
            library.Contact = contact;
            context.SaveChanges();
        }
    }

    // Kütüphane bilgilerini görüntüleme
    public void DisplayLibraryInfo()
    {
        var library = context.Libraries.FirstOrDefault();
        if (library != null)
        {
            Console.WriteLine("Kütüphane Adı: " + library.Name);
            Console.WriteLine("Adres: " + library.Address);
            Console.WriteLine("İletişim: " + library.Contact);
        }
    }

        // Tüm öğrencileri aldıkları ve iade ettikleri kitaplara göre görüntüleme
        public void DisplayStudentsWithBooks()
        {
            var students = context.Students.Include(s => s.Borrowings).ThenInclude(b => b.Book).ToList();
            foreach (var student in students)
            {
                Console.WriteLine("Öğrenci: " + student.Name + " " + student.Surname);
                Console.WriteLine("Aldığı Kitaplar:");
                foreach (var borrowing in student.Borrowings)
                {
                    Console.WriteLine(" - " + borrowing.Book.Title);
                }
                Console.WriteLine("İade Ettiği Kitaplar:");
                foreach (var borrowing in student.Borrowings)
                {
                    if (borrowing.ReturnDate < DateTime.Now)
                    {
                        Console.WriteLine(" - " + borrowing.Book.Title);
                    }
                }
                Console.WriteLine();
            }
        }

        // Tüm yazarları kitapları ile beraber görüntüleme
        public void DisplayAuthorsWithBooks()
        {
            var authors = context.Authors.Include(a => a.Books).ToList();
            foreach (var author in authors)
            {
                Console.WriteLine("Yazar: " + author.Name + " " + author.Surname);
                Console.WriteLine("Kitapları:");
                foreach (var book in author.Books)
                {
                    Console.WriteLine(" - " + book.Title);
                }
                Console.WriteLine();
            }
        }
    }
}