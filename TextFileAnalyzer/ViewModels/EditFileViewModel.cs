using System.Collections.Generic;

using TextFileAnalyzer.Models;

namespace TextFileAnalyzer.ViewModels
{
    public class EditItemViewModel
    {
        public FileSettings FileSetting { get; set; }

        public IEnumerable<string> OldRow { get; set; }

        public IEnumerable<string> NewRow { get; set; }
    }
}
