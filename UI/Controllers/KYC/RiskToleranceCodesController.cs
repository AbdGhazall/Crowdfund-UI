using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UI.Models.KYC;
using UI.Services;

namespace UI.Controllers.KYC
{
    public class RiskToleranceCodesController : Controller
    {
        #region Fields
        private readonly ApplicationDbContext _context;
        #endregion

        #region Constructor
        public RiskToleranceCodesController(ApplicationDbContext context)
        {
            _context = context;
        }
        #endregion

        #region Actions
        public ActionResult Index()
        {
            var riskToleranceCodes = _context.RiskToleranceCodes.OrderByDescending(p => p.Id).ToList();
            return View(riskToleranceCodes);
        }


        public ActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(RiskToleranceCode model)
        {
            if (ModelState.IsValid)
            {
                _context.RiskToleranceCodes.Add(model);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(model);
        }


        public ActionResult Edit(int id)
        {
            var riskToleranceCode = _context.RiskToleranceCodes.Find(id);
            if (riskToleranceCode == null)
            {
                return NotFound();
            }
            return View(riskToleranceCode);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(RiskToleranceCode model)
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
            var riskToleranceCode = _context.RiskToleranceCodes.Find(id);
            if (riskToleranceCode == null)
            {
                return NotFound();
            }
            return View(riskToleranceCode);
        }


        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult ConfirmDelete(int id)
        {
            var riskToleranceCode = _context.RiskToleranceCodes.Find(id);
            if (riskToleranceCode != null)
            {
                _context.RiskToleranceCodes.Remove(riskToleranceCode);
                _context.SaveChanges();
            }
            return RedirectToAction("Index", "RiskToleranceCodes");
        }
        #endregion
    }
}

