using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Restaurant.Models;

namespace Restaurant.Controllers
{
    public class HomeController : Controller
    {
        private RestaurantContext _context;
 
        public HomeController(RestaurantContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost("create")]
        public IActionResult Create(Review review)
        {
            if(ModelState.IsValid)
            {
                _context.Add(review);
                _context.SaveChanges();
                return RedirectToAction("Reviews");
            }
            else
            {
                // Oh no!  We need to return a ViewResponse to preserve the ModelState, and the errors it now contains!
                return View("Index");
            }

        }

        [HttpGet("reviews")]
        public IActionResult Reviews()
        {
            List<Review> ReturnedValues = _context.Review.ToList();
            ViewBag.All = ReturnedValues.OrderByDescending(a => a.id);
            // foreach(Review x in ViewBag.All)
            // {
            //     Console.WriteLine("Reviewer: {0}, Restaurant: {1}, Review: {}",x.Reviewer,x.Restaurant,x.Content);
            // }
            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
