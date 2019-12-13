using System;
using System.IO;
using System.Threading.Tasks;

using TextFileAnalyzer.API.Models;

namespace TextFileAnalyzer.API.Services
{
    public class TableWriterService : ITableWriterService
    {
        public async Task<FileSettings> AddHeaders(FileSettings fileSettings, string headers)
        {
            var content = await File.ReadAllTextAsync(fileSettings.PathFile);
            await File.WriteAllTextAsync(fileSettings.PathFile, headers + Environment.NewLine + content);
            fileSettings.IsHeadersFirst = true;
            return fileSettings;
        }

        public async Task PushString(string pathFile, string str)
        {
            await File.AppendAllTextAsync(pathFile, Environment.NewLine + str);
        }

        public async Task ReplaceString(string pathFile, string searchString, string replaceString)
        {
            string content = await File.ReadAllTextAsync(pathFile);

            await File.WriteAllTextAsync(pathFile, content.Replace(searchString, replaceString));
        }
    }
}
