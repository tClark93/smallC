using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace RapperAPI.Controllers {

    
    public class ArtistController : Controller {

        private List<Artist> allArtists;

        public ArtistController() {
            allArtists = JsonToFile<Artist>.ReadJson();
        }

        //This method is shown to the user navigating to the default API domain name
        //It just display some basic information on how this API functions
        [Route("")]
        [HttpGet]
        public string Index() {
            //String describing the API functionality
            string instructions = "Welcome to the Music API~~\n========================\n";
            instructions += "    Use the route /artists/ to get artist info.\n";
            instructions += "    End-points:\n";
            instructions += "       *Name/{string}\n";
            instructions += "       *RealName/{string}\n";
            instructions += "       *Hometown/{string}\n";
            instructions += "       *GroupId/{int}\n\n";
            instructions += "    Use the route /groups/ to get group info.\n";
            instructions += "    End-points:\n";
            instructions += "       *Name/{string}\n";
            instructions += "       *GroupId/{int}\n";
            instructions += "       *ListArtists=?(true/false)\n";
            return instructions;
        }
        // 1.) Create a route for /artists that returns all artists as JSON
        [HttpGet("artists")]
        public JsonResult Artists()
        {
            return Json(allArtists);  
        }

        // 2.) Create a route /artists/name/{name} that returns all artists that match the provided name(RealName)
        [HttpGet("artists/{name}")]
        public JsonResult ArtistName(string name)
        {
            IEnumerable<Artist> findName = from artist in allArtists.Where(artist => artist.ArtistName.Contains(name))
            select artist;
            return Json(findName);
        }
        // 3.) Create a route /artists/realname/{name} that returns all artists who real names match the provided name
        [HttpGet("artists/realname/{name}")]
        public JsonResult RealName(string name)
        {
            IEnumerable<Artist> findName = from artist in allArtists.Where(artist => artist.RealName.Contains(name))
            select artist;
            return Json(findName);
        }
        // 4.) Create a route /artists/hometown/{town} that returns all artists who are from the provided town
        [HttpGet("artists/hometown/{town}")]
        public JsonResult Hometown(string town)
        {
            IEnumerable<Artist> findTown = from artist in allArtists.Where(artist => artist.Hometown == town)
            select artist;
            return Json(findTown);
        }
        // 5.) Create a route /artists/groupid/{id} that returns all artists who have a GroupId that matches id
        [HttpGet("artists/groupid/{id}")]
        public JsonResult Hometown(int id)
        {
            IEnumerable<Artist> findGroup = from artist in allArtists.Where(artist => artist.GroupId == id)
            select artist;
            return Json(findGroup);
        }
        
    }
    // Somewhere in your namespace, outside other classes
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