using GoogleMapsService.Models;
using Microsoft.EntityFrameworkCore;

namespace GoogleMapsService.Models
{
    public class Google_mapsContext : DbContext
    {
        public Google_mapsContext(
            DbContextOptions<Google_mapsContext> options)
            : base(options)
        {
        }

        public virtual DbSet<GoogleMap> GoogleMap
        {
            get; set;
        }

        protected override void OnModelCreating(
            ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<GoogleMap>().HasData(
                new GoogleMap
                {
                    Id = 1, Rating = 4,
                    Address = "Sredja skola",
                    Lat = 43.736938, Long = 15.898590
                },
                new GoogleMap
                {
                    Id = 2, Rating = 5,
                    Address = "Kuca", Lat = 43.750130,
                    Long = 15.887200
                },
                new GoogleMap
                {
                    Id = 3, Rating = 4,
                    Address = "Stan", Lat = 43.751060,
                    Long = 15.889960
                }
            );
        }
    }
}