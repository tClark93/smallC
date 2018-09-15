using Microsoft.EntityFrameworkCore;
 
namespace DojoSecrets.Models
{
    public class MyContext : DbContext
    {
        public MyContext(DbContextOptions<MyContext> options) : base(options) { }

        // //DbSet<Model Name> Table Name
        public DbSet<User> User { get; set; }
        public DbSet<Secret> Secret { get; set; }
        public DbSet<Like> Like { get; set; }
    }
}