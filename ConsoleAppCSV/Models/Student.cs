using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppCSV.Models
{
    internal class Student
    {
        public string indexNumber { get; set; }
        public string fname { get; set; }
        public string lname { get; set; }
        public string birthdate { get; set; }
        public string email { get; set; }
        public string mothersName { get; set; }
        public string fathersName { get; set; }
        public Studies studies { get; set; }

        public override int GetHashCode()
        {
            return (indexNumber.GetHashCode() + fname.GetHashCode() + lname.GetHashCode());
        }
        public override bool Equals(object? obj)
        {
            return obj != null && indexNumber == ((Student)obj).indexNumber && fname == ((Student)obj).fname && lname == ((Student)obj).lname;
        }
    }
}
