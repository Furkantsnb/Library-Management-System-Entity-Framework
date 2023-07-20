using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Entitys
{
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
}
