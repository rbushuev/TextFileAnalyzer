using System.Collections.Generic;

namespace TextFileAnalyzer.ViewModels
{
    public class AddItemViewModel
    {
        public FileSettings FileSetting { get; set; }

        public IEnumerable<string> Row { get; set; }
    }
}
