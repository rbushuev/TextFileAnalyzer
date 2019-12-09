using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace TextFileAnalyzer.Services
{
    public class TableWriterService : ITableWriterService
    {
        public async Task AddHeaders(string pathFile, string headers)
        {
            var content = await File.ReadAllTextAsync(pathFile);
            File.WriteAllText(pathFile, headers + Environment.NewLine + content);
        }

        public async Task PushString(string pathFile, string str)
        {
            await File.AppendAllTextAsync(pathFile, Environment.NewLine + str);
        }

        public async Task ReplaceString(string pathFile, string searchString, string replaceString)
        {
            using StreamReader reader = new StreamReader(pathFile);
            string content = await reader.ReadToEndAsync();
            reader.Close();

            content = content.Replace(searchString, replaceString);

            using StreamWriter writer = new StreamWriter(pathFile);
            await writer.WriteAsync(content);
            writer.Close();
        }
    }
}
