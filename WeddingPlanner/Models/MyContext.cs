using Microsoft.EntityFrameworkCore;
 
namespace WeddingPlanner.Models
{
    public class MyContext : DbContext
    {
        public MyContext(DbContextOptions<MyContext> options) : base(options) { }

        // //DbSet<Model Name> Table Name
        public DbSet<User> User { get; set; }
        public DbSet<Event> Event { get; set; }
        public DbSet<Guestlist> Guestlist { get; set; }
    }
}