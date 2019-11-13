using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyPersonalWeb.Web.Data;
using MyPersonalWeb.Web.Data.Entities;
using MyPersonalWeb.Web.Helpers;
using MyPersonalWeb.Web.Models;

namespace MyPersonalWeb.Web.Controllers
{
    [Authorize(Roles = "Admin")]
    public class UserManagersController : Controller
    {
        private readonly DataContext _context;
        private readonly IUserHelper _userHelper;

        public UserManagersController(DataContext context, IUserHelper userHelper)
        {
            _context = context;
            _userHelper = userHelper;
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

            var userManager = await _context.UserManagers.Include(u => u.User)
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
        public async Task<IActionResult> Create(AddUserViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await AddUser(model);
                if (user == null)
                {
                    return View(model);
                }

                var userManager = new UserManager
                {
                    User = user,
                };

                _context.UserManagers.Add(userManager);
                try
                {
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError(string.Empty, ex.ToString());
                    return View(model);
                }
            }
            return View(model);
        }

        private async Task<User> AddUser(AddUserViewModel view)
        {
            var user = new User
            {
                Address = view.Address,
                Document = view.Document,
                Email = view.Username,
                FirstName = view.FirstName,
                LastName = view.LastName,
                PhoneNumber = view.PhoneNumber,
                UserName = view.Username
            };

            var result = await _userHelper.AddUserAsync(user, view.Password);
            if (result != IdentityResult.Success)
            {
                ModelState.AddModelError(string.Empty, result.Errors.FirstOrDefault().Description);
                return null;
            }

            var newUser = await _userHelper.GetUserByEmailAsync(view.Username);
            await _userHelper.AddUserToRoleAsync(newUser, "Admin");
            return newUser;
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

        public async Task<IActionResult> DeleteManagers(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _context.UserManagers.FirstOrDefaultAsync(h => h.Id == id.Value);
            if (user == null)
            {
                return NotFound();
            }

            _context.UserManagers.Remove(user);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
