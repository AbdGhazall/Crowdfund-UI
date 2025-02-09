using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using UI.Models;
using UI.Services;

namespace UI.Controllers
{
    public class UsersController : Controller
    {
        #region fields

        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ApplicationDbContext _context;

        #endregion fields

        #region ctor

        public UsersController(UserManager<ApplicationUser> userManager, ApplicationDbContext context)
        {
            _userManager = userManager;
            _context = context;
        }

        #endregion ctor

        #region actions

        public IActionResult Index()
        {
            var users = _context.Users
                .Include(u => u.PlaceOfBirth)
                .Include(u => u.SocialStatus)
                .Include(u => u.InvestorType)
                .OrderByDescending(p => p.Id)
                .ToList();
            return View(users);
        }

        public IActionResult Create()
        {
            ViewBag.PlacesOfBirth = new SelectList(_context.Countries, "Id", "Name");
            ViewBag.SocialStatuses = new SelectList(_context.SocialStatuses, "Id", "Name");
            ViewBag.InvestorTypes = new SelectList(_context.InvestorTypeSetups, "Id", "InvestorType");

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser
                {
                    UserName = model.UserName,
                    Email = model.Email,
                    PhoneNumber = model.PhoneNumber,
                    BirthDate = model.BirthDate,
                    CivilId = model.CivilId,
                    PACIId = model.PACIId,
                    IsClassified = model.IsClassified,
                    PlaceOfBirthId = model.PlaceOfBirthId,
                    SocialStatusId = model.SocialStatusId,
<<<<<<< HEAD
                    InvestorTypeId = model.InvestorTypeId,// Store selected Investor Type
                    PasswordHash = model.Password
=======
                    InvestorTypeId = model.InvestorTypeId // Store selected Investor Type
                    PasswordHash= model.Password
>>>>>>> 225c841f35aba0e69523f0aa268a613885b7612b
                };

                var result = await _userManager.CreateAsync(user);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index");
                }
            }

            // Repopulate dropdown lists in case of errors
            ViewBag.PlacesOfBirth = new SelectList(_context.Countries, "Id", "Name", model.PlaceOfBirthId);
            ViewBag.SocialStatuses = new SelectList(_context.SocialStatuses, "Id", "Name", model.SocialStatusId);
            ViewBag.InvestorTypes = new SelectList(_context.InvestorTypeSetups, "Id", "InvestorType", model.InvestorTypeId);

            return View(model);
        }

        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _userManager.FindByIdAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            var model = new EditViewModel
            {
                Id = user.Id,
                UserName = user.UserName,
                Email = user.Email,
                PhoneNumber = user.PhoneNumber,
                BirthDate = user.BirthDate,
                PlaceOfBirthId = user.PlaceOfBirthId,
                SocialStatusId = user.SocialStatusId,
                InvestorTypeId = (int)user.InvestorTypeId
            };

            // Populate dropdowns
            ViewBag.PlacesOfBirth = new SelectList(_context.Countries, "Id", "Name", user.PlaceOfBirthId);
            ViewBag.SocialStatuses = new SelectList(_context.SocialStatuses, "Id", "Name", user.SocialStatusId);
            ViewBag.InvestorTypes = new SelectList(_context.InvestorTypeSetups, "Id", "InvestorType", user.InvestorTypeId);

            return View(model); // Return EditViewModel instead of ApplicationUser
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, EditViewModel model)
        {
            if (id != model.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByIdAsync(id);
                if (user == null)
                {
                    return NotFound();
                }

                // Update fields
                user.UserName = model.UserName;
                user.Email = model.Email;
                user.PhoneNumber = model.PhoneNumber;
                user.BirthDate = model.BirthDate;
                user.PlaceOfBirthId = model.PlaceOfBirthId;
                user.SocialStatusId = model.SocialStatusId;
                user.InvestorTypeId = model.InvestorTypeId;

                var result = await _userManager.UpdateAsync(user);
                if (result.Succeeded)
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                }
            }

            // Repopulate dropdowns in case of errors
            ViewBag.PlacesOfBirth = new SelectList(_context.Countries, "Id", "Name", model.PlaceOfBirthId);
            ViewBag.SocialStatuses = new SelectList(_context.SocialStatuses, "Id", "Name", model.SocialStatusId);
            ViewBag.InvestorTypes = new SelectList(_context.InvestorTypeSetups, "Id", "InvestorType", model.InvestorTypeId);

            return View(model);
        }

        // GET: Users/Delete/{id}
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _userManager.FindByIdAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        // POST: Users/ConfirmDelete/{id}
        [HttpPost, ActionName("ConfirmDelete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ConfirmDelete(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            var result = await _userManager.DeleteAsync(user);
            if (result.Succeeded)
            {
                return RedirectToAction(nameof(Index));
            }

            ModelState.AddModelError("", "Error deleting user");
            return View("Delete", user);
        }

        #endregion actions
    }
}
