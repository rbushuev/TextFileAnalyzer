using System;
using System.Collections.Generic;
using System.IO;
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
    [Produces("application/json")]
    [ApiController]
    public class EditFileController : ControllerBase
    {
        private readonly ITableReaderService _tableReaderService;
        private readonly ITableWriterService _tableWriterService;

        public EditFileController(ITableReaderService tableReaderService, ITableWriterService tableWriterService)
        {
            _tableReaderService = tableReaderService;
            _tableWriterService = tableWriterService;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody]EditFileViewModel request)
        {
            var separator = request.FileSetting.Separator.GetSeparator();
            var searchString = string.Join(separator, request.OldRow);
            var replaceString = string.Join(separator, request.NewRow);

            var result = new ResponseTableViewModel(request.FileSetting);

            try
            {
                bool isWriteSuccess = await _tableWriterService.ReplaceString(request.FileSetting.PathFile, searchString, replaceString);
                if (isWriteSuccess)
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