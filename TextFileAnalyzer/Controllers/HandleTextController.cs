using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TextFileAnalyzer.ViewModels;
using TextFileAnalyzer.Extensions;

namespace TextFileAnalyzer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HandleTextController : ControllerBase
    {
        private readonly IWebHostEnvironment _hostingEnvironment;

        public HandleTextController(IWebHostEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
        }

        [HttpPost]
        public async Task<IActionResult> HandleText([FromForm]FileSettingViewModel fileSettingViewModel)
        {
            var rows = new List<List<string>>();

            try
            {
                string datasourcePath = _hostingEnvironment.ContentRootPath + "\\datasource";
                string filePath = datasourcePath + $"\\{fileSettingViewModel.Name}.txt";

                using StreamReader sr = new StreamReader(filePath);

                string line;
                while ((line = await sr.ReadLineAsync()) != null)
                {
                    if (fileSettingViewModel.IsFirstString)
                        rows.Add(line.Split(fileSettingViewModel.CellSeparator.GetSeparator()).ToList());
                }

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

            return Ok(rows);
        }
    }
}