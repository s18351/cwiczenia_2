using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppCSV.Models
{
    internal class University
    {
        public string createdAt { get; set; }
        public string author { get; set; }
        public List<Student> studenci { get; set; }
        public List<ActiveStudy> activeStudies { get; set; }
    }
}
