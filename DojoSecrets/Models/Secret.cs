using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DojoSecrets
{
    public class Secret
    {
        [Key]
        public int id { get; set; }

        [Required(ErrorMessage = "You can't post nothing")]
        [MinLength(10),MaxLength(250)]
        public string Content { get; set; }

        public DateTime Created { get; set; }

        [ForeignKey("id")]
        public int Userid { get; set; }

        public User Author { get; set; }

        public List<Like> Likes { get; set; }

        public Secret()
        {
            Likes = new List<Like>();
            Created = DateTime.Now;
        }
    }
}