using Microsoft.EntityFrameworkCore;
 
namespace Restaurant.Models
{
    public class RestaurantContext : DbContext
    {
        public RestaurantContext(DbContextOptions<RestaurantContext> options) : base(options) { }

        public DbSet<Review> Review { get; set; }
    }
}