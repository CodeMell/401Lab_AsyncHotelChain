﻿using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class Room
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public string Nickname { get; set; }
        [Required]
        public string LayoutType { get; set; }
        [Required]
        public double Price { get; set; }
        [Required]
        public string PetFriendly { get; set; }
        [Required]
        public int LocationID { get; set; }
    }
}
