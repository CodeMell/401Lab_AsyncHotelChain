using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Contorllers
{
    //https://localhost:1234/api/HotelLocations/
    //https://asyncinn.com/api/HotelLocations
    [Route("api/[controller]")]
    [ApiController]
    public class HotelLocationsController : ControllerBase
    {
        private readonly AsyncInnContext _context;

        public HotelLocationsController(AsyncInnContext context)
        {
            _context = context;
        }

        // GET: api/HotelLocations
        [HttpGet]
        public async Task<ActionResult<IEnumerable<HotelLocation>>> GetHotelLocation()
        {
          if (_context.HotelLocation == null)
          {
              return NotFound();
          }
            return await _context.HotelLocation.Where(h => h.City == "midtown").ToListAsync();//ToListAsync();
        }

        // GET: api/HotelLocations/5
        [HttpGet("{id}")]
        public async Task<ActionResult<HotelLocation>> GetHotelLocation(int id)
        {
          if (_context.HotelLocation == null)
          {
              return NotFound();
          }
            var hotelLocation = await _context.HotelLocation.FindAsync(id);

            if (hotelLocation == null)
            {
                return NotFound();
            }

            return hotelLocation;
        }

        // PUT: api/HotelLocations/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHotelLocation(int id, HotelLocation hotelLocation)
        {
            if (id != hotelLocation.ID)
            {
                return BadRequest();
            }

            _context.Entry(hotelLocation).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HotelLocationExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/HotelLocations
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<HotelLocation>> PostHotelLocation(HotelLocation hotelLocation)
        {
          if (_context.HotelLocation == null)
          {
              return Problem("Entity set 'AsyncInnContext.HotelLocation'  is null.");
          }
            _context.HotelLocation.Add(hotelLocation);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetHotelLocation", new { id = hotelLocation.ID }, hotelLocation);
        }

        // DELETE: api/HotelLocations/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHotelLocation(int id)
        {
            if (_context.HotelLocation == null)
            {
                return NotFound();
            }
            var hotelLocation = await _context.HotelLocation.FindAsync(id);
            if (hotelLocation == null)
            {
                return NotFound();
            }

            _context.HotelLocation.Remove(hotelLocation);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool HotelLocationExists(int id)
        {
            return (_context.HotelLocation?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
