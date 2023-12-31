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
    public class SeatController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SeatController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Seat
        public async Task<IActionResult> Index()
        {
              return _context.Seat != null ? 
                          View(await _context.Seat.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.Seat'  is null.");
        }

        // GET: Seat/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.Seat == null)
            {
                return NotFound();
            }

            var seat = await _context.Seat
                .FirstOrDefaultAsync(m => m.FlightNumber == id);
            if (seat == null)
            {
                return NotFound();
            }

            return View(seat);
        }

        // GET: Seat/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Seat/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FlightNumber,SeatNumber,IsAvailable")] Seat seat)
        {
            if (ModelState.IsValid)
            {
                _context.Add(seat);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(seat);
        }

        // GET: Seat/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.Seat == null)
            {
                return NotFound();
            }

            var seat = await _context.Seat.FindAsync(id);
            if (seat == null)
            {
                return NotFound();
            }
            return View(seat);
        }

        // POST: Seat/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("FlightNumber,SeatNumber,IsAvailable")] Seat seat)
        {
            if (id != seat.FlightNumber)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(seat);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SeatExists(seat.FlightNumber))
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
            return View(seat);
        }

        // GET: Seat/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.Seat == null)
            {
                return NotFound();
            }

            var seat = await _context.Seat
                .FirstOrDefaultAsync(m => m.FlightNumber == id);
            if (seat == null)
            {
                return NotFound();
            }

            return View(seat);
        }

        // POST: Seat/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.Seat == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Seat'  is null.");
            }
            var seat = await _context.Seat.FindAsync(id);
            if (seat != null)
            {
                _context.Seat.Remove(seat);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SeatExists(string id)
        {
          return (_context.Seat?.Any(e => e.FlightNumber == id)).GetValueOrDefault();
        }
    }
}
