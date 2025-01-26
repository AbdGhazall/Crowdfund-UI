using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UI.Models.KYC;
using UI.Services;

namespace UI.Controllers.KYC
{
    public class InvestorTypeSetupController : Controller
    {
        private readonly ApplicationDbContext _context;

        public InvestorTypeSetupController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var investorTypes = _context.InvestorTypeSetups.OrderByDescending(x => x.CreatedDate).ToList();
            return View(investorTypes);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(InvestorTypeSetup model)
        {
            if (ModelState.IsValid)
            {
                _context.InvestorTypeSetups.Add(model);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(model);
        }

        public IActionResult Edit(string id)
        {
            var investorType = _context.InvestorTypeSetups.Find(id);
            if (investorType == null)
            {
                return NotFound();
            }
            return View(investorType);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(InvestorTypeSetup model)
        {
            if (ModelState.IsValid)
            {
                _context.Entry(model).State = EntityState.Modified;
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(model);
        }

        public IActionResult Delete(string id)
        {
            var investorType = _context.InvestorTypeSetups.Find(id);
            if (investorType == null)
            {
                return NotFound();
            }
            return View(investorType);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult ConfirmDelete(string id)
        {
            var investorType = _context.InvestorTypeSetups.Find(id);
            if (investorType != null)
            {
                _context.InvestorTypeSetups.Remove(investorType);
                _context.SaveChanges();
            }
            return RedirectToAction("Index", "InvestorTypeSetup");
        }
    }
}
