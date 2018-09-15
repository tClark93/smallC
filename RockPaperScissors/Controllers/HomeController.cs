using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using RockPaperScissors.Models;

namespace RockPaperScissors.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            if(HttpContext.Session.GetInt32("win") == null)
            {
                HttpContext.Session.SetInt32("win",0);
            }
            if(HttpContext.Session.GetInt32("tie") == null)
            {
                HttpContext.Session.SetInt32("tie",0);
            }
            if(HttpContext.Session.GetInt32("lose") == null)
            {
                HttpContext.Session.SetInt32("lose",0);
            }
            if(HttpContext.Session.GetString("message") == null)
            {
                HttpContext.Session.SetString("message","welcome");
            }
            ViewBag.Message = HttpContext.Session.GetString("message");
            ViewBag.Lose = HttpContext.Session.GetInt32("lose");
            ViewBag.Tie = HttpContext.Session.GetInt32("tie");
            ViewBag.Win = HttpContext.Session.GetInt32("win");
            return View();
            
        }
      
        [HttpGet("rock")]
        public IActionResult Rock()
        {
            Random rand = new Random();
            int chance = rand.Next(1,4);
            if(chance == 1)
            {
                HttpContext.Session.SetInt32("win",((int)HttpContext.Session.GetInt32("win")+1));
                HttpContext.Session.SetString("message","You Won! The computer selected scissors.");

            }
            if(chance == 2)
            {
                HttpContext.Session.SetInt32("lose",((int)HttpContext.Session.GetInt32("lose")+1));
                HttpContext.Session.SetString("message","You Lost! The computer selected paper.");
            }
            if(chance == 3)
            {
                HttpContext.Session.SetInt32("tie",((int)HttpContext.Session.GetInt32("tie")+1));
                HttpContext.Session.SetString("message","You Tied! The computer selected rock.");
            }
            return RedirectToAction("Index");
        }
        [HttpGet("paper")]
        public IActionResult Paper()
        {
            Random rand = new Random();
            int chance = rand.Next(1,4);
            if(chance == 1)
            {
                HttpContext.Session.SetInt32("win",((int)HttpContext.Session.GetInt32("win")+1));
                HttpContext.Session.SetString("message","You Won! The computer selected rock.");

            }
            if(chance == 2)
            {
                HttpContext.Session.SetInt32("lose",((int)HttpContext.Session.GetInt32("lose")+1));
                HttpContext.Session.SetString("message","You Lost! The computer selected scissors.");
            }
            if(chance == 3)
            {
                HttpContext.Session.SetInt32("tie",((int)HttpContext.Session.GetInt32("tie")+1));
                HttpContext.Session.SetString("message","You Tied! The computer selected paper.");
            }
            return RedirectToAction("Index");
        }
        [HttpGet("scissors")]
        public IActionResult Scissors()
        {
            Random rand = new Random();
            int chance = rand.Next(1,4);
            if(chance == 1)
            {
                HttpContext.Session.SetInt32("win",((int)HttpContext.Session.GetInt32("win")+1));
                HttpContext.Session.SetString("message","You Won! The computer selected paper.");

            }
            if(chance == 2)
            {
                HttpContext.Session.SetInt32("lose",((int)HttpContext.Session.GetInt32("lose")+1));
                HttpContext.Session.SetString("message","You Lost! The computer selected rock.");
            }
            if(chance == 3)
            {
                HttpContext.Session.SetInt32("tie",((int)HttpContext.Session.GetInt32("tie")+1));
                HttpContext.Session.SetString("message","You Tied! The computer selected scissors.");
            }
            return RedirectToAction("Index");
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
