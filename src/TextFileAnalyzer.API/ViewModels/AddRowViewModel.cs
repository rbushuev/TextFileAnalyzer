using System.Collections.Generic;

using TextFileAnalyzer.API.Models;

namespace TextFileAnalyzer.API.ViewModels
{
    public class AddItemViewModel
    {
        public FileSettings FileSetting { get; set; }

        public IEnumerable<string> Row { get; set; }
    }
}
