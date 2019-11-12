using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyPersonalWeb.Web.Data;
using MyPersonalWeb.Web.Data.Entities;

namespace MyPersonalWeb.Web.Controllers
{
    [Authorize(Roles = "Admin")]
    public class UserManagersController : Controller
    {
        private readonly DataContext _context;

        public UserManagersController(DataContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View(_context.UserManagers.Include(u => u.User));
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userManager = await _context.UserManagers
                .FirstOrDefaultAsync(m => m.Id == id);
            if (userManager == null)
            {
                return NotFound();
            }

            return View(userManager);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id")] UserManager userManager)
        {
            if (ModelState.IsValid)
            {
                _context.Add(userManager);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(userManager);
        }
        
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userManager = await _context.UserManagers.FindAsync(id);
            if (userManager == null)
            {
                return NotFound();
            }
            return View(userManager);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id")] UserManager userManager)
        {
            if (id != userManager.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(userManager);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserManagerExists(userManager.Id))
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
            return View(userManager);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userManager = await _context.UserManagers
                .FirstOrDefaultAsync(m => m.Id == id);
            if (userManager == null)
            {
                return NotFound();
            }

            return View(userManager);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var userManager = await _context.UserManagers.FindAsync(id);
            _context.UserManagers.Remove(userManager);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UserManagerExists(int id)
        {
            return _context.UserManagers.Any(e => e.Id == id);
        }
    }
}
