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
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ApplicationDbContext _context;

        public UsersController(UserManager<ApplicationUser> userManager, ApplicationDbContext context)
        {
            _userManager = userManager;
            _context = context;
        }

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
                    InvestorTypeId = model.InvestorTypeId // Store selected Investor Type
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
            var user = await _userManager.FindByIdAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            // Pass the lists for dropdowns
            ViewBag.PlacesOfBirth = new SelectList(_context.Countries, "Id", "Name", user.PlaceOfBirthId);
            ViewBag.SocialStatuses = new SelectList(_context.SocialStatuses, "Id", "Name", user.SocialStatusId);
            ViewBag.InvestorTypes = new SelectList(_context.InvestorTypeSetups, "Id", "InvestorType", user.InvestorTypeId);

            return View(user);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, ApplicationUser model)
        {
            if (!ModelState.IsValid)
            {
                // Repopulate dropdown lists in case of errors
                ViewBag.PlacesOfBirth = new SelectList(_context.Countries, "Id", "Name", model.PlaceOfBirthId);
                ViewBag.SocialStatuses = new SelectList(_context.SocialStatuses, "Id", "Name", model.SocialStatusId);
                ViewBag.InvestorTypes = new SelectList(_context.InvestorTypeSetups, "Id", "InvestorType", model.InvestorTypeId);

                return View(model);
            }

            var user = await _userManager.FindByIdAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            // Update the user object
            user.UserName = model.UserName;
            user.Email = model.Email;
            user.PhoneNumber = model.PhoneNumber;
            user.BirthDate = model.BirthDate;
            user.CivilId = model.CivilId;
            user.PACIId = model.PACIId;
            user.IsClassified = model.IsClassified;
            user.PlaceOfBirthId = model.PlaceOfBirthId;
            user.SocialStatusId = model.SocialStatusId;
            user.InvestorTypeId = model.InvestorTypeId;

            var result = await _userManager.UpdateAsync(user);
            if (result.Succeeded)
            {
                return RedirectToAction("Index");
            }
            else
            {
                // If update fails, add errors to ModelState and repopulate dropdowns
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }

                // Repopulate dropdown lists in case of errors
                ViewBag.PlacesOfBirth = new SelectList(_context.Countries, "Id", "Name", model.PlaceOfBirthId);
                ViewBag.SocialStatuses = new SelectList(_context.SocialStatuses, "Id", "Name", model.SocialStatusId);
                ViewBag.InvestorTypes = new SelectList(_context.InvestorTypeSetups, "Id", "InvestorType", model.InvestorTypeId);

                return View(model);
            }
        }
    }
}