using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.AspNetCore.Mvc;
using TextFileAnalyzer.Models;

namespace TextFileAnalyzer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilesController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            var response = new List<FileProperty>();
            string catalog = Path.Combine(Directory.GetCurrentDirectory(), @"datasource");
            FileInfo[] fileInfos = new DirectoryInfo(catalog).GetFiles($"*.txt");

            foreach (var e in fileInfos)
            {
                var temp = new FileProperty()
                {
                    Name = Path.GetFileNameWithoutExtension(e.Name),
                    FullPath = e.FullName,
                    FileSize = Math.Round((double)e.Length / 1000, 3)
                };
                response.Add(temp);
            }
            return Ok(response);
        }
    }
}