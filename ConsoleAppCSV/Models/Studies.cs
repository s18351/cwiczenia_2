using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppCSV.Models
{
    public class Studies
    {
        public string Name { get; set; }
        public string Mode { get; set; }

        public Student[] Students { get; set; }
    }
}
