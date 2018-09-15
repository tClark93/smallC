using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DojoSecrets
{
    public class Like
    {
        [Key]
        public int id { get; set; }

        [ForeignKey("id")]
        public int Userid { get; set; }

        [ForeignKey("id")]
        public int Secretid { get; set; }

        public User LikedBy { get; set; }

        public Secret LikedSecret {get; set; }
    }
}