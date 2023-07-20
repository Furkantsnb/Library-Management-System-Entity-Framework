using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem
{
    // Kütüphane Yönetim Sistemi DbContext sınıfı
    public class LibraryManagementContext : DbContext
    {
        public DbSet<Library> Libraries { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Borrowing> Borrowings { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //projeye uygun Provider yükleyin ben sqlServer kütüphanesini kullandım
            optionsBuilder.UseSqlServer("Server= LAPTOP-I5A7DU4B;Database=LibraryManagementSystem;User Id = sa;Password=123456;TrustServerCertificate=true");
        }
    }
}
//