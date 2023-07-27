using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class RoomAmenity
    {
        [Key]
        public int RoomId { get; set; }
        [Required]
        public string AmenityId { get; set; }
        [Required]
        public string Description { get; set; }
    }
}
