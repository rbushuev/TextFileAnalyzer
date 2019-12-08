using TextFileAnalyzer.Models;

namespace TextFileAnalyzer.ViewModels
{
    public class FileSettingViewModel
    {
        public string PathFile { get; set; }

        public bool IsFirstString { get; set; }

        public Separator CellSeparator { get; set; } = new Separator();
    }
}
