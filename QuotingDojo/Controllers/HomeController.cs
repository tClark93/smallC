using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using QuotingDojo.Models;
using QuotingDojo.DbConnection;

namespace QuotingDojo.Controllers
{
    public class HomeController : Controller
    {
        private DbConnector cnx = new DbConnector();
        public HomeController()
        {
            DbConnector cnx = new DbConnector();
        }
        public IActionResult Index()
        {
            return View();
        }


        [HttpPost]
        [Route("addquote")]
        public IActionResult AddQuote(string Name, string quote)
        {
            DateTime CurrentTime = DateTime.Now;
            Console.WriteLine(Name);
            Console.WriteLine(quote);
            string query = $"INSERT INTO Quote (content, author, created_at) VALUES ('{quote}', '{Name}', '{CurrentTime.ToString("yyyy-MM-dd HH:mm:ss")}')";
            this.cnx.Execute(query);
            return RedirectToAction("Quotes");
        }

        [HttpGet]
        [Route("quotes")]
        public IActionResult Quotes()
        {
            List<Dictionary<string, object>> AllQuotes = DbConnector.Query("SELECT * FROM Quote");
            ViewBag.AllQuotes = AllQuotes;
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
