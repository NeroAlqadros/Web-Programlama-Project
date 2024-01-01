using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BuBilet.Areas.Identity.Data;
using BuBilet.Models;
using Microsoft.AspNetCore.Authorization;

namespace BuBilet.Controllers
{
    [Authorize("RequireAdmin")]
    public class PlaneTypesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PlaneTypesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: PlaneTypes
        public async Task<IActionResult> Index()
        {
              return _context.PlaneTypes != null ? 
                          View(await _context.PlaneTypes.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.PlaneTypes'  is null.");
        }

        // GET: PlaneTypes/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.PlaneTypes == null)
            {
                return NotFound();
            }

            var planeTypes = await _context.PlaneTypes
                .FirstOrDefaultAsync(m => m.PlaneId == id);
            if (planeTypes == null)
            {
                return NotFound();
            }

            return View(planeTypes);
        }

        // GET: PlaneTypes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PlaneTypes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PlaneId,PlaneType")] PlaneTypes planeTypes)
        {
            if (ModelState.IsValid)
            {
                _context.Add(planeTypes);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(planeTypes);
        }

        // GET: PlaneTypes/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.PlaneTypes == null)
            {
                return NotFound();
            }

            var planeTypes = await _context.PlaneTypes.FindAsync(id);
            if (planeTypes == null)
            {
                return NotFound();
            }
            return View(planeTypes);
        }

        // POST: PlaneTypes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("PlaneId,PlaneType")] PlaneTypes planeTypes)
        {
            if (id != planeTypes.PlaneId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(planeTypes);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PlaneTypesExists(planeTypes.PlaneId))
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
            return View(planeTypes);
        }

        // GET: PlaneTypes/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.PlaneTypes == null)
            {
                return NotFound();
            }

            var planeTypes = await _context.PlaneTypes
                .FirstOrDefaultAsync(m => m.PlaneId == id);
            if (planeTypes == null)
            {
                return NotFound();
            }

            return View(planeTypes);
        }

        // POST: PlaneTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.PlaneTypes == null)
            {
                return Problem("Entity set 'ApplicationDbContext.PlaneTypes'  is null.");
            }
            var planeTypes = await _context.PlaneTypes.FindAsync(id);
            if (planeTypes != null)
            {
                _context.PlaneTypes.Remove(planeTypes);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PlaneTypesExists(string id)
        {
          return (_context.PlaneTypes?.Any(e => e.PlaneId == id)).GetValueOrDefault();
        }
    }
}
