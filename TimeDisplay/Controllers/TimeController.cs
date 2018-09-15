using Microsoft.AspNetCore.Mvc;
namespace TimeDisplay
{
    public class TimeController : Controller
    {
        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            return View();
        }
    }
}