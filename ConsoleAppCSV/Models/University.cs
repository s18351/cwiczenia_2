using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppCSV.Models
{
    internal class University
    {
        public Student[] Students { get; set; }
        public Studies[] ActiveStudies { get; set; }
    }
}
