using ConsoleAppCSV.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppCSV
{
    internal class UniversityExporter : University
    {
        public string CreatedDate { get; set; }
        public string Author { get; set; }
    }
}
