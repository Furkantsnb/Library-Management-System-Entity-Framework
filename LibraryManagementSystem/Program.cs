using System.Globalization;

namespace LibraryManagementSystem
{
    // Kütüphane Yönetim Sistemi kullanım örneği
    class Program
    {
        static void Main(string[] args)
        {
            LibraryManagementSystem librarySystem = new LibraryManagementSystem();

            while (true)
            {
                Console.WriteLine("İşlem Seçin:");
                Console.WriteLine("1. Kütüphane Bilgilerini Güncelle");
                Console.WriteLine("2. Öğrenci Ekle");
                Console.WriteLine("3. Öğrenci Silme");
                Console.WriteLine("4. Kitap Ekle");
                Console.WriteLine("5. Kitap Silme");
                Console.WriteLine("6. Ödünç Alma İşlemi Yap");
                Console.WriteLine("7. kitap İade İşlemi Yap");
                Console.WriteLine("8. Kütüphane Bilgilerini Görüntüle");
                Console.WriteLine("9. Öğrenci Bilgilerini Görüntüle");
                Console.WriteLine("10. Yazar Bilgilerini Görüntüle");
                Console.WriteLine("0. Çıkış");

                Console.Write("Seçiminizi yapın (0-10): ");
                int choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        Console.WriteLine("Kütüphane Bilgilerini Güncelle");
                        Console.Write("Kütüphane Adı: ");
                        string libraryName = Console.ReadLine().Trim().ToUpper();
                        Console.Write("Adres: ");
                        string libraryAddress = Console.ReadLine().Trim().ToUpper();
                        Console.Write("İletişim: ");
                        string libraryContact = Console.ReadLine().Trim().ToUpper();
                        librarySystem.UpdateLibrary(libraryName, libraryAddress, libraryContact);
                        Console.WriteLine("Kütüphane bilgileri güncellendi.");
                        break;

                    case 2:
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
                        librarySystem.AddStudent(student);
                        Console.WriteLine("Öğrenci eklendi.");
                        break;

                    case 3:
                        Console.WriteLine("Öğrenci Silme");
                        Console.Write("Öğrenci Numarası: ");
                        int studentNumberToDelete = int.Parse(Console.ReadLine());
                        Student studentToDelete = librarySystem.GetStudentByNumber(studentNumberToDelete);
                        if (studentToDelete != null)
                        {
                            librarySystem.RemoveStudent(studentToDelete);
                            Console.WriteLine("Öğrenci silindi.");
                        }
                        else
                        {
                            Console.WriteLine("Öğrenci bulunamadı.");
                        }
                        break;

                    case 4:
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
                        librarySystem.AddBook(book);
                        Console.WriteLine("Kitap eklendi.");
                        break;

                    case 5:
                        Console.WriteLine("Kitap Silme");
                        Console.Write("Kitap Adı: ");
                        string bookTitleToDelete = Console.ReadLine().Trim().ToUpper();
                        Book bookToDelete = librarySystem.GetBookByTitle(bookTitleToDelete);
                        if (bookToDelete != null)
                        {
                            librarySystem.RemoveBook(bookToDelete);
                            Console.WriteLine("Kitap silindi.");
                        }
                        else
                        {
                            Console.WriteLine("Kitap bulunamadı.");
                        }
                        break;

                    case 6:
                        Console.WriteLine("Ödünç Alma İşlemi Yap");
                        Console.Write("Öğrenci Numarası: ");
                        int borrowingStudentNumber = int.Parse(Console.ReadLine());
                        Console.Write("Kitap Adı: ");
                        string borrowingBookTitle = Console.ReadLine().Trim().ToUpper();
                        Console.Write("Ödünç Alma Tarihi (GG.AA.YYYY): ");
                        DateTime borrowDate = DateTime.ParseExact(Console.ReadLine(), "dd.MM.yyyy", CultureInfo.InvariantCulture);
                        Console.Write("Geri Dönüş Tarihi (GG.AA.YYYY): ");
                        DateTime returnDate = DateTime.ParseExact(Console.ReadLine(), "dd.MM.yyyy", CultureInfo.InvariantCulture);

                        Student borrowingStudent = librarySystem.GetStudentByNumber(borrowingStudentNumber);
                        Book borrowingBook = librarySystem.GetBookByTitle(borrowingBookTitle);

                        if (borrowingStudent != null && borrowingBook != null)
                        {
                            librarySystem.BorrowBook(borrowingStudent, borrowingBook, borrowDate, returnDate);
                            Console.WriteLine("Kitap ödünç alındı.");
                        }
                        else
                        {
                            Console.WriteLine("Öğrenci veya kitap bulunamadı.");
                        }
                        break;

                    case 7:
                        Console.WriteLine("Kitap İade");
                        Console.Write("Öğrenci Numarası: ");
                        int studentNumberForReturn = int.Parse(Console.ReadLine());
                        Console.Write("Kitap Adı: ");
                        string bookTitleForReturn = Console.ReadLine().Trim().ToUpper();
                        Student studentForReturn = librarySystem.GetStudentByNumber(studentNumberForReturn);
                        Book bookForReturn = librarySystem.GetBookByTitle(bookTitleForReturn);
                        if (studentForReturn != null && bookForReturn != null)
                        {
                            librarySystem.ReturnBook(studentForReturn, bookForReturn);
                            Console.WriteLine("Kitap iade edildi.");
                        }
                        else
                        {
                            Console.WriteLine("Öğrenci veya kitap bulunamadı.");
                        }
                        break;

                    case 8:
                        Console.WriteLine("Kütüphane Bilgilerini Görüntüle");
                        librarySystem.DisplayLibraryInfo();
                        break;

                    case 9:
                        Console.WriteLine("Öğrencilerin Aldıkları ve İade Ettikleri Kitaplar");
                        librarySystem.DisplayStudentsWithBooks();
                        break;

                    case 10:
                        Console.WriteLine("Yazarlar ve Kitap Bilgileri");
                        librarySystem.DisplayAuthorsWithBooks();
                        break;
                    case 11:
                        Console.WriteLine("Programdan çıkılıyor...");
                        return;

                    default:
                        Console.WriteLine("Geçersiz seçim. Tekrar deneyin.");
                        break;
                }
                Console.WriteLine("Devam etmek için bir tuşa basın...");
                Console.ReadKey();

                Console.Clear();

                Console.WriteLine();
            }
        }

    }
}