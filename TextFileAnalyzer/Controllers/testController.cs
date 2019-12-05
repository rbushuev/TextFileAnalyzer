using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TextFileAnalyzer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class testController : ControllerBase
    {
        [HttpGet]
        public string Get()
        {
            return "test";
        }
        [HttpPost]
        public void Post([FromBody]string value)
        {

        }
    }
}