using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class RoomAmenity
    {
        [Key]
        public int RoomID { get; set; }
        [Required]
        public int AmenityID { get; set; }
        [Required]
        public string Description { get; set; }
    }
}
