using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace green.Models
{
    [Table("Show")]
    public class Show
    {
        
        [Key]
        public int id { get; set; }

        [ForeignKey("id")]
        public int Venueid { get; set; }

        [ForeignKey("id")]
        public int Artistid { get; set; }

        [Required]
        public DateTime Start { get; set; }

        [Required]
        public DateTime End { get; set; }

        public Venue Location { get; set; }

        public Artist Performer {get; set; }
    }
}