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
    public class EditHeadersController : ControllerBase
    {
        private readonly ITableReaderService _tableReaderService;
        private readonly ITableWriterService _tableWriterService;

        public EditHeadersController(ITableReaderService tableReaderService, ITableWriterService tableWriterService)
        {
            _tableReaderService = tableReaderService;
            _tableWriterService = tableWriterService;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody]EditHeadersViewModel request)
        {
            var separator = request.FileSetting.Separator.GetSeparator();
            var oldHeaders = string.Join(separator, request.OldHeaders);
            var newHeaders = string.Join(separator, request.NewHeaders);

            var result = new ResponseTableViewModel(request.FileSetting);
            try
            {
                if (request.FileSetting.IsHeadersFirst)
                {
                    await _tableWriterService.ReplaceString(request.FileSetting.PathFile, oldHeaders, newHeaders);
                }
                else
                {
                    result.FileSetting = await _tableWriterService.AddHeaders(request.FileSetting, newHeaders);
                }

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