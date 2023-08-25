using WebApplication1.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace WebApplication1.Data
{
    public class AsyncInnContext : IdentityDbContext
    {
        public DbSet<Amenity> Amenities { get; set; } = default!;
        public DbSet<HotelLocation> hotelLocations { get; set; } = default!;
        public DbSet<Room> rooms { get; set; } = default!;
        public DbSet<RoomAmenity> roomAmenities { get; set; } = default!;
        public DbSet<ApplicationUser> applicationUsers { get; set; } = default!;

        public AsyncInnContext(DbContextOptions<AsyncInnContext> options) : base(options) 
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // We need Identity to do it's thing ...
            base.OnModelCreating(modelBuilder);
            //information tables
            modelBuilder.Entity<Amenity>().HasData(new Amenity 
            { ID = 1, Name = "A/C" },
            new Amenity
            { ID = 2, Name = "Heater" },
            new Amenity
            { ID = 3, Name = "Soap" });

            modelBuilder.Entity<HotelLocation>().HasData(new HotelLocation 
            { ID = 1, Name = "laaBy", Address = "1236 rode", City = "midtown", State = "TN", PhoneNumber = "555-555-5555" },
            new HotelLocation
            { ID = 2, Name = "Nigth 9", Address = "7891 rode", City = "hightown", State = "TN", PhoneNumber = "666-666-6666" },
            new HotelLocation
            { ID = 3, Name = "Layback Bay", Address = "1112 rode", City = "lowtown", State = "TN", PhoneNumber = "777-777-7777" },);
            
            modelBuilder.Entity<Room>().HasData(new Room 
            { ID = 1, Nickname = "pro", LayoutType = "large", Price = 150.00, PetFriendly = "yes", LocationID = 1},
            new Room
            { ID = 2, Nickname = "Basic Double", LayoutType = "mid", Price = 100.00, PetFriendly = "yes", LocationID = 2 },
            new Room
            { ID = 3, Nickname = "Basic Single", LayoutType = "small", Price = 50.00, PetFriendly = "no", LocationID = 3 });

            //lookup tables
            modelBuilder.Entity<RoomAmenity>().HasData(new RoomAmenity 
            { ID = 1, AmenityID = 1, RoomID = 1, Description = "cool" },
            new RoomAmenity 
            { ID = 2, AmenityID = 1, RoomID = 1, Description = "cool" },
            new RoomAmenity
            { ID = 3, AmenityID = 1, RoomID = 1, Description = "cool" });

            modelBuilder.Entity<ApplicationUser>().HasData(new ApplicationUser
            { Id = 1, UserName = "rena", Password = "1q2w3e$R%T", Email = "rena@gmail.com", PhoneNumber = "555-555-5555", Token = "wEgwq3810=1"}
                );

            SeedRole(modelBuilder, "Admin", "create", "update", "delete");
            SeedRole(modelBuilder, "Editor", "create", "update");
        }

        private int nextId = 1;

        private void SeedRole(ModelBuilder modelBuilder, string roleName, params string[] permissions)
        {
            var role = new IdentityRole
            {
                Id = roleName.ToLower(),
                Name = roleName,
                NormalizedName = roleName.ToUpper(),
                ConcurrencyStamp = Guid.Empty.ToString()
            };

            modelBuilder.Entity<IdentityRole>().HasData(role);

            // Go through the permissions list (the params) and seed a new entry for each
            var roleClaims = permissions.Select(permission =>
              new IdentityRoleClaim<string>
              {
                  Id = nextId++,
                  RoleId = role.Id,
                  ClaimType = "permissions", // This matches what we did in Startup.cs
                  ClaimValue = permission
              }).ToArray();

            modelBuilder.Entity<IdentityRoleClaim<string>>().HasData(roleClaims);
        }

        public DbSet<WebApplication1.Models.HotelLocation> HotelLocation { get; set; } = default!;

        public DbSet<WebApplication1.Models.Amenity> Amenity { get; set; } = default!;

        public DbSet<WebApplication1.Models.Room> Room { get; set; } = default!;

        public DbSet<WebApplication1.Models.RoomAmenity> RoomAmenity { get; set; } = default!;
    }
}
