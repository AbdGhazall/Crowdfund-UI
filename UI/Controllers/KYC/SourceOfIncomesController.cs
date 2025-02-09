using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UI.Models.KYC;
using UI.Services;

namespace UI.Controllers.KYC
{
    public class SourceOfIncomesController : Controller
    {
        #region fields

        private readonly ApplicationDbContext _context;

        #endregion fields

        #region constructor

        public SourceOfIncomesController(ApplicationDbContext context)
        {
            _context = context;
        }

        #endregion constructor

        #region actions

        public ActionResult Index()
        {
            var sourcesOfIncome = _context.SourceOfIncomes.OrderByDescending(s => s.Id).ToList();
            return View(sourcesOfIncome);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(SourceOfIncome model)
        {
            if (ModelState.IsValid)
            {
                _context.SourceOfIncomes.Add(model);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(model);
        }

        public ActionResult Edit(int id)
        {
            var sourceOfIncome = _context.SourceOfIncomes.Find(id);
            if (sourceOfIncome == null)
            {
                return NotFound();
            }
            return View(sourceOfIncome);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(SourceOfIncome model)
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
            var sourceOfIncome = _context.SourceOfIncomes.Find(id);
            if (sourceOfIncome == null)
            {
                return NotFound();
            }
            return View(sourceOfIncome);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult ConfirmDelete(int id)
        {
            var sourceOfIncome = _context.SourceOfIncomes.Find(id);
            if (sourceOfIncome != null)
            {
                _context.SourceOfIncomes.Remove(sourceOfIncome);
                _context.SaveChanges();
            }
            return RedirectToAction("Index", "SourceOfIncomes");
        }

        #endregion actions
    }
}