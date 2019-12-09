using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TextFileAnalyzer.Models;

namespace TextFileAnalyzer.ViewModels
{
    public class ResponseTableViewModel
    {
        public FileSettings FileSetting { get; set; }

        public Table Table { get; set; } = new Table();

        public ResponseTableViewModel(FileSettings fileSetting)
        {
            FileSetting = fileSetting;
        }
    }
}
