using System.Globalization;
using LibraryManagementSystem;
using LibraryManagementSystem.Entitys;
// Kütüphane Yönetim Sistemi kullanım örneği


class Program
{
    static void Main(string[] args)
    {

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
                    LibraryManager libraryManager = new LibraryManager();
                    libraryManager.UpdateLibraryCase();
                    break;

                case 2:
                    StudentManager studentManager = new StudentManager();
                    studentManager.AddStudent();
                    break;

                case 3:
                    StudentManager studentManager1 = new StudentManager();
                    studentManager1.DeleteStudent();
                    break;

                case 4:
                    BookManager bookManager = new BookManager();
                    bookManager.AddBookCase();
                    break;

                case 5:
                    BookManager bookManager1 = new BookManager();
                    bookManager1.DeleteBook();
                    break;

                case 6:
                    StudentManager studentManager3 = new StudentManager();
                    studentManager3.BookBorrowingProcess();
                    break;

                case 7:
                    StudentManager studentManager4 = new StudentManager();
                    studentManager4.BookReturn();
                    break;

                case 8:

                    LibraryManager libraryManager1 = new LibraryManager();
                    libraryManager1.DisplayLibraryInfo();
                    break;

                case 9:
                    StudentManager studentManager5 = new StudentManager();
                   
                    studentManager5.DisplayStudentsWithBooks();
                    break;

                case 10:

                    BookManager bookManager2 = new BookManager();
                    bookManager2.DisplayAuthorsWithBooks();
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
