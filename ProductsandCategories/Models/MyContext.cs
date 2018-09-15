using Microsoft.EntityFrameworkCore;
 
namespace ProductsandCategories.Models
{
    public class MyContext : DbContext
    {
        public MyContext(DbContextOptions<MyContext> options) : base(options) { }

        // //DbSet<Model Name> Table Name
        public DbSet<Product> Product { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<Categorized> Categorized { get; set; }
    }
}