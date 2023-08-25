using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class Amenity
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public string Name { get; set; }

        public Amenity(string name)
        {
            Name = name;
        }
    }
}
