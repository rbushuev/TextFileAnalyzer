using System.ComponentModel.DataAnnotations;
using TextFileAnalyzer.Models;

namespace TextFileAnalyzer.ViewModels
{
    public class FileSettingViewModel
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string PathFile { get; set; }

        [Required]
        public bool IsFirstString { get; set; }

        [Required]
        public Separator CellSeparator { get; set; } = new Separator();
    }
}
