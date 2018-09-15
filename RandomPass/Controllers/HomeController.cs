using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RandomPass.Models;
using Microsoft.AspNetCore.Http;

namespace RandomPass.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            if(HttpContext.Session.GetInt32("count") == null)
            {
                HttpContext.Session.SetInt32("count",1);
            }
            else
            {
                int? IntVariable = HttpContext.Session.GetInt32("count");
                int IntVar = (int)IntVariable;
                HttpContext.Session.SetInt32("count",IntVar+1);
            }
            ViewBag.Val = HttpContext.Session.GetInt32("count");
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
