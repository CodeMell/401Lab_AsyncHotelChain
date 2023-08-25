﻿using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class HotelLocation
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string State { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public string PhoneNumber { get; set; }

        public List<Room> Rooms { get; set; }

        public HotelLocation(string name, string city, string state, string address, string phoneNumber)
        {
            
            Name = name;
            City = city;
            State = state;
            Address = address;
            PhoneNumber = phoneNumber;
            
        }
    }
}
