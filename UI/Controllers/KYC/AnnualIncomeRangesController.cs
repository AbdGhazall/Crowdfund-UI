using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UI.Models.KYC;
using UI.Services;

namespace UI.Controllers.KYC
{
    public class AnnualIncomeRangesController : Controller
    {
        #region Fields
        private readonly ApplicationDbContext _context;
        #endregion

        #region Constructor
        public AnnualIncomeRangesController(ApplicationDbContext context)
        {
            _context = context;
        }
        #endregion

        #region Actions
        public ActionResult Index()
        {
            var annualIncomeRanges = _context.AnnualIncomeRanges.OrderByDescending(p => p.Id).ToList();
            return View(annualIncomeRanges);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(AnnualIncomeRange model)
        {
            if (ModelState.IsValid)
            {
                _context.AnnualIncomeRanges.Add(model);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(model);
        }

        public ActionResult Edit(int id)
        {
            var annualIncomeRange = _context.AnnualIncomeRanges.Find(id);
            if (annualIncomeRange == null)
            {
                return NotFound();
            }
            return View(annualIncomeRange);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(AnnualIncomeRange model)
        {
            if (ModelState.IsValid)
            {
                _context.Entry(model).State = EntityState.Modified;
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(model);
        }

        public ActionResult Delete(int id)
        {
            var annualIncomeRange = _context.AnnualIncomeRanges.Find(id);
            if (annualIncomeRange == null)
            {
                return NotFound();
            }
            return View(annualIncomeRange);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult ConfirmDelete(int id)
        {
            var annualIncomeRange = _context.AnnualIncomeRanges.Find(id);
            if (annualIncomeRange != null)
            {
                _context.AnnualIncomeRanges.Remove(annualIncomeRange);
                _context.SaveChanges();
            }
            return RedirectToAction("Index", "AnnualIncomeRanges");
        }
        #endregion
    }
}

