using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyPersonalWeb.Web.Data;
using MyPersonalWeb.Web.Data.Entities;
using MyPersonalWeb.Web.Helpers;
using MyPersonalWeb.Web.Models;

namespace MyPersonalWeb.Web.Controllers
{
    [Authorize]
    public class LeaguesController : Controller
    {
        private readonly DataContext _context;
        private readonly IConverterHelper _converterHelper;

        public LeaguesController(DataContext context, IConverterHelper converterHelper)
        {
            _context = context;
            _converterHelper = converterHelper;
        }

        public IActionResult Index()
        {
            return View(_context.Leagues.Include(t => t.Teams));
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var league = await _context.Leagues.Include(t => t.Teams)
                .FirstOrDefaultAsync(m => m.LeagueId == id);
            if (league == null)
            {
                return NotFound();
            }

            return View(league);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(League league)
        {
            if (ModelState.IsValid)
            {
                if (LeagueNameExists(league.Name))
                {
                    ModelState.AddModelError(string.Empty, "La Liga ya existe.");
                    return View(league);
                }

                _context.Add(league);
                try
                {
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError(string.Empty, ex.ToString());
                    return View(league);
                }
            }
            return View(league);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var league = await _context.Leagues.FindAsync(id);
            if (league == null)
            {
                return NotFound();
            }
            return View(league);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("LeagueId,Name")] League league)
        {
            if (id != league.LeagueId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(league);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LeagueExists(league.LeagueId))
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
            return View(league);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var league = await _context.Leagues
                .FirstOrDefaultAsync(m => m.LeagueId == id);
            if (league == null)
            {
                return NotFound();
            }

            return View(league);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var league = await _context.Leagues.FindAsync(id);
            _context.Leagues.Remove(league);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LeagueExists(int id)
        {
            return _context.Leagues.Any(e => e.LeagueId == id);
        }
        private bool LeagueNameExists(string ligueName)
        {
            return _context.Leagues.Any(e => e.Name == ligueName);
        }

        // TEAMS ====================================================================================================================================

        public async Task<IActionResult> AddTeam(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var league = await _context.Leagues.FindAsync(id.Value);
            if (league == null)
            {
                return NotFound();
            }

            var teamViewModel = new TeamViewModel
            {
                LeagueId = league.LeagueId,
                LeagueName = league.Name
            };

            return View(teamViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> AddTeam(TeamViewModel model)
        {
            if (ModelState.IsValid)
            {
                var team = await _converterHelper.ToTeamAsync(model, true);
                _context.Teams.Add(team);
                await _context.SaveChangesAsync();
                return RedirectToAction($"Details/{model.LeagueId}");
            }
            
            return View(model);
        }

        public async Task<IActionResult> EditTeam(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var team = await _context.Teams
                .Include(p => p.League)
                .FirstOrDefaultAsync(p => p.TeamId == id);
            if (team == null)
            {
                return NotFound();
            }

            return View(_converterHelper.ToTeamViewModel(team));
        }

        [HttpPost]
        public async Task<IActionResult> EditTeam(TeamViewModel model)
        {
            if (ModelState.IsValid)
            {
                var team = await _converterHelper.ToTeamAsync(model, false);
                _context.Teams.Update(team);
                await _context.SaveChangesAsync();
                return RedirectToAction($"Details/{model.LeagueId}");
            }
            
            return View(model);
        }

        public async Task<IActionResult> DeleteTeam(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var team = await _context.Teams.Include(p => p.League)
                .FirstOrDefaultAsync(h => h.TeamId == id.Value);
            if (team == null)
            {
                return NotFound();
            }

            _context.Teams.Remove(team);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> DeleteLeague(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var league = await _context.Leagues.Include(p => p.Teams)
                .FirstOrDefaultAsync(h => h.LeagueId == id.Value);
            if (league == null)
            {
                return NotFound();
            }

            if (league.Teams.Count > 0)
            {
                ModelState.AddModelError(string.Empty, "La liga no puede ser borrada porque tiene equipos registrados.");
                return RedirectToAction($"{nameof(Details)}/{league.LeagueId}");
            }

            _context.Leagues.Remove(league);
            await _context.SaveChangesAsync();
            return RedirectToAction($"{nameof(Details)}/{league.LeagueId}");
        }
    }
}
