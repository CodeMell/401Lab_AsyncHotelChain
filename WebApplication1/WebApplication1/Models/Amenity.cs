using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class Amenity
    {
        [Key]
        public int AmenityId { get; set; }
        [Required]
        public string Name { get; set; }
    }
}
