using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UI.Models;
using UI.Services;

namespace UI.Controllers
{
    public class ExpectedTransactionPerMonthRangesController : Controller
    {
        #region Fields
        private readonly ApplicationDbContext _context;
        #endregion

        #region Constructor
        public ExpectedTransactionPerMonthRangesController(ApplicationDbContext context)
        {
            _context = context;
        }
        #endregion

        #region Actions
        public ActionResult Index()
        {
            var ranges = _context.ExpectedTransactionPerMonthRanges.OrderByDescending(p => p.Id).ToList();
            return View(ranges);
        }

        
        public ActionResult Create()
        {
            return View();
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ExpectedTransactionPerMonthRange model)
        {
            if (ModelState.IsValid)
            {
                _context.ExpectedTransactionPerMonthRanges.Add(model);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(model);
        }

        
        public ActionResult Edit(int id)
        {
            var range = _context.ExpectedTransactionPerMonthRanges.Find(id);
            if (range == null)
            {
                return NotFound();
            }
            return View(range);
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ExpectedTransactionPerMonthRange model)
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
            var range = _context.ExpectedTransactionPerMonthRanges.Find(id);
            if (range == null)
            {
                return NotFound();
            }
            return View(range);
        }

        
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult ConfirmDelete(int id)
        {
            var range = _context.ExpectedTransactionPerMonthRanges.Find(id);
            if (range != null)
            {
                _context.ExpectedTransactionPerMonthRanges.Remove(range);
                _context.SaveChanges();
            }
            return RedirectToAction("Index", "ExpectedTransactionPerMonthRanges");
        }
        #endregion
    }
}

