using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TheWall.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace TheWall.Controllers
{
    public class HomeController : Controller
    {
        private MyContext _context;
 
        public HomeController(MyContext context)
        {
            _context = context;
        }

        [HttpGet("")]

        public IActionResult Index()
        {
            return View();
        }
        
        [HttpGet("login")]

        public IActionResult Login()
        {
            return View();
        }

        [HttpGet("wall")]
        public IActionResult Wall()
        {
            if(HttpContext.Session.GetInt32("User") == null)
            {
                return RedirectToAction("Index");
            }
            ViewModel Views = new ViewModel()
            {
                Users = new User(),
                Posts = new Post(),
                Comments = new Comment()
            };
            int? id = HttpContext.Session.GetInt32("User");
            User user = _context.User.SingleOrDefault(u => u.id == (int)id);
            List<Post> allPosts = _context.Post.Include(p => p.Creator).Include(p => p.Comments).ToList();
            ViewBag.User = user;
            ViewBag.Posts = allPosts.OrderByDescending(a => a.Created);
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
                return RedirectToAction("Wall");
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
                    return RedirectToAction("Wall");
                }
            }
            return View("Login");
        }

        [HttpPost("addPost")]
        public IActionResult addPost(Post post)
        {
            System.Console.WriteLine(post.Content);
            int? id = HttpContext.Session.GetInt32("User");
            User user = _context.User.SingleOrDefault(u => u.id == id);
            Post newPost = new Post{
                Creator = user,
                Content = post.Content,
                Userid = (int)id,
            };
            _context.Post.Add(newPost);
            _context.SaveChanges();
            user.Posts.Add(newPost);
            _context.SaveChanges();
            return RedirectToAction("Wall");
        }

        [HttpPost("addComment")]
        public IActionResult addComment(Comment comment)
        {
            int? id = HttpContext.Session.GetInt32("User");
            User user = _context.User.SingleOrDefault(u => u.id == id);
            Post post = _context.Post.SingleOrDefault(p => p.id == comment.Postid);
            Comment newComment = new Comment{
                Commentor = user,
                Content = comment.Content,
                Postid = comment.Postid,
            };
            _context.Comment.Add(newComment);
            _context.SaveChanges();
            post.Comments.Add(newComment);
            _context.SaveChanges();
            return RedirectToAction("Wall");
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
