using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TextFileAnalyzer.ViewModels
{
    public class FilesViewModel
    {
        public int CountFiles { get; set; }

        public IEnumerable<string> Path { get; set; }
    }
}
