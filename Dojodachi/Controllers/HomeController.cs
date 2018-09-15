using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Dojodachi.Models;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Http;

namespace Dojodachi.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            if(HttpContext.Session.GetObjectFromJson<Dachi>("DachiInfo") == null)
            {
                Dachi dachi = new Dachi();
                HttpContext.Session.SetObjectAsJson("DachiInfo", dachi);
            }
            ViewBag.DachiInfo = HttpContext.Session.GetObjectFromJson<Dachi>("DachiInfo");
            if(ViewBag.DachiInfo.Fullness > 99 && ViewBag.DachiInfo.Happiness > 99 && ViewBag.DachiInfo.Energy > 99)
            {
                ViewBag.DachiInfo.Message = "You won!  Dachi broke from his caccoon and flew away!";
            }
            if(ViewBag.DachiInfo.Fullness <= 0 || ViewBag.DachiInfo.Happiness <= 0)
            {
                ViewBag.DachiInfo.Message = "You killed Dachi you fucking asshole!";
            }
            TempData["message"] = ViewBag.DachiInfo.Message;
            return View();
        }
        // feed
        [HttpGet("feed")]
        public IActionResult FeedDachi()
        {
            Dachi DachiInfoUp = HttpContext.Session.GetObjectFromJson<Dachi>("DachiInfo");
            if(DachiInfoUp.Meals > 0)
            {
                DachiInfoUp.Feed();
            } 
            else 
            {
                DachiInfoUp.Message = "You have no food to give Dachi";
            }
            HttpContext.Session.SetObjectAsJson("DachiInfo",DachiInfoUp);
            return RedirectToAction("Index");
        }
        // play
        [HttpGet("play")]
        public IActionResult PlayWith()
        {
            Dachi DachiInfoUp = HttpContext.Session.GetObjectFromJson<Dachi>("DachiInfo");
            if(DachiInfoUp.Energy > 4)
            {
                DachiInfoUp.Play();
            } 
            else 
            {
                DachiInfoUp.Message = "Dachi doesn't have the energy to play (he's almost dead).";
            }
            HttpContext.Session.SetObjectAsJson("DachiInfo",DachiInfoUp);
            return RedirectToAction("Index");
        }
        // work
        [HttpGet("Work")]
        public IActionResult Slave()
        {
            Dachi DachiInfoUp = HttpContext.Session.GetObjectFromJson<Dachi>("DachiInfo");
            if(DachiInfoUp.Energy > 4)
            {
                DachiInfoUp.Work();
            } 
            else 
            {
                DachiInfoUp.Message = "Dachi doesn't have the energy to work (he's almost dead).";
            }
            HttpContext.Session.SetObjectAsJson("DachiInfo",DachiInfoUp);
            return RedirectToAction("Index");
        }
        // sleep
        [HttpGet("sleep")]
        public IActionResult Nap()
        {
            Dachi DachiInfoUp = HttpContext.Session.GetObjectFromJson<Dachi>("DachiInfo");
            DachiInfoUp.Sleep();
            HttpContext.Session.SetObjectAsJson("DachiInfo",DachiInfoUp);
            return RedirectToAction("Index");
        }
        [HttpGet("reset")]
        public IActionResult Reset()
        {
            HttpContext.Session.Clear();
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
    public static class SessionExtensions
    {
            // We can call ".SetObjectAsJson" just like our other session set methods, by passing a key and a value
        public static void SetObjectAsJson(this ISession session, string key, object value)
        {
            // This helper function simply serializes theobject to JSON and stores it as a string in session
            session.SetString(key, JsonConvert.SerializeObject(value));
        }
            // generic type T is a stand-in indicating that we need to specify the type on retrieval
        public static T GetObjectFromJson<T>(this ISession session, string key)
        {
            string value = session.GetString(key);
                // Upon retrieval the object is deserialized based on the type we specified
            return value == null ? default(T) : JsonConvert.DeserializeObject<T>(value);
        }
    }
}
