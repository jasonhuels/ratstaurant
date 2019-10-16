using Microsoft.EntityFrameworkCore;

namespace Ratstaurant.Models
{
  public class RatstaurantContext : DbContext
  {
    public virtual DbSet<Cuisine> Cuisine { get; set; }
    public DbSet<Restaurant> Restaurants { get; set; }

    public RatstaurantContext(DbContextOptions options) : base(options) { }
  }
}