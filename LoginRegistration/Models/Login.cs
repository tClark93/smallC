using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LoginRegistration
{
    public class Login
    {
        [Required(ErrorMessage = "Please enter valid email")]
        [EmailAddress]
        [RegularExpression(@"^\w+@[a-zA-Z_]+?\.[a-zA-Z]{2,3}$")]
        public string logEmail{ get; set; }

        [Required]
        [MinLength(8)]
        [DataType(DataType.Password)]
        public string logPassword { get; set; }
    }
}