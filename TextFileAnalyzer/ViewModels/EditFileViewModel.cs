using System.Collections.Generic;

using TextFileAnalyzer.Models;

namespace TextFileAnalyzer.ViewModels
{
    public class EditFileViewModel
    {
        public FileSettingViewModel FileSetting { get; set; }

        public IEnumerable<string> OldRow { get; set; }

        public IEnumerable<string> NewRow { get; set; }
    }
}
