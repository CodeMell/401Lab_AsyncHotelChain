using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Models;
using WebApplication1.Models.Interfaces;
using WebApplication1.Models.Services;

namespace WebApplication1.Contorllers
{
    //https://localhost:44368/api/HotelLocations/
    //https://asyncinn.com/api/HotelLocations
    [Route("api/[controller]")]
    [ApiController]
    public class HotelLocationsController : ControllerBase
    {
        private readonly AsyncInnContext _context;
        private readonly IHotel _hotel;

        public HotelLocationsController(AsyncInnContext context, IHotel hotel)
        {
            _context = context;
            _hotel = hotel;
        }

        // GET: api/HotelLocations
        [HttpGet]
        public async Task<ActionResult<IEnumerable<HotelLocation>>> GetHotelLocation()
        {
            return await _hotel.GetHotelLocation();//ToListAsync();
        }

        // GET: api/HotelLocations/5
        [HttpGet("{id}")]
        public async Task<ActionResult<HotelLocation>> GetHotelLocation(int id)
        {
            return await _hotel.GetHotelLocation(id);
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

           await _hotel.PutHotelLocation(id, hotelLocation);

            return NoContent();
        }

        // POST: api/HotelLocations
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<HotelLocation>> PostHotelLocation(HotelLocation hotelLocation)
        {
            await _hotel.PostHotelLocation(hotelLocation);

            return CreatedAtAction("GetHotelLocation", new { id = hotelLocation.ID }, hotelLocation);
        }

        // DELETE: api/HotelLocations/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHotelLocation(int id)
        {
            await _hotel.DeleteHotelLocation(id);

            return NoContent();
        }

        private bool HotelLocationExists(int id)
        {
            return _hotel.HotelLocationExists(id);
        }
    }
}
