using Microsoft.AspNetCore.Mvc;
namespace RazorFun
{
    public class RazorController : Controller
    {
        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            return View("Index");
        }
    }
}