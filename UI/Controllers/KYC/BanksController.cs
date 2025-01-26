using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UI.Models.KYC;
using UI.Services;

namespace UI.Controllers.KYC
{
    public class BanksController : Controller
    {
        private readonly ApplicationDbContext _context;

        public BanksController(ApplicationDbContext context)
        {
            _context = context;
        }

        // Index
        public IActionResult Index()
        {
            var banks = _context.Banks.OrderByDescending(b => b.Id).ToList();
            return View(banks);
        }

        // Create (GET)
        public IActionResult Create()
        {
            return View();
        }

        // Create (POST)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Bank model)
        {
            if (ModelState.IsValid)
            {
                _context.Banks.Add(model);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(model);
        }

        // Edit (GET)
        public IActionResult Edit(int id)
        {
            var bank = _context.Banks.Find(id);
            if (bank == null)
            {
                return NotFound();
            }
            return View(bank);
        }

        // Edit (POST)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Bank model)
        {
            if (ModelState.IsValid)
            {
                _context.Entry(model).State = EntityState.Modified;
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(model);
        }

        // Delete (GET)
        public IActionResult Delete(int id)
        {
            var bank = _context.Banks.Find(id);
            if (bank == null)
            {
                return NotFound();
            }
            return View(bank);
        }

        // Delete (POST)
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult ConfirmDelete(int id)
        {
            var bank = _context.Banks.Find(id);
            if (bank != null)
            {
                _context.Banks.Remove(bank);
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}
