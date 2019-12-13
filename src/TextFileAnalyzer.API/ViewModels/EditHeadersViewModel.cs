using System.Collections.Generic;

using TextFileAnalyzer.API.Models;

namespace TextFileAnalyzer.API.ViewModels
{
    public class EditHeadersViewModel
    {
        public FileSettings FileSetting { get; set; }

        public IEnumerable<string> OldHeaders { get; set; }

        public IEnumerable<string> NewHeaders { get; set; }
    }
}
