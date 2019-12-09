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
using TextFileAnalyzer.Services;

namespace TextFileAnalyzer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HandleTextController : ControllerBase
    {
        private readonly ITableReaderService _tableReaderService;

        public HandleTextController(ITableReaderService tableReaderService)
        {
            _tableReaderService = tableReaderService;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromForm]FileSettingViewModel request)
        {
            var result = new ResponseTableViewModel(request);

            var separator = request.Separator.GetSeparator();

            try
            {
                result.Table = await _tableReaderService.Read(request.PathFile, separator, request.IsHeadersFirst);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

            return Ok(result);
        }
    }
}