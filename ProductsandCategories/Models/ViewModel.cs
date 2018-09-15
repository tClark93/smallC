using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProductsandCategories.Models
{
    public class ViewModel
    {
        public Product Product { get; set; }
        public List<Product> AllProducts { get; set; }
        public Category Category { get; set; }
        public List<Category> AllCategories { get; set; }
        public List<Category> Excludes { get; set; }
        public Categorized Categorized { get; set; }
        public List<Categorized> AllPairs { get; set; }
    }
}