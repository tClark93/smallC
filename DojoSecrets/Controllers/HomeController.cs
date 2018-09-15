using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DojoSecrets.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace DojoSecrets.Controllers
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
                return RedirectToAction("Secrets");
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
                return RedirectToAction("Secrets");
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
                    return RedirectToAction("Secrets");
                }
            }
            ModelState.AddModelError("logUser.Password", "Username and password do not match");
            return View("Index", FormData);
        }

        [HttpGet("secrets")]
        public IActionResult Secrets()
        {
            int? id = HttpContext.Session.GetInt32("User");
            if(id == null)
            {
                return RedirectToAction("Index");
            }
            User user = _context.User.SingleOrDefault(u => u.id == (int)id);
            List<Secret> secrets = _context.Secret
                            .Include(l => l.Likes)
                            .ThenInclude(u => u.LikedBy)
                            .ToList();
            ViewBag.user = user;
            ViewBag.secrets = secrets.OrderByDescending(x => x.Created);
            return View();
        }

        [HttpGet("popular")]
          public IActionResult Popular()
        {
            int? id = HttpContext.Session.GetInt32("User");
            if(id == null)
            {
                return RedirectToAction("Index");
            }
            User user = _context.User.SingleOrDefault(u => u.id == (int)id);
            List<Secret> secrets = _context.Secret
                            .Include(l => l.Likes)
                            .ThenInclude(u => u.LikedBy)
                            .ToList();
            ViewBag.user = user;
            ViewBag.secrets = secrets.OrderByDescending(x => x.Likes.Count);
            return View();
        }

        [HttpPost("share")]
        public IActionResult Share(Secret secret)
        {
            int? id = HttpContext.Session.GetInt32("User");
            User user = _context.User.SingleOrDefault(u => u.id == (int)id);
            if(ModelState.IsValid)
            {
                secret.Userid = (int)id;
                secret.Author = user;
                _context.Secret.Add(secret);
                _context.SaveChanges();
                user.Secrets.Add(secret);
                return RedirectToAction("Secrets");            
            }
            List<Secret> secrets = _context.Secret
                            .Include(l => l.Likes)
                            .ThenInclude(u => u.LikedBy)
                            .ToList();
            ViewBag.secrets = secrets.OrderByDescending(x => x.Created);
            ViewBag.user = user;
            return View("Secrets", secret);
        }

        [HttpGet]
        [Route("like/{num}")]
        public IActionResult Like(int num)
        {
            int? id = HttpContext.Session.GetInt32("User");
            User user = _context.User.SingleOrDefault(u => u.id == (int)id);
            Secret secret = _context.Secret.SingleOrDefault(s => s.id == (int)num);
            Like like = new Like()
            {
                Userid = user.id,
                Secretid = secret.id,
                LikedBy = user,
                LikedSecret = secret
            };
            _context.Like.Add(like);
            _context.SaveChanges();
            return RedirectToAction("Secrets");
        }

        [HttpGet]
        [Route("delete/{num}")]
        public IActionResult Delete(int num)
        {
            if(HttpContext.Session.GetInt32("User") == null)
            {
                return RedirectToAction("Index"); 
            }
            Secret secret = _context.Secret.SingleOrDefault(s => s.id == (int)num);
            _context.Secret.Remove(secret);
            _context.SaveChanges();
            return RedirectToAction("Secrets");
        }
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
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
