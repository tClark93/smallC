using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProductsandCategories.Models
{
    public class Categorized
    {
        [Key]
        public int id { get; set; }

        [ForeignKey("id")]
        public int Productid { get; set; }

        [ForeignKey("id")]
        public int Categoryid { get; set; }

        public Product Product { get; set; }

        public Category Category {get; set; }
    }
}