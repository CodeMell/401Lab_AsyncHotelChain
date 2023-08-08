using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WebApplication1.Migrations
{
    /// <inheritdoc />
    public partial class DB1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Amenity",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Amenity", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "HotelLocation",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    State = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HotelLocation", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Room",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nickname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LayoutType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    PetFriendly = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HotelLocationID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Room", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "RoomAmenity",
                columns: table => new
                {
                    RoomID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AmenityID = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoomAmenity", x => x.RoomID);
                });

            migrationBuilder.InsertData(
                table: "Amenity",
                columns: new[] { "ID", "Name" },
                values: new object[,]
                {
                    { 1, "A/C" },
                    { 2, "A/C" },
                    { 3, "A/C" }
                });

            migrationBuilder.InsertData(
                table: "HotelLocation",
                columns: new[] { "ID", "Address", "City", "Name", "PhoneNumber", "State" },
                values: new object[,]
                {
                    { 1, "1236 rode", "midtown", "laaBy", "555-555-5555", "TN" },
                    { 2, "7891 rode", "hightown", "Nigth 9", "666-666-6666", "TN" },
                    { 3, "1112 rode", "lowtown", "Layback Bay", "777-777-7777", "TN" }
                });

            migrationBuilder.InsertData(
                table: "Room",
                columns: new[] { "ID", "LayoutType", "HotelLocationID", "Nickname", "PetFriendly", "Price" },
                values: new object[,]
                {
                    { 1, "large", 1, "pro", "yes", 150.0 },
                    { 2, "mid", 2, "Basic Double", "yes", 100.0 },
                    { 3, "small", 3, "Basic Single", "no", 50.0 }
                });

            migrationBuilder.InsertData(
                table: "RoomAmenity",
                columns: new[] { "RoomID", "AmenityID", "Description" },
                values: new object[] { 1, 1, "cool" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Amenity");

            migrationBuilder.DropTable(
                name: "HotelLocation");

            migrationBuilder.DropTable(
                name: "Room");

            migrationBuilder.DropTable(
                name: "RoomAmenity");
        }
    }
}
