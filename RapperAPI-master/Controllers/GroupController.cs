using System;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace RapperAPI.Controllers {
    public class GroupController : Controller {
        List<Group> allGroups {get; set;}
        List<Artist> allArtists {get; set;}
        public GroupController() {
            allGroups = JsonToFile<Group>.ReadJson();
            allArtists = JsonToFile<Artist>.ReadJson();
        }
        // 1.) Create a route /groups that returns all groups as JSON

        [HttpGet("groups")]
        public JsonResult Groups()
        {
            return Json(allGroups);  
        }

        // 2.) Create a route /groups/name/{name} that returns all groups that match the provided name

        [HttpGet("groups/name/{name}")]
        public JsonResult GroupName(string name)
        {
            IEnumerable<Group> findName = from Group in allGroups.Where(Group => Group.GroupName.Contains(name))
            select Group;
            return Json(findName);
        }

        // 3.) Create a route /groups/id/{id} that returns all groups with the provided Id value
        [HttpGet("groups/id/{id}/{nnn}")]
        public JsonResult GroupName(int id, bool nnn = false)
        {
            IEnumerable<Group> findGroupID = from Group in allGroups.Where(Group => Group.Id == id)
            select Group;
            // if(nnn == true)
            // {
            //     var answer = 
            //     from Group in allGroups.Where(Group => Group.Id == id)
            //     join Artist in allArtists on Group.Id equals Artist.GroupId
            //     select Artist;
            //     List<Artist> findGroupID[Members] = new List<Artist>();
            //     answer.ToList();
            //     foreach(Artist artist in answer)
            //     {
            //         findGroupID.Members.Insert(artist);
            //     }
            //     return Json(answer);
            // }
            return Json(findGroupID);
        }
        
        // 4.) (Optional) Add an extra boolean parameter to the group routes called displayArtists that will include members for all Group JSON responses
        [HttpGet("groups/id/{id}")]
        [HttpGet("groups/id/{id}/{boolean}")]
        public JsonResult Demo(int id, bool boolean = false)
        {
            if(boolean == false)
            {
                return Json(allGroups);
            }
            else
            {
                // var query = 
                // (from g in allGroups
                // from a in allArtists
                // where g.Id == a.GroupId
                // join )
                var answer = allGroups.Join(allArtists, g => g.Id, a => a.GroupId, (g,a) => {g.Members.Add(a); return g;}).ToList().Distinct();
                return Json(answer);
            }
        }
    }
}