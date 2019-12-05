using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TextFileAnalyzer.Models
{
    public enum SeparatorEnum
    {
        [Display(Name = "Знак табуляции")]
        Tab,

        [Display(Name = "Пробел")]
        Space,

        [Display(Name = "Точка с запятой")]
        Semicolon,

        [Display(Name = "Другой")]
        Custom
    }

    public class Separator
    {
        public SeparatorEnum SeparatorEnum { get; set; }

        public string CustomSeparator { get; set; }
    }
}
