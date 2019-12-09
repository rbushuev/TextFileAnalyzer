using System.Threading.Tasks;

namespace TextFileAnalyzer.Services
{
    public interface ITableWriterService
    {
        Task PushString(string pathFile, string str);
        Task ReplaceString(string pathFile, string searchString, string replaceString);
    }
}
