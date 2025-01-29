using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UI.Models.KYC;
using UI.Services;

namespace UI.Controllers.KYC
{
    public class PurposeOfInvestmentCodesController : Controller
    {
        #region Fields

        private readonly ApplicationDbContext _context;

        #endregion Fields

        #region Constructor

        public PurposeOfInvestmentCodesController(ApplicationDbContext context)
        {
            _context = context;
        }

        #endregion Constructor

        #region Actions

        public ActionResult Index()
        {
            var purposeOfInvestmentCodes = _context.PurposeOfInvestmentCodes.OrderByDescending(p => p.Id).ToList();
            return View(purposeOfInvestmentCodes);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PurposeOfInvestmentCode model)
        {
            if (ModelState.IsValid)
            {
                _context.PurposeOfInvestmentCodes.Add(model);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(model);
        }

        public ActionResult Edit(int id)
        {
            var purposeOfInvestmentCode = _context.PurposeOfInvestmentCodes.Find(id);
            if (purposeOfInvestmentCode == null)
            {
                return NotFound();
            }
            return View(purposeOfInvestmentCode);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(PurposeOfInvestmentCode model)
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
            var purposeOfInvestmentCode = _context.PurposeOfInvestmentCodes.Find(id);
            if (purposeOfInvestmentCode == null)
            {
                return NotFound();
            }
            return View(purposeOfInvestmentCode);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult ConfirmDelete(int id)
        {
            var purposeOfInvestmentCode = _context.PurposeOfInvestmentCodes.Find(id);
            if (purposeOfInvestmentCode != null)
            {
                _context.PurposeOfInvestmentCodes.Remove(purposeOfInvestmentCode);
                _context.SaveChanges();
            }
            return RedirectToAction("Index", "PurposeOfInvestmentCodes");
        }

        #endregion Actions
    }
}