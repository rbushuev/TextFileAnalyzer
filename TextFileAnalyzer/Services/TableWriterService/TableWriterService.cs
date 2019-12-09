using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace TextFileAnalyzer.Services
{
    public class TableWriterService : ITableWriterService
    {
        private bool _success;

        public async Task<bool> ReplaceString(string pathFile, string searchString, string replaceString)
        {
            try
            {
                using StreamReader reader = new StreamReader(pathFile);
                string content = await reader.ReadToEndAsync();
                reader.Close();

                content = content.Replace(searchString, replaceString);

                using StreamWriter writer = new StreamWriter(pathFile);
                await writer.WriteAsync(content);
                writer.Close();

                _success = true;
            }
            catch
            {
                _success = false;
                return _success;
            }

            return _success;
        }
    }
}
