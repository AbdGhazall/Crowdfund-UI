using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UI.Models.KYC;
using UI.Services;

namespace UI.Controllers.KYC
{
    public class RiskAgreementsController : Controller
    {
        #region Fields
        private readonly ApplicationDbContext _context;
        #endregion

        #region Constructor
        public RiskAgreementsController(ApplicationDbContext context)
        {
            _context = context;
        }
        #endregion

        #region Actions
        public ActionResult Index()
        {
            var riskAgreements = _context.RiskAgreements.OrderByDescending(p => p.Id).ToList();
            return View(riskAgreements);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(RiskAgreement model)
        {
            if (ModelState.IsValid)
            {
                _context.RiskAgreements.Add(model);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(model);
        }

        public ActionResult Edit(int id)
        {
            var riskAgreement = _context.RiskAgreements.Find(id);
            if (riskAgreement == null)
            {
                return NotFound();
            }
            return View(riskAgreement);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(RiskAgreement model)
        {
            if (ModelState.IsValid)
            {
                _context.Entry(model).State = EntityState.Modified; // Update entity
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(model);
        }

        public ActionResult Delete(int id)
        {
            var riskAgreement = _context.RiskAgreements.Find(id);
            if (riskAgreement == null)
            {
                return NotFound();
            }
            return View(riskAgreement);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult ConfirmDelete(int id)
        {
            var riskAgreement = _context.RiskAgreements.Find(id);
            if (riskAgreement != null)
            {
                _context.RiskAgreements.Remove(riskAgreement);
                _context.SaveChanges();
            }
            return RedirectToAction("Index", "RiskAgreements");
        }
        #endregion
    }
}

