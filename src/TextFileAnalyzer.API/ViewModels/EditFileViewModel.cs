using System.Collections.Generic;

using TextFileAnalyzer.API.Models;

namespace TextFileAnalyzer.API.ViewModels
{
    public class EditItemViewModel
    {
        public FileSettings FileSetting { get; set; }

        public IEnumerable<string> OldRow { get; set; }

        public IEnumerable<string> NewRow { get; set; }
    }
}
