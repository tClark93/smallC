using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProductsandCategories.Models
{
    [Table("Category")]
    public class Category
    {
        public int id { get; set; }

        [Required(ErrorMessage = "Category name is required")]
        [MinLength(3, ErrorMessage = "Minimum length is three characters"),MaxLength(45, ErrorMessage="Maximum length is forty-five characters")]
        public string Name { get; set; }

        public DateTime Created { get; set; }

        public DateTime Updated { get; set; }

        public List<Categorized> CategorizedProducts { get; set; }

        public Category()
        {
            CategorizedProducts = new List<Categorized>();
            Created = DateTime.Now;
            Updated = DateTime.Now;
        }
    }
}