using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WeddingPlanner
{
    public class Event
    {
        public class CustomDateAttribute : RangeAttribute
        {
        public CustomDateAttribute()
            : base(typeof(DateTime), 
                    DateTime.Now.AddDays(+1).ToShortDateString(),
                    DateTime.Now.AddYears(+5).ToShortDateString()) 
        { } 
        }
        [Key]
        public int id { get; set; }

        [Required(ErrorMessage = "Bride's name must contain at least 3 characters")]
        [MinLength(3),MaxLength(45)]
        public string Bride { get; set; }

        [Required(ErrorMessage = "Groom's name must contain at least 3 characters")]
        [MinLength(3),MaxLength(45)]
        public string Groom { get; set; }
 
        [Required(ErrorMessage = "Event must have a set date")]
        [CustomDateAttribute(ErrorMessage = "You can't get married today or in the past.")]
        public DateTime Date{ get; set; }


        [Required(ErrorMessage = "Please provide an address")]
        [MinLength(3),MaxLength(245)]
        public string Address { get; set; }

        public DateTime Created { get; set; }

        [ForeignKey("id")]
        public int Userid { get; set; }

        public User Creator { get; set; }

        public List<Guestlist> Guests { get; set; }

        public Event()
        {
            Guests = new List<Guestlist>();
            Created = DateTime.Now;
        }
    }
}