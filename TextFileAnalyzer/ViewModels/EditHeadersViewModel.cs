using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TextFileAnalyzer.ViewModels
{
    public class EditHeadersViewModel
    {
        public FileSettingViewModel FileSetting { get; set; }

        public IEnumerable<string> OldHeaders { get; set; }

        public IEnumerable<string> NewHeaders { get; set; }
    }
}
