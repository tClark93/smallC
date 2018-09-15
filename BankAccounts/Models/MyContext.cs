using Microsoft.EntityFrameworkCore;
 
namespace BankAccounts.Models
{
    public class MyContext : DbContext
    {
        public MyContext(DbContextOptions<MyContext> options) : base(options) { }

        //DbSet<Model Name> Table Name
        public DbSet<User> User { get; set; }
        public DbSet<Account> Account { get; set; }
    }
}