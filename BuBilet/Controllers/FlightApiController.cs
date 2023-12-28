using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BuBilet.Areas.Identity.Data;
using BuBilet.Models;

namespace BuBilet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FlightApiController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public FlightApiController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/FlightApi
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Flight>>> GetFlight()
        {
          if (_context.Flight == null)
          {
              return NotFound();
          }
            return await _context.Flight.ToListAsync();
        }

        // GET: api/FlightApi/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Flight>> GetFlight(string id)
        {
          if (_context.Flight == null)
          {
              return NotFound();
          }
            var flight = await _context.Flight.FindAsync(id);

            if (flight == null)
            {
                return NotFound();
            }

            return flight;
        }

        // PUT: api/FlightApi/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFlight(string id, Flight flight)
        {
            if (id != flight.FlightNumber)
            {
                return BadRequest();
            }

            _context.Entry(flight).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FlightExists(id))
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

        // POST: api/FlightApi
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Flight>> PostFlight(Flight flight)
        {
          if (_context.Flight == null)
          {
              return Problem("Entity set 'ApplicationDbContext.Flight'  is null.");
          }
            _context.Flight.Add(flight);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (FlightExists(flight.FlightNumber))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetFlight", new { id = flight.FlightNumber }, flight);
        }

        // DELETE: api/FlightApi/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFlight(string id)
        {
            if (_context.Flight == null)
            {
                return NotFound();
            }
            var flight = await _context.Flight.FindAsync(id);
            if (flight == null)
            {
                return NotFound();
            }

            _context.Flight.Remove(flight);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool FlightExists(string id)
        {
            return (_context.Flight?.Any(e => e.FlightNumber == id)).GetValueOrDefault();
        }
    }
}
