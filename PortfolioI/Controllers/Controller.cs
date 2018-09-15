using Microsoft.AspNetCore.Mvc;
namespace PortfolioI.Controllers
{
    public class ProjectsController : Controller
    {
        [HttpGet]
        [Route("projects")]
        public string Projects()
        {
            return "These are my projects!";
        }
    }
    public class ContactController : Controller
    {
        [HttpGet]
        [Route("contact")]
        public string Contact()
        {
            return "This is my contact!";
        }
    }
}