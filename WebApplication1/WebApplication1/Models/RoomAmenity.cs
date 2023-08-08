using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class RoomAmenity
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public int RoomID { get; set; }
        [Required]
        public int AmenityID { get; set; }
        public string Description { get; set; }

        public Room Room { get; set; }
        public Amenity Amenity { get; set;}
    }
}
