using System.Collections.Generic;

namespace TextFileAnalyzer.ViewModels
{
    public class AddRowViewModel
    {
        public FileSettingViewModel FileSetting { get; set; }

        public IEnumerable<string> Row { get; set; }
    }
}
