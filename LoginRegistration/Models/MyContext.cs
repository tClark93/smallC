using Microsoft.EntityFrameworkCore;
 
namespace LoginRegistration.Models
{
    public class MyContext : DbContext
    {
        public MyContext(DbContextOptions<MyContext> options) : base(options) { }

        //DbSet<Model Name> Table Name
        public DbSet<User> User { get; set; }
    }
}