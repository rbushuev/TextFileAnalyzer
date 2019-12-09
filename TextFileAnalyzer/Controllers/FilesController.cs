using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TextFileAnalyzer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilesController : ControllerBase
    {
        [HttpPost]
        public IActionResult Post(string fileExtension)
        {
            var result = new List<Models.File>();

            string catalog = Path.Combine(Directory.GetCurrentDirectory(), @"datasource");

            FileInfo[] fileInfos = new DirectoryInfo(catalog).GetFiles($".{fileExtension}");

            foreach (var e in fileInfos)
            {
                var temp = new Models.File()
                {
                    Name = Path.GetFileNameWithoutExtension(e.Name),
                    FullPath = e.FullName,
                    FileSize = Math.Round((double)e.Length / 1000, 3)
                };
                result.Add(temp);
            }

            return Ok(result);
        }
    }
}