using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using UI.Models;
using UI.Models.Users_KYC;
using UI.Models.ViewModels;
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
                    InvestorTypeId = model.InvestorTypeId,
                    PasswordHash = model.Password
                };

                var result = await _userManager.CreateAsync(user);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index");
                }
            }

            ViewBag.PlacesOfBirth = new SelectList(_context.Countries, "Id", "Name", model.PlaceOfBirthId);
            ViewBag.SocialStatuses = new SelectList(_context.SocialStatuses, "Id", "Name", model.SocialStatusId);
            ViewBag.InvestorTypes = new SelectList(_context.InvestorTypeSetups, "Id", "InvestorType", model.InvestorTypeId);

            return View(model);
        }




        public IActionResult Edit(string id)
        {
            var user = _context.Users
             .Include(u => u.PlaceOfBirth)
             .Include(u => u.SocialStatus)
             .Include(u => u.InvestorType)

             .FirstOrDefault(u => u.Id.Equals(id));

            if (user == null)
            {
                return NotFound();
            }

            //retrive with null always
            var employmentDetailsRecord = _context.EmploymentDetails
                .Where(e => e.UserId.Equals(id))
                .FirstOrDefault();



            var viewModel = new EditViewModel
            {
                Id = user.Id,
                Email = user.Email,
                UserName = user.UserName,
                PhoneNumber = user.PhoneNumber,
                BirthDate = user.BirthDate,
                PlaceOfBirthId = user.PlaceOfBirthId,
                SocialStatusId = user.SocialStatusId,
                InvestorTypeId = (int)user.InvestorTypeId,
                EmploymentDetails = employmentDetailsRecord //null



            };

            ViewBag.PlacesOfBirth = new SelectList(_context.Countries, "Id", "Name");
            ViewBag.SocialStatuses = new SelectList(_context.SocialStatuses, "Id", "Name");
            ViewBag.InvestorTypes = new SelectList(_context.InvestorTypeSetups, "Id", "Name");

            return View(viewModel);
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

            ViewBag.PlacesOfBirth = new SelectList(_context.Countries, "Id", "Name", model.PlaceOfBirthId);
            ViewBag.SocialStatuses = new SelectList(_context.SocialStatuses, "Id", "Name", model.SocialStatusId);
            ViewBag.InvestorTypes = new SelectList(_context.InvestorTypeSetups, "Id", "InvestorType", model.InvestorTypeId);

            return View(model);
        }




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