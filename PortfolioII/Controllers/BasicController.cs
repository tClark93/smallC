using Microsoft.AspNetCore.Mvc;
namespace PortfolioII
{
    public class BasicController : Controller
    {
        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            return View("Index");
        }
        [HttpGet]
        [Route("projects")]
        public IActionResult Projects()
        {
            return View("Projects");
        }
        [HttpGet]
        [Route("contact")]
        public IActionResult Contact()
        {
            return View("Contact");
        }
    }
}