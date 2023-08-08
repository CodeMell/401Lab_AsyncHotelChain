using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Models.Interfaces
{
    public interface IHotel
    {
        Task<ActionResult<IEnumerable<HotelLocation>>> GetHotelLocation();
        Task<ActionResult<HotelLocation>> GetHotelLocation(int id);
        Task<IActionResult> PutHotelLocation(int id, HotelLocation hotelLocation);
        Task<ActionResult<HotelLocation>> PostHotelLocation(HotelLocation hotelLocation);
        Task<IActionResult> DeleteHotelLocation(int id);
        bool HotelLocationExists(int id);
    }
}
