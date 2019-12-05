using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TextFileAnalyzer.Extensions;
using TextFileAnalyzer.ViewModels;

namespace TextFileAnalyzer.Controllers
{
    public class HomeController : Controller
    {
        private readonly IWebHostEnvironment _hostingEnvironment;

        public HomeController(IWebHostEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
        }

        public IActionResult Index()
        {
            //string[] allFoundFiles = Directory.GetFiles(projectRootPath, $"{fileName}.txt", SearchOption.AllDirectories);
            return View();
        }

        public async Task<IActionResult> HandleText(FileSettingViewModel fileSettingViewModel)
        {

            List<List<string>> rows = new List<List<string>>();

            try
            {
                string datasourcePath = _hostingEnvironment.ContentRootPath + "\\datasource";
                string filePath = datasourcePath + $"\\{fileSettingViewModel.Name}.txt";

                using StreamReader sr = new StreamReader(filePath);

                string line;
                while ((line = await sr.ReadLineAsync()) != null)
                {
                    rows.Add(line.Split(fileSettingViewModel.CellSeparator.GetSeparator()).ToList());
                }

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

            return View();
        }
        
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
