using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TextFileAnalyzer.Models
{
    public class FileProperty
    {
        public string Name { get; set; }

        public string FullPath { get; set; }

        public double FileSize { get; set; }
    }
}
