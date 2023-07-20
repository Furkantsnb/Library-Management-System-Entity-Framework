using LibraryManagementSystem.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Globalization;

namespace LibraryManagementSystem
{
    public class BookManager
    {

        LibraryManagementContext context = new LibraryManagementContext();
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

        // Kitap başlığına göre kitabı getirme
        public Book GetBookByTitle(string bookTitle)
        {
            return context.Books.FirstOrDefault(b => b.Title == bookTitle);
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


        // Yazar silme
        public void RemoveAuthor(Author author)
        {
            context.Authors.Remove(author);
            context.SaveChanges();
        }

        // Yazar ekleme
        public void AddAuthor(Author author)
        {
            context.Authors.Add(author);
            context.SaveChanges();
        }


        // Switch case : 10
        // Tüm yazarları kitapları ile beraber görüntüleme
        public void DisplayAuthorsWithBooks()
        {
            Console.WriteLine("Yazarlar ve Kitap Bilgileri");
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





            // Switch case : 4 
            public void AddBookCase()
            {
                Console.WriteLine("Kitap Ekle");
                Console.Write("Kitap Adı: ");
                string bookTitle = Console.ReadLine().Trim().ToUpper();
                Console.Write("Yazar Adı: ");
                string authorName = Console.ReadLine().Trim().ToUpper();
                Console.Write("Yazar Soyadı: ");
                string authorSurname = Console.ReadLine().Trim().ToUpper();
                Console.Write("Yazar Doğum Tarihi (GG.AA.YYYY): ");
                DateTime authorBirthDate = DateTime.ParseExact(Console.ReadLine(), "dd.MM.yyyy", CultureInfo.InvariantCulture);
                Console.Write("Yayınevi: ");
                string bookPublisher = Console.ReadLine().Trim().ToUpper();
                Console.Write("ISBN: ");
                string bookISBN = Console.ReadLine().Trim();
                Console.Write("Kategori: ");
                string categoryName = Console.ReadLine().Trim().ToUpper();
                Console.Write("Dil: ");
                string bookLanguage = Console.ReadLine().Trim().ToUpper();

                Author author = new Author
                {
                    Name = authorName,
                    Surname = authorSurname,
                    BirthDate = authorBirthDate
                };

                Category category = new Category
                {
                    Name = categoryName
                };

                Book book = new Book
                {
                    Title = bookTitle,
                    Author = author,
                    Publisher = bookPublisher,
                    ISBN = bookISBN,
                    Category = category,
                    Language = bookLanguage
                };
                AddBook(book);
                Console.WriteLine("Kitap eklendi.");
            }



            // Switch case : 5
             public void DeleteBook()
            {
                Console.WriteLine("Kitap Silme");
                Console.Write("Kitap Adı: ");
                string bookTitleToDelete = Console.ReadLine().Trim().ToUpper();
                Book bookToDelete = GetBookByTitle(bookTitleToDelete);
                if (bookToDelete != null)
                {
                    RemoveBook(bookToDelete);
                    Console.WriteLine("Kitap silindi.");
                }
                else
                {
                    Console.WriteLine("Kitap bulunamadı.");
                }
            }
    }
} 
