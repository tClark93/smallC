using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
namespace DojoSurvey
{
    public class SurveyController : Controller
    {
        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        [Route("Created")]
        public IActionResult Created()
        {
            return View();
        }
        [HttpPost]
        [Route("method")]
        public IActionResult method(string name, string dojo, string favorite_language, string comments)
        {
            @ViewBag.Name = name;
            @ViewBag.Dojo = dojo;
            @ViewBag.Favorite_Language = favorite_language;
            @ViewBag.Comments = comments;
            return View("Created");
        }
    }
}