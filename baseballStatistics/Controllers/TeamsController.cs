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
    public class TeamsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public TeamsController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        private Task<ApplicationUser> GetCurrentUserAsync() => _userManager.GetUserAsync(HttpContext.User);

        // GET: Teams
        public async Task<IActionResult> Index()
        {
            var user = await GetCurrentUserAsync();
            var applicationDbContext = _context.Team
                .Include(a => a.ApplicationUser);

                return View(await applicationDbContext.ToListAsync());
            //return View();
            //if (user == null)
            //{
            //    return NotFound();
            //}
            //else
            //{
            //    return View(await applicationDbContext.ToListAsync());
            //}
        }

        // GET: Teams/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var team = await _context.Team
                .Include(t => t.Players)
                .Include(a => a.ApplicationUser)
                .Where(a => a.ApplicationUser.IsCoach == true)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (team == null)
            {
                return NotFound();
            }

            return View(team);
        }

        // GET: Teams/Create
        public IActionResult Create()
        {
            var coachList = _context.ApplicationUser
                    .Where(a => a.IsCoach == true);
            var coachSelectList = coachList.Select(coach => new SelectListItem
            {
                Text = coach.FullName,
                Value = coach.Id.ToString()
            }).ToList();
            coachSelectList.Insert(0, new SelectListItem
            {
                Text = "Select Coach",
                Value = "null"
            });
            ViewData["ApplicationUser"] = coachSelectList;
            return View();
        }

        // POST: Teams/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Mascot,TeamAffiliation,ApplicationUserId")] Team team)
        {
            if (team.ApplicationUserId == "null")
            {
                team.ApplicationUserId = null;
            }

            if (ModelState.IsValid)
            {
                _context.Add(team);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

    
                return View(team);
        }

        // GET: Teams/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var team = await _context.Team.FindAsync(id);
            if (team == null)
            {
                return NotFound();
            }
            var coachList = _context.ApplicationUser
                .Where(a => a.IsCoach == true);
            var coachSelectList = coachList.Select(coach => new SelectListItem
            {
                Text = coach.FullName,
                Value = coach.Id
            }).ToList();
            coachSelectList.Insert(0, new SelectListItem
            {
                Text = "Select Coach",
                Value = "null"
            });
            ViewData["ApplicationUserId"] = coachSelectList;
            //ViewData["ApplicationUserId"] = new SelectList(_context.ApplicationUser, "Id", "Id", team.ApplicationUserId);
            return View(team);
        }

        // POST: Teams/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Mascot,TeamAffiliation,ApplicationUserId")] Team team)
        {
            if (id != team.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(team);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TeamExists(team.Id))
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
            ViewData["ApplicationUserId"] = new SelectList(_context.ApplicationUser, "Id", "Id", team.ApplicationUserId);
            return View(team);
        }

        // GET: Teams/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var team = await _context.Team
                .Include(t => t.ApplicationUser)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (team == null)
            {
                return NotFound();
            }

            return View(team);
        }

        // POST: Teams/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var team = await _context.Team.FindAsync(id);
            _context.Team.Remove(team);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TeamExists(int id)
        {
            return _context.Team.Any(e => e.Id == id);
        }

        private Task<ApplicationUser> GetUserAsync()
        {
            return _userManager.GetUserAsync(HttpContext.User);
        }
    }
}
