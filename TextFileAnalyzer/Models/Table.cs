using System.Collections.Generic;

namespace TextFileAnalyzer.Models
{
    public class Table
    {
        public IList<string> Headers { get; private set; } = new List<string>();

        public IList<Row> Rows { get; private set; } = new List<Row>();


        public void AddRowContent(string[] content)
        {
            var row = new Row();
            row.AddContent(content);
            Rows.Add(row);
        }

        public void AddHeaders(string[] headers)
        {
            Headers = headers;
        }

        public void AddCustomHeaders(int countHeaders)
        {
            for (int i = 0; i < countHeaders; i++)
                Headers.Add($"col_{i}");
        }
    }
}
