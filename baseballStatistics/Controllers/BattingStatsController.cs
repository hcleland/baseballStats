using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using baseballStatistics.Data;
using baseballStatistics.Models;
using Microsoft.AspNetCore.Identity;

namespace baseballStatistics.Controllers
{
    public class BattingStatsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public BattingStatsController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        private Task<ApplicationUser> GetCurrentUserAsync() => _userManager.GetUserAsync(HttpContext.User);

        // GET: BattingStats
        public async Task<IActionResult> Index()
        {
            var user = await GetCurrentUserAsync();
            var applicationDbContext = _context.Stats
                .Where(b => b.Player.ApplicationUserId == user.Id)
                .Include(b => b.Player.ApplicationUser)
                .Include(b => b.Player);
            if (user == null)
            {
                return NotFound();
            }
            else
            {
                return View(await applicationDbContext.ToListAsync());
            }
        }

        // GET: BattingStats/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var battingStats = await _context.Stats
                .Include(b => b.Player)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (battingStats == null)
            {
                return NotFound();
            }

            return View(battingStats);
        }

        // GET: BattingStats/Create
        public async Task<IActionResult> Create()
        {
            //var user = await GetCurrentUserAsync();
            //ViewData["PlayerId"] = new SelectList(
            //    _context.Player.Where(a => a.
            //    ApplicationUserId == user.Id), "Id", "FullName");
            //return View();

            var user = await GetUserAsync();
            ViewData["PlayerId"] = new SelectList(
                _context.Player.Where(a => a.ApplicationUserId == user.Id), "Id", "FirstName");
            return View();

            //var user = await GetCurrentUserAsync();
            //var applicationDbContext = _context.Stats
            //    .Where(b => b.Player.ApplicationUserId == user.Id)
            //    .Include(b => b.Player.ApplicationUser)
            //    .Include(b => b.Player);
            //if (user == null)
            //{
            //    return NotFound();
            //}
            //else
            //{
            //    return View(await applicationDbContext.ToListAsync());
            //}
        }


        // POST: BattingStats/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,PlayerId,GameDate,AtBat,Hit,Single,Double,Triple,HomeRun,RunsBattedIn,RunsScored,Walk,Strikeout")] BattingStats battingStats)
        {
            if (ModelState.IsValid)
            { 

                _context.Add(battingStats);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            //ViewData["PlayerId"] = new SelectList(
            //    _context.Player.Where(a => a.ApplicationUserId == user.Id), "Id", "FirstName", battingStats.PlayerId);
            return View(battingStats);
        }

        // GET: BattingStats/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var battingStats = await _context.Stats.FindAsync(id);
            if (battingStats == null)
            {
                return NotFound();
            }
            ViewData["PlayerId"] = new SelectList(_context.Player, "Id", "ApplicationUserId", battingStats.PlayerId);
            return View(battingStats);
        }

        // POST: BattingStats/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,PlayerId,GameDate,AtBat,Hit,Single,Double,Triple,HomeRun,RunsBattedIn,RunsScored,Walk,Strikeout")] BattingStats battingStats)
        {
            if (id != battingStats.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(battingStats);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BattingStatsExists(battingStats.Id))
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
            ViewData["PlayerId"] = new SelectList(_context.Player, "Id", "ApplicationUserId", battingStats.PlayerId);
            return View(battingStats);
        }

        // GET: BattingStats/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var battingStats = await _context.Stats
                .Include(b => b.Player)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (battingStats == null)
            {
                return NotFound();
            }

            return View(battingStats);
        }

        // POST: BattingStats/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var battingStats = await _context.Stats.FindAsync(id);
            _context.Stats.Remove(battingStats);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BattingStatsExists(int id)
        {
            return _context.Stats.Any(e => e.Id == id);
        }

        private Task<ApplicationUser> GetUserAsync()
        {
            return _userManager.GetUserAsync(HttpContext.User);
        }

    }
}
