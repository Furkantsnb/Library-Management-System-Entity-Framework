using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem
{
    public class LibraryManager
    {
        LibraryManagementContext context = new LibraryManagementContext();
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

        // Switch case : 1 
        public void UpdateLibraryCase()
        {
            Console.WriteLine("Kütüphane Bilgilerini Güncelle");
            Console.Write("Kütüphane Adı: ");
            string libraryName = Console.ReadLine().Trim().ToUpper();
            Console.Write("Adres: ");
            string libraryAddress = Console.ReadLine().Trim().ToUpper();
            Console.Write("İletişim: ");
            string libraryContact = Console.ReadLine().Trim().ToUpper();
            UpdateLibrary(libraryName, libraryAddress, libraryContact);
            Console.WriteLine("Kütüphane bilgileri güncellendi.");
        }

        // Kütüphane bilgilerini görüntüleme // Switch case : 8
        public void DisplayLibraryInfo()
        {
            Console.WriteLine("Kütüphane Bilgilerini Görüntüle");
            var library = context.Libraries.FirstOrDefault();
            if (library != null)
            {
                Console.WriteLine("Kütüphane Adı: " + library.Name);
                Console.WriteLine("Adres: " + library.Address);
                Console.WriteLine("İletişim: " + library.Contact);
            }
        }
    }
}
