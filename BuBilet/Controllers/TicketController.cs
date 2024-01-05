using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BuBilet.Areas.Identity.Data;
using BuBilet.Models;
using System.Security.Claims;
using BuBilet.Migrations;

namespace BuBilet.Controllers
{
    public class TicketController : Controller
    {
      

        private readonly ApplicationDbContext _context;

        public TicketController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Ticket
        public async Task<IActionResult> Index()
        {
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var claims = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);
          

            var tickets = await _context.Ticket.Where(m => m.Id == claims.Value).ToListAsync();


            foreach (var item in tickets)
            {
               item.Flight = await _context.Flight.Where(f => f.FlightId == item.FlightId).FirstOrDefaultAsync();
            }

            // var flights = await _context.Flight.ToListAsync();
            // var matchingFlights = flights.Where(flight => tickets.Any(ticket => ticket.FlightId == flight.FlightId)).ToList();




            // var flights1 = flights.FirstOrDefault(m => m.FlightId ==ticket.FlightId);

            // var flights = await _context.Flight.FirstOrDefaultAsync(m => m.FlightId == ticket.FlightId);

            return View(tickets);

            /*
              return _context.Ticket != null ? 
                          View(await _context.Ticket.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.Ticket'  is null.");
            */
        }

        // GET: Ticket/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.Flight == null)
            {
                return NotFound();
            }

            var ticket = await _context.Ticket.FirstOrDefaultAsync(t => t.TicketId == id);
           // var flight = await _context.Flight.FirstOrDefaultAsync(m => m.FlightId == id);
           ticket.Flight = await _context.Flight.FirstOrDefaultAsync(f=> f.FlightId == ticket.FlightId);
            if (ticket == null)
            {
                return NotFound();
            }

            return View(ticket);
        }

        // GET: Ticket/Create
        

        // GET: Ticket/Edit/5
     

      

        // GET: Ticket/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.Ticket == null)
            {
                return NotFound();
            }

            var ticket = await _context.Ticket.FirstOrDefaultAsync(m => m.TicketId == id);


            ticket.Flight = await _context.Flight.FirstOrDefaultAsync(f => f.FlightId == ticket.FlightId);


            if (ticket == null)
            {
                return NotFound();
            }

            return View(ticket);
        }

        // POST: Ticket/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.Ticket == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Ticket'  is null.");
            }

            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var claims = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);


            var ticket = await _context.Ticket.FirstOrDefaultAsync(m => m.Id == claims.Value && m.TicketId == id);

           

            if (ticket != null)
            {
                _context.Ticket.Remove(ticket);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TicketExists(string id)
        {
          return (_context.Ticket?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
