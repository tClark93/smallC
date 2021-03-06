using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BankAccounts
{
    public class User
    {
        public int id { get; set; }

        [Required(ErrorMessage = "First name must contain at least 3 characters")]
        [MinLength(3)]
        public string First { get; set; }

        [Required(ErrorMessage = "Last name must contain at least 3 characters")]
        [MinLength(3)]
        public string Last { get; set; }
 
        [Required(ErrorMessage = "Please enter valid email")]
        [EmailAddress]
        [RegularExpression(@"^\w+@[a-zA-Z_]+?\.[a-zA-Z]{2,3}$")]
        public string Email{ get; set; }

        [Required]
        [MinLength(8)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Compare("Password")]
        [NotMapped]
        public string Confirm { get; set; }

    }
}