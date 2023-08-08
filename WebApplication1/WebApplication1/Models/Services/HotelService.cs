using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Models.Interfaces;

namespace WebApplication1.Models.Services
{
    public class HotelService : IHotel
    {
        private AsyncInnContext _context;

        public HotelService(AsyncInnContext context)
        {
            _context = context;
        }

        // get all hotels
        public async Task<ActionResult<IEnumerable<HotelLocation>>> IHotel.GetHotelLocation()
        {
            return await _context.HotelLocation.ToListAsync();
        }
        // get a hotel
        public async Task<ActionResult<HotelLocation>> IHotel.GetHotelLocation(int id)
        {
            return await _context.HotelLocation.ToListAsync(id);
        }
        public async Task<IActionResult> IHotel.PutHotelLocation(int id, HotelLocation hotelLocation)
        {
            _context.Entry(hotelLocation).State = EntityState.Modified;
            try
            {
                // save data changes
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException) 
            {
                throw;
            }
            return null;
        }
        public async Task<ActionResult<HotelLocation>> IHotel.PostHotelLocation(HotelLocation hotelLocation)
        {
            _context.HotelLocation.Add(hotelLocation);
            await _context.SaveChangesAsync();
            return hotelLocation;
        }
        public async Task<IActionResult> IHotel.DeleteHotelLocation(int id)
        {
            // former hotel controller functionality
            var hotel = await _context.HotelLocation.FindAsync(id);
            _context.HotelLocation.Remove(hotel);
            await _context.SaveChangesAsync();
            // end
            return null;
            //return null to controller. controller returns No Content to user
        }
        public bool IHotel.HotelLocationExists(int id)
        {
            return (_context.HotelLocation?.Any(e => e.ID == id)).GetValueOrDefault;
        }
    }
}
