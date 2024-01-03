using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BuBilet.Areas.Identity.Data;
using BuBilet.Models;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace BuBilet.Controllers
{
    public class FlightController : Controller
    {
        private readonly ApplicationDbContext _context;
        Random random = new Random();

        public FlightController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Flight
        public async Task<IActionResult> Index()
        {
             return View();
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

      

        public async Task<IActionResult> Flights(string source, string destination, DateTime departureTime)
        {

            return View("Flights", await _context.Flight.Where(f => f.Source == source && f.Destination == destination && f.DepartureDateTime.Date == departureTime).ToListAsync());
        }


      
        // GET: Flight/Create
        [Authorize("RequireAdmin")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Flight/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FlightId,Source,Destination,DepartureDateTime,ArrivalDateTime,PlaneId")] Flight flight)
        {
            var flights = _context.Flight.ToList();
            foreach (var item in flights)
            {
                if (flight.FlightId == item.FlightId)
                {
                    return View(flight);
                }
            }
            

            if (ModelState.IsValid)
            {
                for(var i = 1; i < 72; i++)
                {
                    Seat seat = new Seat()
                    {
                        SeatId = Guid.NewGuid().ToString(),
                        FlightId = flight.FlightId,
                        SeatNumber = i.ToString(),
                        IsAvailable = true
                    };
                    _context.Add(seat);
                }

                _context.Add(flight);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(flight);
        }

        // GET: Flight/Edit/5
        [Authorize("RequireAdmin")]
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
        public async Task<IActionResult> Edit(string id, [Bind("FlightId,Source,Destination,DepartureDateTime,ArrivalDateTime,PlaneId")] Flight flight)
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
        [Authorize("RequireAdmin")]
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
            var seats= await _context.Seat.Where(s => s.FlightId == id).ToListAsync();
            var tickets =await _context.Ticket.Where(t => t.FlightId == id).ToListAsync();
            if (flight != null)
            {
                _context.Flight.Remove(flight);
                foreach(var seat in seats){
                    _context.Seat.Remove(seat);
                }
                foreach (var ticket in tickets)
                {
                    _context.Ticket.Remove(ticket);
                }
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Buy(string id) 
        { if (id == null || _context.Flight == null)
            { return NotFound(); } 
            var flight = await _context.Flight
                .FirstOrDefaultAsync(m => m.FlightId == id); 
            if (flight == null) 
            { return NotFound(); }
            await _context.SaveChangesAsync();
           
            return View(flight);
        }


        [HttpPost, ActionName("Buy")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> BuyConfirmed(string id , string SeatNumber)
        { 
           

            var flight1 =  _context.Flight.FirstOrDefault(f=> f.FlightId == id);

            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var claims = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);

            var seat = _context.Seat.FirstOrDefault(s => s.FlightId == id || s.SeatNumber == SeatNumber );



            if (seat.IsAvailable == false)
            {
                return View();
            }

           
            
           
            Ticket ticket = new Ticket()
            {
                TicketId = Guid.NewGuid().ToString(),
                Id = claims.Value.ToString(),
                FlightId = id,
                SeatId = seat.SeatId
            
            };

            if (_context.Flight == null) 
            { return Problem("Entity set 'ApplicationDbContext.Flight'  is null.");
            } 
            var flight = await _context.Flight.FindAsync(id);


            seat.IsAvailable = false;
             _context.Update(seat);
            if (flight != null)

               
            { _context.Ticket.Add(ticket); 
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
