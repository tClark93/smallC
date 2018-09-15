using Microsoft.EntityFrameworkCore;
 
namespace green.Models
{
    public class MyContext : DbContext
    {
        public MyContext(DbContextOptions<MyContext> options) : base(options) { }

        // //DbSet<Model Name> Table Name
        public DbSet<Venue> Venue { get; set; }
        public DbSet<Artist> Artist { get; set; }
        public DbSet<Show> Show { get; set; }
    }
}