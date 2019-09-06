using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using baseballStatistics.Data;
using baseballStatistics.Models;

namespace baseballStatistics.Controllers
{
    public class FieldingStatsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public FieldingStatsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: FieldingStats
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.FieldingStats.Include(f => f.Player);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: FieldingStats/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fieldingStats = await _context.FieldingStats
                .Include(f => f.Player)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (fieldingStats == null)
            {
                return NotFound();
            }

            return View(fieldingStats);
        }

        // GET: FieldingStats/Create
        public IActionResult Create()
        {
            ViewData["PlayerId"] = new SelectList(_context.Player, "Id", "ApplicationUserId");
            return View();
        }

        // POST: FieldingStats/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,PlayerId,GameDate,Assist,Error,Putout,DoublePlay")] FieldingStats fieldingStats)
        {
            if (ModelState.IsValid)
            {
                _context.Add(fieldingStats);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PlayerId"] = new SelectList(_context.Player, "Id", "ApplicationUserId", fieldingStats.PlayerId);
            return View(fieldingStats);
        }

        // GET: FieldingStats/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fieldingStats = await _context.FieldingStats.FindAsync(id);
            if (fieldingStats == null)
            {
                return NotFound();
            }
            ViewData["PlayerId"] = new SelectList(_context.Player, "Id", "ApplicationUserId", fieldingStats.PlayerId);
            return View(fieldingStats);
        }

        // POST: FieldingStats/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,PlayerId,GameDate,Assist,Error,Putout,DoublePlay")] FieldingStats fieldingStats)
        {
            if (id != fieldingStats.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(fieldingStats);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FieldingStatsExists(fieldingStats.Id))
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
            ViewData["PlayerId"] = new SelectList(_context.Player, "Id", "ApplicationUserId", fieldingStats.PlayerId);
            return View(fieldingStats);
        }

        // GET: FieldingStats/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fieldingStats = await _context.FieldingStats
                .Include(f => f.Player)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (fieldingStats == null)
            {
                return NotFound();
            }

            return View(fieldingStats);
        }

        // POST: FieldingStats/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var fieldingStats = await _context.FieldingStats.FindAsync(id);
            _context.FieldingStats.Remove(fieldingStats);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FieldingStatsExists(int id)
        {
            return _context.FieldingStats.Any(e => e.Id == id);
        }
    }
}
