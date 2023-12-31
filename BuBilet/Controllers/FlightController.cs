using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BuBilet.Areas.Identity.Data;
using BuBilet.Models;

namespace BuBilet.Controllers
{
    public class FlightController : Controller
    {
        private readonly ApplicationDbContext _context;
        
      
        public FlightController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Flight
        public async Task<IActionResult> Index()
        {
              return _context.Flight != null ? 
                          View(await _context.Flight.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.Flight'  is null.");
        }

        // GET: Flight/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.Flight == null)
            {
                return NotFound();
            }

            var flight = await _context.Flight
                .FirstOrDefaultAsync(m => m.FlightId == id);
            if (flight == null)
            {
                return NotFound();
            }

            return View(flight);
        }

        // GET: Flight/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Flight/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(string flightId, string source, string destination, DateTime departureDateTime, DateTime arrivalDateTime)
        {
            var flight = new Flight
            {
                FlightId = flightId,
                Source = source,
                Destination = destination,
                DepartureDateTime = departureDateTime,
                ArrivalDateTime = arrivalDateTime
            };

            // Create 60 seats with the flight's ID
            var seats = new List<Seat>();
            for (int i = 1; i <= 60; i++)
            {
                seats.Add(new Seat
                {
                    FlightNumber = flightId,
                    SeatNumber = $"{i}",
                    IsAvailable = true,
                    Flight = flight
                });
            }

            if (ModelState.IsValid)
            {

                // Create a new flight
                _context.Flight.Add(flight);
                _context.Seat.AddRange(seats);

                return RedirectToAction(nameof(Index));
            }
            return View(flight);
        }
       

        // GET: Flight/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.Flight == null)
            {
                return NotFound();
            }

            var flight = await _context.Flight.FindAsync(id);
            if (flight == null)
            {
                return NotFound();
            }
            return View(flight);
        }

        // POST: Flight/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("FlightId,Source,Destination,DepartureDateTime,ArrivalDateTime")] Flight flight)
        {
            if (id != flight.FlightId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(flight);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FlightExists(flight.FlightId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(flight);
        }

        // GET: Flight/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.Flight == null)
            {
                return NotFound();
            }

            var flight = await _context.Flight
                .FirstOrDefaultAsync(m => m.FlightId == id);
            if (flight == null)
            {
                return NotFound();
            }

            return View(flight);
        }

        // POST: Flight/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.Flight == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Flight'  is null.");
            }
            var flight = await _context.Flight.FindAsync(id);
            if (flight != null)
            {
                _context.Flight.Remove(flight);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FlightExists(string id)
        {
          return (_context.Flight?.Any(e => e.FlightId == id)).GetValueOrDefault();
        }
    }
}
