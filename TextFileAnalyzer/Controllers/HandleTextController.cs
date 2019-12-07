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
using TextFileAnalyzer.Models;

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
        public async Task<IActionResult> HandleText([FromForm]FileSettingViewModel fsVM)
        {
            var table = new Table();

            try
            {
                string filePath = GetFilePath(fsVM.Name);

                using StreamReader sr = new StreamReader(filePath);

                var line = await sr.ReadLineAsync();

                var separator = fsVM.CellSeparator.GetSeparator();

                var content = line.Split(separator);

                if (fsVM.IsFirstString)
                    table.AddHeaders(content);
                else
                    table.AddCustomHeaders(content.Length);


                int id = 0;
                while ((line = await sr.ReadLineAsync()) != null)
                {
                    content = line.Split(separator);

                    table.AddRowContent(content);
                }

            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

            return Ok(table);
        }

        private string GetFilePath(string nameFile)
        {
            return Path.Combine(_hostingEnvironment.ContentRootPath, @"datasource", $"{nameFile}.txt");
        }
    }
}