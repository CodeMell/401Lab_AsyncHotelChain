using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Models.Interfaces
{
    public interface IHotel
    {
        public Task<ActionResult<IEnumerable<HotelLocation>>> GetHotelLocation();
        public Task<ActionResult<HotelLocation>> GetHotelLocation(int id);
        public Task<IActionResult> PutHotelLocation(int id, HotelLocation hotelLocation);
        public Task<ActionResult<HotelLocation>> PostHotelLocation(HotelLocation hotelLocation);
        public Task<IActionResult> DeleteHotelLocation(int id);
        public bool HotelLocationExists(int id);
    }
}
