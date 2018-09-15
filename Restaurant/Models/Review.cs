using System;
using System.ComponentModel.DataAnnotations;
 
namespace Restaurant.Models
{
    public class CustomDateAttribute : RangeAttribute
        {
        public CustomDateAttribute()
            : base(typeof(DateTime), 
                    DateTime.Now.AddYears(-10).ToShortDateString(),
                    DateTime.Now.ToShortDateString()) 
        { } 
        }

    public class Review
    {
        public int id { get; set; }

        [Required(ErrorMessage = "Name must contain at least 3 characters")]
        [MinLength(3)]
        public string Reviewer { get; set; }
 
        [Required]
        [MinLength(1)]
        public string Restaurant { get; set; }
 
        [Required(ErrorMessage = "Review must be at least 10 characters long")]
        [MinLength(10)]
        public string Content{ get; set; }

        [Required]
        public int Stars{ get; set; }

        [Required(ErrorMessage = "Date cannot be in the future")]
        [CustomDateAttribute]
        public DateTime Date{ get; set; }
    }
}