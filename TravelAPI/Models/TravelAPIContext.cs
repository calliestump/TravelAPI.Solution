using Microsoft.EntityFrameworkCore;


namespace TravelAPI.Models
{
    public class TravelAPIContext : DbContext
    {
        public TravelAPIContext(DbContextOptions<TravelAPIContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Review> Reviews { get; set; }
        public virtual DbSet<Location> Locations { get; set; }
    }
}