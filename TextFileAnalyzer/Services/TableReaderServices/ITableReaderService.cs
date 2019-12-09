using System.Threading.Tasks;
using TextFileAnalyzer.Models;

namespace TextFileAnalyzer.Services
{
    public interface ITableReaderService
    {
        Task<Table> Read(string pathFile, string separator, bool isFirstString);
    }
}
