using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace green.Models
{
    [Table("Artist")]
    public class Artist
    {
        public int id { get; set; }

        [Required(ErrorMessage = "Please provide a name")]
        [MinLengthAttribute(1, ErrorMessage="Minimum length is one character"),MaxLength(100, ErrorMessage="Maximum length is one hundred characters")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please enter valid email")]
        [EmailAddress]
        [MinLengthAttribute(3, ErrorMessage="Minimum length is three characters"),MaxLength(150, ErrorMessage="Maximum length is 150 characters")]
        [RegularExpression(@"^\w+@[a-zA-Z_]+?\.[a-zA-Z]{2,3}$")]
        public string Email{ get; set; }

        [Required(ErrorMessage = "Please provide a description")]
        [MinLengthAttribute(1, ErrorMessage="Minimum length is ten characters"),MaxLength(1200, ErrorMessage="Maximum length is twelve hundred characters")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Please provide a five digit zip code")]
        [RegularExpression(@"^\d{5}(?:[-\s]\d{4})?$", ErrorMessage = "Please enter a valid zipcode")]
        public int Zip { get; set; }

        [RegularExpression(@"^(\+\d{1,2}\s)?\(?\d{3}\)?[\s.-]?\d{3}[\s.-]?\d{4}$", ErrorMessage = "Please enter a valid phone number")]
        public string Phone { get; set; }
        
        [RegularExpression(@"^(ht|f)tp(s?)\:\/\/[0-9a-zA-Z]([-.\w]*[0-9a-zA-Z])*(:(0-9)*)*(\/?)([a-zA-Z0-9\-\.\?\,\'\/\\\+&%\$#_]*)?$", ErrorMessage="Please enter valid URL")]
        public string Website { get; set; }

        [RegularExpression(@"^(ht|f)tp(s?)\:\/\/[0-9a-zA-Z]([-.\w]*[0-9a-zA-Z])*(:(0-9)*)*(\/?)([a-zA-Z0-9\-\.\?\,\'\/\\\+&%\$#_]*)?$", ErrorMessage="Please enter valid URL")]
        public string Twitter { get; set; }

        [RegularExpression(@"^(ht|f)tp(s?)\:\/\/[0-9a-zA-Z]([-.\w]*[0-9a-zA-Z])*(:(0-9)*)*(\/?)([a-zA-Z0-9\-\.\?\,\'\/\\\+&%\$#_]*)?$", ErrorMessage="Please enter valid URL")]
        public string Instagram { get; set; }

        [RegularExpression(@"^(ht|f)tp(s?)\:\/\/[0-9a-zA-Z]([-.\w]*[0-9a-zA-Z])*(:(0-9)*)*(\/?)([a-zA-Z0-9\-\.\?\,\'\/\\\+&%\$#_]*)?$", ErrorMessage="Please enter valid URL")]
        public string Facebook { get; set; }

        [Required]
        [MinLengthAttribute(8, ErrorMessage="Minimum length is eight characters"),MaxLength(40, ErrorMessage="Maximum length is forty characters")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Passwords do not match")]
        [NotMapped]
        public string Confirm { get; set; }

        public DateTime Created { get; set; }
        public List<Show> Gigs { get; set; }

        // public List<Like> LikedIdeas { get; set; }

        public Artist()
        {
            Gigs = new List<Show>();
        
            Created = DateTime.Now;
        }
    }
}