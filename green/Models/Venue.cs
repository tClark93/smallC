using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace green.Models
{
    [Table("Venue")]
    public class Venue
    {
        public int id { get; set; }

        [Required(ErrorMessage = "Please provide a name")]
        [MinLengthAttribute(1, ErrorMessage="Minimum length is one character"),MaxLength(200, ErrorMessage="Maximum length is two hundred characters")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please enter valid email")]
        [EmailAddress]
        [MinLengthAttribute(3, ErrorMessage="Minimum length is three characters"),MaxLength(150, ErrorMessage="Maximum length is 150 characters")]
        [RegularExpression(@"^\w+@[a-zA-Z_]+?\.[a-zA-Z]{2,3}$")]
        public string Email{ get; set; }

        [Required(ErrorMessage = "Please provide a description")]
        [MinLengthAttribute(10, ErrorMessage="Minimum length is ten characters"),MaxLength(500, ErrorMessage="Maximum length is five hundred characters")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Please provide an address")]
        [MinLengthAttribute(10, ErrorMessage="Minimum length is ten characters"),MaxLength(150, ErrorMessage="Maximum length is one hundred fifty characters")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Please provide an address")]
        [MinLengthAttribute(3, ErrorMessage="Minimum length is three characters"),MaxLength(75, ErrorMessage="Maximum length is seventy-five characters")]
        public string City { get; set; }

        public string State { get; set; }

        [Required(ErrorMessage = "Please provide a five digit zip code")]
        [RegularExpression(@"^\d{5}(?:[-\s]\d{4})?$", ErrorMessage = "Please enter a valid zipcode")]
        public int Zip { get; set; }

        [Required(ErrorMessage = "Please tell us when you open")]
        [StringLength(5)]
        public string Open { get; set; }

        [Required(ErrorMessage = "Please tell us when you close")]
        [StringLength(5)]
        public string Close { get; set; }

        [Required(ErrorMessage = "Please provide a phone number")]
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

        public decimal Lat { get; set; }
        public decimal Long { get; set; }

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
        public List<Show> Entertainment { get; set; }

        // public List<Like> LikedIdeas { get; set; }

        public Venue()
        {
            Entertainment = new List<Show>();
        
            Created = DateTime.Now;
        }
    }
}