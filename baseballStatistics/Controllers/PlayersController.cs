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
    public class PlayersController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public PlayersController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        private Task<ApplicationUser> GetCurrentUserAsync() => _userManager.GetUserAsync(HttpContext.User);

        // GET: Players
        public async Task<IActionResult> Index()
        {
            var user = await GetCurrentUserAsync();
            var applicationDbContext = _context.Player
                .Where(b => b.ApplicationUserId == user.Id)
                .Include(b => b.ApplicationUser)
                .Include(b => b.Team);
                //.Include(b => b.Player);
            if (user == null)
            {
                return NotFound();
            }
            else
            {
                return View(await applicationDbContext.ToListAsync());
            }
        }

        // GET: Players/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var player = await _context.Player
                .Include(p => p.ApplicationUser)
                .Include(p => p.Team)
                .Include(p => p.BattingStats)
                .Include(p => p.FieldingStats)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (player == null)
            {
                return NotFound();
            }
            try
            {
                //var battingCalculation = (10 / (decimal) (75 - 25)).ToString("N3");
                var battingCalculation = ((player.BattingStats.Sum(i => i.Hit) / (decimal)(player.BattingStats.Sum(i => i.AtBat) - player.BattingStats.Sum(i => i.Walk))).ToString("N3"));

                ViewData["BattingAverage"] = battingCalculation;
            }
            catch (DivideByZeroException)
            {
                return View(player);
            }

            return View(player);
        }

        // GET: Players/Create
        public async Task<IActionResult> Create()
        {
            var user = await GetCurrentUserAsync();

            var player = new Player()
            {
                ApplicationUser = user,
                ApplicationUserId = user.Id
            };

            ViewData["TeamId"] = new SelectList(_context.Team, "Id", "Name");

            return View(player);

            //ViewData["ApplicationUserId"] = new SelectList(_context.ApplicationUser, "Id", "Id");
            //ViewData["TeamId"] = new SelectList(_context.Team, "Id", "Name");
            //return View();
        }

        // POST: Players/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FirstName,LastName,Nickname,Age,Position,JerseyNumber,ApplicationUserId,TeamId")] Player player)
        {
            if (ModelState.IsValid)
            {
                _context.Add(player);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ApplicationUserId"] = new SelectList(_context.ApplicationUser, "Id", "Id", player.ApplicationUserId);
            ViewData["TeamId"] = new SelectList(_context.Team, "Id", "Name", player.TeamId);
            return View(player);
        }

        // GET: Players/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var player = await _context.Player
                .Include(p => p.ApplicationUser)
                .Include(p => p.Team)
                .Include(p => p.BattingStats)
                .Include(p => p.FieldingStats)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (player == null)
            {
                return NotFound();
            }
            ViewData["ApplicationUserId"] = new SelectList(_context.ApplicationUser, "Id", "Id", player.ApplicationUserId);
            ViewData["TeamId"] = new SelectList(_context.Team, "Id", "Name", player.TeamId);
            return View(player);
        }

        // POST: Players/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FirstName,LastName,Nickname,Age,Position,ApplicationUserId,TeamId")] Player player)
        {
            if (id != player.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(player);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PlayerExists(player.Id))
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
            ViewData["ApplicationUserId"] = new SelectList(_context.ApplicationUser, "Id", "Id", player.ApplicationUserId);
            ViewData["TeamId"] = new SelectList(_context.Team, "Id", "Name", player.TeamId);
            return View(player);
        }

        // GET: Players/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var player = await _context.Player
                .Include(p => p.ApplicationUser)
                .Include(p => p.Team)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (player == null)
            {
                return NotFound();
            }

            return View(player);
        }

        // POST: Players/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var player = await _context.Player.FindAsync(id);
            _context.Player.Remove(player);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PlayerExists(int id)
        {
            return _context.Player.Any(e => e.Id == id);
        }

        private Task<ApplicationUser> GetUserAsync()
        {
            return _userManager.GetUserAsync(HttpContext.User);
        }
    }
}
