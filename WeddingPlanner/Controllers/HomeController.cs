using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WeddingPlanner.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace WeddingPlanner.Controllers
{
    public class HomeController : Controller
    {
        private MyContext _context;
 
        public HomeController(MyContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            LoginView loginReg = new LoginView()
            {
                regUser = new User(),
                logUser = new Login(),
            };
            if(HttpContext.Session.GetInt32("User") != null)
            {
                return RedirectToAction("Dashboard");
            }
            return View();
        }

        [HttpPost("register")]
        public IActionResult Register(LoginView DataForm)
        {
            User user = DataForm.regUser; 
            User check = _context.User.SingleOrDefault(u => u.Email == user.Email);
            if (check != null)
            {
                ModelState.AddModelError("regUser.Email", "Email already in use");
                return View("Index",DataForm);
            }
            if(ModelState.IsValid)
            {
                PasswordHasher<User> Hasher = new PasswordHasher<User>();
                user.Password = Hasher.HashPassword(user, user.Password);
                _context.Add(user);
                _context.SaveChanges();
                HttpContext.Session.SetInt32("User", user.id);
                return RedirectToAction("Dashboard");
            }
            else
            {
                return View("Index");
            }
        }

        [HttpPost]
        [Route("login")]
        public IActionResult Login(LoginView FormData)
        {
            Login loginUser = FormData.logUser;
            var user = _context.User.SingleOrDefault(u => u.Email == loginUser.Email);
            if(user != null && loginUser.Password != null)
            {
                var Hasher = new PasswordHasher<User>();
                if(0 != Hasher.VerifyHashedPassword(user, user.Password, loginUser.Password))
                {
                    HttpContext.Session.SetInt32("User", user.id);
                    return RedirectToAction("Dashboard");
                }
            }
            ModelState.AddModelError("logUser.Password", "Username and password do not match");
            return View("Index", FormData);
        }

        [HttpGet("dashboard")]
        public IActionResult Dashboard()
        {
            int? id = HttpContext.Session.GetInt32("User");
            if(id == null)
            {
                return RedirectToAction("Index");
            }
            ViewModel view = new ViewModel()
            {
                users = new User(),
                events = new Event(),
                guestlists = new Guestlist()
            };
            User user = _context.User.SingleOrDefault(u => u.id == (int)id);
            List<Event> wedding = _context.Event
                            .Include(w => w.Guests)
                            .ThenInclude(g => g.Guest)
                            .ToList();
            ViewBag.user = user;
            ViewBag.weddings = wedding;
            return View();
        }

        [HttpGet("create")]
        public IActionResult Create()
        {
            int? id = HttpContext.Session.GetInt32("User");
            User user = _context.User.SingleOrDefault(u => u.id == (int)id);
            ViewBag.user = user;
            return View();
        }

        [HttpPost("addWedding")]
        public IActionResult addWedding(Event nuptuals)
        {
            int? id = HttpContext.Session.GetInt32("User");
            User user = _context.User.SingleOrDefault(u => u.id == (int)id);
            if(ModelState.IsValid)
            {
                _context.Event.Add(nuptuals);
                _context.SaveChanges();
                user.Events.Add(nuptuals);
                _context.SaveChanges();
                return RedirectToAction("Dashboard");            
            }
            return View("Create", nuptuals);
        }

        [HttpGet]
        [Route("wedding/{num}")]
        public IActionResult Wedding(int num)
        {
            if(HttpContext.Session.GetInt32("User") == null)
            {
                return RedirectToAction("Index"); 
            }
            
            Event wedding = _context.Event
                .Include(w => w.Guests)
                .ThenInclude(g => g.Guest)
                .SingleOrDefault(w => w.id == num);
            ViewBag.wedding = wedding;
            return View();
        }

        [HttpGet]
        [Route("rsvp/{num}")]
        public IActionResult RSVP(int num)
        {
            if(HttpContext.Session.GetInt32("User") == null)
            {
                return RedirectToAction("Index"); 
            }
            int? id = HttpContext.Session.GetInt32("User");
            User user = _context.User.SingleOrDefault(u => u.id == (int)id);
            Event wedding = _context.Event
                            .Include(w => w.Guests)
                            .ThenInclude(g => g.Guest)
                            .SingleOrDefault(w => w.id == num);
            Guestlist gl = new Guestlist()
            {
                Userid = user.id,
                Eventid = wedding.id,
                Guest = user,
                Wedding = wedding
            };
            _context.Guestlist.Add(gl);
            _context.SaveChanges();
            ViewBag.wedding = wedding;
            return RedirectToAction("Dashboard");
        }

        [HttpGet]
        [Route("cancel/{num}")]
        public IActionResult cancel(int num)
        {
            if(HttpContext.Session.GetInt32("User") == null)
            {
                return RedirectToAction("Index"); 
            }
            int? id = HttpContext.Session.GetInt32("User");
            User user = _context.User.SingleOrDefault(u => u.id == (int)id);
            Event wedding = _context.Event
                            .Include(w => w.Guests)
                            .ThenInclude(g => g.Guest)
                            .SingleOrDefault(w => w.id == num);
            Guestlist guest = _context.Guestlist.Where(a => a.Userid == user.id).Where(b => b.Eventid == wedding.id).SingleOrDefault();
            wedding.Guests.Remove(guest);
            _context.SaveChanges();
            return RedirectToAction("Dashboard");
        }

        [HttpGet]
        [Route("delete/{num}")]
        public IActionResult Delete(int num)
        {
            if(HttpContext.Session.GetInt32("User") == null)
            {
                return RedirectToAction("Index"); 
            }
            Event wedding = _context.Event.SingleOrDefault(w => w.id == (int)num);
            _context.Event.Remove(wedding);
            _context.SaveChanges();
            return RedirectToAction("Dashboard");
        }

        [HttpGet]
        [Route("logout")]
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index");
        }
    }
}
