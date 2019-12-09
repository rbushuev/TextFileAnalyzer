using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TextFileAnalyzer.Extensions;
using TextFileAnalyzer.Services;
using TextFileAnalyzer.ViewModels;

namespace TextFileAnalyzer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddRowController : ControllerBase
    {
        private readonly ITableReaderService _tableReaderService;
        private readonly ITableWriterService _tableWriterService;

        public AddRowController(ITableReaderService tableReaderService, ITableWriterService tableWriterService)
        {
            _tableReaderService = tableReaderService;
            _tableWriterService = tableWriterService;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody]AddRowViewModel request)
        {
            var separator = request.FileSetting.Separator.GetSeparator();
            var pushString = string.Join(separator, request.Row);

            var result = new ResponseTableViewModel(request.FileSetting);

            try
            {
                await _tableWriterService.PushString(request.FileSetting.PathFile, pushString);
                result.Table = await _tableReaderService.Read(request.FileSetting.PathFile, separator, request.FileSetting.IsHeadersFirst);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

            return Ok(result);
        }
    }
}