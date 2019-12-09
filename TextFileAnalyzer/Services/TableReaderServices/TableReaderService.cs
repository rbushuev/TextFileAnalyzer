using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using TextFileAnalyzer.Models;

namespace TextFileAnalyzer.Services
{
    public class TableReaderService : ITableReaderService
    {
        public async Task<Table> Read(string pathFile, string separator, bool isHeadersFirst)
        {
            var table = new Table();

            using StreamReader reader = new StreamReader(pathFile);

            var line = await reader.ReadLineAsync();

            var firstString = line.Split(separator);

            if (isHeadersFirst)
                table.AddHeaders(firstString);
            else
            {
                table.AddCustomHeaders(firstString.Length);
                table.AddRowContent(firstString);
            }

            while ((line = await reader.ReadLineAsync()) != null)
                table.AddRowContent(line.Split(separator));

            return table;
        }
    }
}
