using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProductsandCategories.Models
{
    [Table("Product")]
    public class Product
    {
        public int id { get; set; }

        [Required(ErrorMessage = "Product name is required")]
        [MinLength(3, ErrorMessage = "Minimum length is three characters"),MaxLength(45, ErrorMessage="Maximum length is forty-five characters")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Product description is required")]
        [MinLength(3, ErrorMessage = "Minimum length is three characters"),MaxLength(45, ErrorMessage="Maximum length is 250 characters")]
        public string Description { get; set; }
 
        [Required(ErrorMessage = "Product price is required")]
        public decimal Price{ get; set; }

        public DateTime Created { get; set; }

        public DateTime Updated { get; set; }

        public List<Categorized> Categories { get; set; }

        public Product()
        {
            Categories = new List<Categorized>();
            Created = DateTime.Now;
            Updated = DateTime.Now;
        }
    }
}