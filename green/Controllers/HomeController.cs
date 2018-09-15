using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using green.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace green.Controllers
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

        [HttpGet("artist")]
        public IActionResult Artist()
        {
            ViewModel Views = new ViewModel()
            {
                AllArtists = _context.Artist.ToList()
            };
            return View(Views);
        }

        [HttpGet("JoinAsArtist")]
        public IActionResult JoinArtist()
        {
            return View();
        }

        [HttpPost("registerArtist")]
        public IActionResult registerArtist(Artist artist)
        {
            Artist check = _context.Artist.SingleOrDefault(a => a.Email == artist.Email);
            if (check != null)
            {
                ModelState.AddModelError("Email", "Email already in use");
                return View("JoinArtist", artist);
            }
            if(ModelState.IsValid)
            {
                PasswordHasher<Artist> Hasher = new PasswordHasher<Artist>();
                artist.Password = Hasher.HashPassword(artist, artist.Password);
                _context.Add(artist);
                _context.SaveChanges();
                HttpContext.Session.SetInt32("User", artist.id);
                return RedirectToAction("Index");
            }
            else
            {
                return View("JoinArtist");
            }
        }

        [HttpGet("venue")]
        public IActionResult Venue()
        {
            ViewModel Views = new ViewModel()
            {
                AllVenues = _context.Venue.ToList()
            };
            return View(Views);
        }

        [HttpGet("JoinAsVenue")]
        public IActionResult JoinVenue()
        {
            return View();
        }

        [HttpPost("registerVenue")]
        public IActionResult registerVenue(Venue venue)
        {
            Venue check = _context.Venue.SingleOrDefault(v => v.Email == venue.Email);
            if (check != null)
            {
                ModelState.AddModelError("Email", "Email already in use");
                return View("JoinVenue", venue);
            }
            if(ModelState.IsValid)
            {
                PasswordHasher<Venue> Hasher = new PasswordHasher<Venue>();
                venue.Password = Hasher.HashPassword(venue, venue.Password);
                _context.Add(venue);
                _context.SaveChanges();
                HttpContext.Session.SetInt32("User", venue.id);
                return RedirectToAction("Index");
            }
            else
            {
                return View("JoinVenue");
            }
        }

        [HttpGet("join")]
        public IActionResult Join()
        {
            return View();
        }

        [HttpGet("artist/{num}")]
        public IActionResult ArtistID(int num)
        {
            Artist artist = _context.Artist.SingleOrDefault(a =>a.id == num);
            ViewModel Views = new ViewModel()
            {
                Artist = artist,
                // UsersIdeas = _context.Idea
                //         .Where(i => i.Userid == user.id)
                //         .ToList(),
                // LikedIdeas = _context.Like
                //         .Where(l => l.LikedByUser == user)
                //         .ToList()
            };
            return View(Views);
        }

        [HttpGet("venue/{num}")]
        public IActionResult VenueID(int num)
        {
            Venue venue = _context.Venue.SingleOrDefault(v =>v.id == num);
            ViewModel Views = new ViewModel()
            {
                Venue = venue,
                AllArtists = _context.Artist.ToList()
                // UsersIdeas = _context.Idea
                //         .Where(i => i.Userid == user.id)
                //         .ToList(),
                // LikedIdeas = _context.Like
                //         .Where(l => l.LikedByUser == user)
                //         .ToList()
            };
            return View(Views);
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
