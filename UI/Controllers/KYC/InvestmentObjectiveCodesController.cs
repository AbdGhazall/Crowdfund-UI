using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UI.Models.KYC;
using UI.Services;

namespace UI.Controllers.KYC
{
    public class InvestmentObjectiveCodesController : Controller
    {
        #region Fields
        private readonly ApplicationDbContext _context;
        #endregion

        #region Constructor
        public InvestmentObjectiveCodesController(ApplicationDbContext context)
        {
            _context = context;
        }
        #endregion

        #region Actions
        public ActionResult Index()
        {
            var investmentObjectiveCodes = _context.InvestmentObjectiveCodes.OrderByDescending(p => p.Id).ToList();
            return View(investmentObjectiveCodes);
        }


        public ActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(InvestmentObjectiveCode model)
        {
            if (ModelState.IsValid)
            {
                _context.InvestmentObjectiveCodes.Add(model);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(model);
        }


        public ActionResult Edit(int id)
        {
            var investmentObjectiveCode = _context.InvestmentObjectiveCodes.Find(id);
            if (investmentObjectiveCode == null)
            {
                return NotFound();
            }
            return View(investmentObjectiveCode);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(InvestmentObjectiveCode model)
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
            var investmentObjectiveCode = _context.InvestmentObjectiveCodes.Find(id);
            if (investmentObjectiveCode == null)
            {
                return NotFound();
            }
            return View(investmentObjectiveCode);
        }


        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult ConfirmDelete(int id)
        {
            var investmentObjectiveCode = _context.InvestmentObjectiveCodes.Find(id);
            if (investmentObjectiveCode != null)
            {
                _context.InvestmentObjectiveCodes.Remove(investmentObjectiveCode);
                _context.SaveChanges();
            }
            return RedirectToAction("Index", "InvestmentObjectiveCodes");
        }
        #endregion
    }
}

