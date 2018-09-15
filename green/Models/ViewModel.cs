using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace green.Models
{
    public class ViewModel
    {
        public Artist Artist { get; set; }
        public Venue Venue { get; set; }
        public List<Show> Gigs { get; set; }
        public List<Show> Entertainment { get; set; }
        public List<Artist> AllArtists { get; set; }
        public List<Venue> AllVenues { get; set; }
    }
}