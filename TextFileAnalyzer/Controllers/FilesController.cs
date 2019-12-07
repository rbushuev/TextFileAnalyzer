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
        [HttpGet]
        public IActionResult Get()
        {
            var catalog = Path.Combine(Directory.GetCurrentDirectory(), @"datasource");
            string[] allFoundFiles = Directory.GetFiles(catalog, $"*.txt", SearchOption.AllDirectories);
            return Ok(allFoundFiles);
        }
    }
}