using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BankAccounts.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace BankAccounts.Controllers
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
            return View();
        }

        [HttpGet]
        [Route("login")]
        public IActionResult Login()
        {
            return View();
        }

        [HttpGet]
        [Route("account/{num}")]
        public IActionResult Account(int num)
        {
            if(HttpContext.Session.GetInt32("User") == null)
            {
                return RedirectToAction("Index"); 
            }
            if(HttpContext.Session.GetInt32("User") != num)
            {
                int? x = HttpContext.Session.GetInt32("User");
                return RedirectToAction("account", new{num=x});
            }
            int? id = HttpContext.Session.GetInt32("User");
            List<Account> Accounts = _context.Account.Where(account => account.User_id == (int)num).OrderByDescending(account => account.Date).ToList();
            User user = _context.User.SingleOrDefault(u => u.id == num);
            ViewBag.User = user;
            ViewBag.Accounts = Accounts;
            return View();
        }

        [HttpPost("register")]
        public IActionResult Register(User user)
        {
            if(ModelState.IsValid)
            {
                PasswordHasher<User> Hasher = new PasswordHasher<User>();
                user.Password = Hasher.HashPassword(user, user.Password);
                _context.Add(user);
                _context.SaveChanges();
                HttpContext.Session.SetInt32("User", user.id);
                return RedirectToAction("account", new{num=user.id});
            }
            else
            {
                return View("Index");
            }

        }

        [HttpPost]
        [Route("loginuser")]
        public IActionResult Login(User userLog)
        {
            var user = _context.User.SingleOrDefault(u => u.Email == userLog.Email);
            if(user != null && userLog.Password != null)
            {
                var Hasher = new PasswordHasher<User>();
                if(0 != Hasher.VerifyHashedPassword(user, user.Password, userLog.Password))
                {
                    HttpContext.Session.SetInt32("User", user.id);
                    return RedirectToAction("account", new{num=user.id});
                }
            }
            return View("Login");
        }

        [HttpPost]
        [Route("activity")]
        public IActionResult Activity(Account account)
        {
            int? id = HttpContext.Session.GetInt32("User");
            List<Account> Accounts = _context.Account.Where(a => a.User_id == (int)id).OrderByDescending(a => account.Date).ToList();
            float sum = (int)Accounts.Sum(t => t.Amount);
            DateTime CurrentTime = DateTime.Now;
            CurrentTime.ToString("yyyy-MM-dd HH:mm:ss");
            if(sum < -account.Amount && account.Amount < 0)
            {
                Account alteredTransaction = new Account(){
                Amount = -sum,
                User_id = (int)id,
                Date = CurrentTime
                };
                _context.Account.Add(alteredTransaction);
                _context.SaveChanges();

                return RedirectToAction("account", new{num=id});
            }
            Account newTransaction = new Account(){
                Amount = account.Amount,
                User_id = (int)id,
                Date = CurrentTime
            };
            _context.Account.Add(newTransaction);
            _context.SaveChanges();
            return RedirectToAction("account", new{num=id});
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
