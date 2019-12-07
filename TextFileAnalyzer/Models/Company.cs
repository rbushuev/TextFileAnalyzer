using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TextFileAnalyzer.Models
{
    public class Company
    {
        public int Id { get; set; }

        public IEnumerable<string> Info { get; set; }
    }
}
