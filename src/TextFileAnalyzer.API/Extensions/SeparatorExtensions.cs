using System;

using TextFileAnalyzer.API.Models;

namespace TextFileAnalyzer.API
{
    public static class SeparatorExtensions
    {
        public static string GetSeparator(this Separator separator)
        {
            switch (separator.SeparatorEnum)
            {
                case SeparatorEnum.Tab:
                    return "\t";
                case SeparatorEnum.Space:
                    return " ";
                case SeparatorEnum.Semicolon:
                    return ";";
                case SeparatorEnum.Custom:
                    return separator.CustomSeparator;
                default:
                    throw new Exception("что-то не понятное в разделителях");
            }
        }
    }
}
