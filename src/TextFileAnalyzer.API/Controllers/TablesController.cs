using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

using TextFileAnalyzer.API.Models;
using TextFileAnalyzer.API.Services;
using TextFileAnalyzer.API.ViewModels;

namespace TextFileAnalyzer.API.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class TablesController : ControllerBase
    {
        private readonly ITableReaderService _tableReaderService;
        private readonly ITableWriterService _tableWriterService;

        public TablesController(ITableReaderService tableReaderService, ITableWriterService tableWriterService)
        {
            _tableReaderService = tableReaderService;
            _tableWriterService = tableWriterService;
        }

        [HttpPost]
        public async Task<IActionResult> GetTable([FromForm]FileSettings request)
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

        [HttpPost]
        public async Task<IActionResult> AddItem([FromBody]AddItemViewModel request)
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

        [HttpPatch]
        public async Task<IActionResult> EditItem([FromBody]EditItemViewModel request)
        {
            var separator = request.FileSetting.Separator.GetSeparator();
            var searchString = string.Join(separator, request.OldRow);
            var replaceString = string.Join(separator, request.NewRow);
            var result = new ResponseTableViewModel(request.FileSetting);
            try
            {
                await _tableWriterService.ReplaceString(request.FileSetting.PathFile, searchString, replaceString);
                result.Table = await _tableReaderService.Read(request.FileSetting.PathFile, separator, request.FileSetting.IsHeadersFirst);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> EditHeaders([FromBody]EditHeadersViewModel request)
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