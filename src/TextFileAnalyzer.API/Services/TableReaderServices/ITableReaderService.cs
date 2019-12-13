using System.Threading.Tasks;

using TextFileAnalyzer.API.Models;

namespace TextFileAnalyzer.API.Services
{
    public interface ITableReaderService
    {
        Task<Table> Read(string pathFile, string separator, bool isFirstString);
    }
}
