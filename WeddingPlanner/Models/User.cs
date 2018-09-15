using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WeddingPlanner
{
    [Table("User")]
    public class User
    {
        public int id { get; set; }

        [Required(ErrorMessage = "First name must contain at least 3 characters")]
        [MinLength(3),MaxLength(45)]
        [RegularExpression(@"^[a-zA-Z]+[ a-zA-Z-_]*$", ErrorMessage = "Use letters only")]
        public string First { get; set; }

        [Required(ErrorMessage = "Last name must contain at least 3 characters")]
        [MinLength(3),MaxLength(45)]
        [RegularExpression(@"^[a-zA-Z]+[ a-zA-Z-_]*$", ErrorMessage = "Use letters only")]
        public string Last { get; set; }
 
        [Required(ErrorMessage = "Please enter valid email")]
        [EmailAddress]
        [MinLength(3),MaxLength(245)]
        [RegularExpression(@"^\w+@[a-zA-Z_]+?\.[a-zA-Z]{2,3}$")]
        public string Email{ get; set; }

        [Required]
        [MinLength(8),MaxLength(40)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Compare("Password")]
        [NotMapped]
        public string Confirm { get; set; }

        public DateTime Created { get; set; }

        public List<Event> Events { get; set; }

        public User()
        {
            Events = new List<Event>();
            Created = DateTime.Now;
        }
    }
}