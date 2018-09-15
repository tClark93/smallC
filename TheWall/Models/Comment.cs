using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TheWall
{
    public class Comment
    {
        [Key]
        public int id { get; set; }

        public string Content { get; set; }

        public DateTime Created { get; set; }

        [ForeignKey("id")]
        public int Postid { get; set; }
        [ForeignKey("id")]
        public int Userid { get; set; }

        public User Commentor { get; set; }

        public Comment()
        {
            Created = DateTime.Now;
        }
    }
}