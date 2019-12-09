using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TextFileAnalyzer.Services
{
    public interface ITableWriterService
    {
        Task<bool> ReplaceString(string pathFile, string searchString, string replaceString);
    }
}
