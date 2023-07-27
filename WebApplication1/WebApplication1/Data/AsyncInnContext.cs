using WebApplication1.Models;
using Microsoft.EntityFrameworkCore;
namespace WebApplication1.Data
{
    public class AsyncInnContext : DbContext
    {
        public DbSet<Amenity> Amenities;
        public DbSet<HotelLocation> hotelLocations;
        public DbSet<Room> rooms;
        public DbSet<RoomAmenity> roomAmenities;

        public AsyncInnContext(DbContextOptions<AsyncInnContext> options) : base(options) 
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Amenity>().HasData(new Amenity { AmenityId = 1, Name = "A/C" });
            modelBuilder.Entity<HotelLocation>().HasData(new HotelLocation { LocationId = 1, Name = "lee", Address = "1236 rode", City = "midtown", State = "TN", PhoneNumber = "555-555-5555" });
            modelBuilder.Entity<Room>().HasData(new Room { RoomId = 1, LayoutType = "big"});

            //lookup tables
            modelBuilder.Entity<RoomAmenity>().HasData(new RoomAmenity { AmenityId = 1, RoomId = 1, Description = "cool" });
        }
    }
}
