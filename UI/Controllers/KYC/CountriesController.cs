using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UI.Models.KYC;
using UI.Services;

namespace UI.Controllers.KYC
{
    public class CountriesController : Controller
    {
        #region Fields

        private readonly ApplicationDbContext _context;

        #endregion Fields

        #region Constructor

        public CountriesController(ApplicationDbContext context)
        {
            _context = context;
        }

        #endregion Constructor

        #region Actions

        // Index Action - List all countries
        public ActionResult Index()
        {
            var countries = _context.Countries.OrderByDescending(c => c.Id).ToList();
            return View(countries);
        }

        // Create Action - Display the form to create a new country
        public ActionResult Create()
        {
            return View();
        }

        // Create Post Action - Save the new country to the database
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Country model)
        {
            if (ModelState.IsValid)
            {
                _context.Countries.Add(model);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(model);
        }

        // Edit Action - Display the form to edit an existing country
        public ActionResult Edit(int id)
        {
            var country = _context.Countries.Find(id);
            if (country == null)
            {
                return NotFound();
            }
            return View(country);
        }

        // Edit Post Action - Update the country data in the database
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Country model)
        {
            if (ModelState.IsValid)
            {
                _context.Entry(model).State = EntityState.Modified; // Update the country
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(model);
        }

        // Delete Action - Display the confirmation view to delete a country
        public ActionResult Delete(int id)
        {
            var country = _context.Countries.Find(id);
            if (country == null)
            {
                return NotFound();
            }
            return View(country);
        }

        // Delete Confirm Action - Delete the country from the database
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult ConfirmDelete(int id)
        {
            var country = _context.Countries.Find(id);
            if (country != null)
            {
                _context.Countries.Remove(country);
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        #endregion Actions
    }
}