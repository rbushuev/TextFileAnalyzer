namespace TextFileAnalyzer.API.Models
{
    public class FileSettings
    {
        public string PathFile { get; set; }

        public bool IsHeadersFirst { get; set; }

        public Separator Separator { get; set; } = new Separator();
    }
}
