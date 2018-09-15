using System.ComponentModel.DataAnnotations;
namespace ValidatingForm.Models
{
    public class User
    {
        [Required]
        [MinLength(4)]
        public string First { get; set; }

        [Required]
        [MinLength(4)]
        public string Last { get; set; }

        [Required]
        [Range(1,101)]
        public int Age { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [MinLength(8)]
        public string Password { get; set; }
    }
}
