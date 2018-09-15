using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WeddingPlanner
{
    public class Guestlist
    {
        [Key]
        public int id { get; set; }

        [ForeignKey("id")]
        public int Userid { get; set; }

        [ForeignKey("id")]
        public int Eventid { get; set; }

        public User Guest { get; set; }

        public Event Wedding {get; set; }
    }
}