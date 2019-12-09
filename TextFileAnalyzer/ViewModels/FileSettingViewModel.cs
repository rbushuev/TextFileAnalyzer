using TextFileAnalyzer.Models;

namespace TextFileAnalyzer.ViewModels
{
    public class FileSettingViewModel
    {
        public string PathFile { get; set; }

        public bool IsHeadersFirst { get; set; }

        public Separator Separator { get; set; } = new Separator();
    }
}
