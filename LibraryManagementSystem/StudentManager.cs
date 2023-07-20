using LibraryManagementSystem.Entitys;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem
{
    public class StudentManager
    {

        LibraryManagementContext context = new LibraryManagementContext();

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




        // Tüm öğrencileri aldıkları ve iade ettikleri kitaplara göre görüntüleme
        public void DisplayStudentsWithBooks()
        {
            Console.WriteLine("Öğrencilerin Aldıkları ve İade Ettikleri Kitaplar");
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

        public void AddStudent()
        {
            Console.WriteLine("Öğrenci Ekle");
            Console.Write("Ad: ");
            string studentName = Console.ReadLine().Trim().ToUpper();
            Console.Write("Soyad: ");
            string studentSurname = Console.ReadLine().Trim().ToUpper();
            Console.Write("Öğrenci Numarası: ");
            int studentNumber = int.Parse(Console.ReadLine());
            Console.Write("Bölüm: ");
            string studentDepartment = Console.ReadLine().Trim().ToUpper();
            Console.Write("İletişim: ");
            string studentContact = Console.ReadLine().Trim().ToUpper();
            Student student = new Student
            {
                Name = studentName,
                Surname = studentSurname,
                StudentNumber = studentNumber,
                Department = studentDepartment,
                Contact = studentContact
            };
            AddStudent(student);
            Console.WriteLine("Öğrenci eklendi.");
        }



        public void DeleteStudent()
        {
            Console.WriteLine("Öğrenci Silme");
            Console.Write("Öğrenci Numarası: ");
            int studentNumberToDelete = int.Parse(Console.ReadLine());
            Student studentToDelete = GetStudentByNumber(studentNumberToDelete);
            if (studentToDelete != null)
            {
                RemoveStudent(studentToDelete);
                Console.WriteLine("Öğrenci silindi.");
            }
            else
            {
                Console.WriteLine("Öğrenci bulunamadı.");
            }
        }

        public void BookBorrowingProcess()
        {
            BookManager bookManager5 = new BookManager();
            Console.WriteLine("Ödünç Alma İşlemi Yap");
            Console.Write("Öğrenci Numarası: ");
            int borrowingStudentNumber = int.Parse(Console.ReadLine());
            Console.Write("Kitap Adı: ");
            string borrowingBookTitle = Console.ReadLine().Trim().ToUpper();
            Console.Write("Ödünç Alma Tarihi (GG.AA.YYYY): ");
            DateTime borrowDate = DateTime.ParseExact(Console.ReadLine(), "dd.MM.yyyy", CultureInfo.InvariantCulture);
            Console.Write("Geri Dönüş Tarihi (GG.AA.YYYY): ");
            DateTime returnDate = DateTime.ParseExact(Console.ReadLine(), "dd.MM.yyyy", CultureInfo.InvariantCulture);

            Student borrowingStudent = GetStudentByNumber(borrowingStudentNumber);
            Book borrowingBook = bookManager5.GetBookByTitle(borrowingBookTitle);

            if (borrowingStudent != null && borrowingBook != null)
            {
                BorrowBook(borrowingStudent, borrowingBook, borrowDate, returnDate);
                Console.WriteLine("Kitap ödünç alındı.");
            }
            else
            {
                Console.WriteLine("Öğrenci veya kitap bulunamadı.");
            }
        }


        public void BookReturn()
        {
            BookManager bookManager6 = new BookManager();
            Console.WriteLine("Kitap İade");
            Console.Write("Öğrenci Numarası: ");
            int studentNumberForReturn = int.Parse(Console.ReadLine());
            Console.Write("Kitap Adı: ");
            string bookTitleForReturn = Console.ReadLine().Trim().ToUpper();
            Student studentForReturn =GetStudentByNumber(studentNumberForReturn);
            Book bookForReturn = bookManager6.GetBookByTitle(bookTitleForReturn);
            if (studentForReturn != null && bookForReturn != null)
            {
                ReturnBook(studentForReturn, bookForReturn);
                Console.WriteLine("Kitap iade edildi.");
            }
            else
            {
                Console.WriteLine("Öğrenci veya kitap bulunamadı.");
            }

        }

    }
}
