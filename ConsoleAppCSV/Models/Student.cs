using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppCSV.Models
{
    public class Student
    {
        //Paweł,Kowalski375,Informatyka dzienne,Dzienne,4533,2000-02-12,375@pjwstk.edu.pl,Alina,Adam
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int IndexNumber{ get; set; }
        public string Birthdate { get; set; }
        public string Email { get; set; }
        public string MotherName { get; set; }
        public string FatherName { get; set; }

    }
}
