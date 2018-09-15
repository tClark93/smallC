using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TheWall
{
    public class Post
    {
        [Key]
        public int id { get; set; }

        public string Content { get; set; }

        public DateTime Created { get; set; }

        [ForeignKey("id")]
        public int Userid { get; set; }

        public List<Comment>Comments { get; set; }

        public User Creator { get; set; }
        public Post()
        {
            Created = DateTime.Now;
            Comments = new List<Comment>();
        }
    }
}