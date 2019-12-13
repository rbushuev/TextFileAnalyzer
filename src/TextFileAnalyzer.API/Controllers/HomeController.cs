using Microsoft.AspNetCore.Mvc;

namespace TextFileAnalyzer.API.Controllers
{
    [ApiController]
    [Route("/")]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return Ok("welcome to the home page web api 🤔");
        }
    }
}