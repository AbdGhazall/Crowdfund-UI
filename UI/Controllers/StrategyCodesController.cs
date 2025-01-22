using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UI.Models;
using UI.Services;

namespace UI.Controllers
{
    public class StrategyCodesController : Controller
    {
        #region Fields
        private readonly ApplicationDbContext _context;
        #endregion

        #region Constructor
        public StrategyCodesController(ApplicationDbContext context)
        {
            _context = context;
        }
        #endregion

        #region Actions
        public ActionResult Index()
        {
            var strategyCodes = _context.StrategyCodes.OrderByDescending(p => p.Id).ToList();
            return View(strategyCodes);
        }

        
        public ActionResult Create()
        {
            return View();
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(StrategyCode model)
        {
            if (ModelState.IsValid)
            {
                _context.StrategyCodes.Add(model);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(model);
        }

        
        public ActionResult Edit(int id)
        {
            var strategyCode = _context.StrategyCodes.Find(id);
            if (strategyCode == null)
            {
                return NotFound();
            }
            return View(strategyCode);
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(StrategyCode model)
        {
            if (ModelState.IsValid)
            {
                _context.Entry(model).State = EntityState.Modified; //edit old data with new data I sent.
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(model);
        }

        
        public ActionResult Delete(int id)
        {
            var strategyCode = _context.StrategyCodes.Find(id);
            if (strategyCode == null)
            {
                return NotFound();
            }
            return View(strategyCode);
        }

        
        [HttpPost, ActionName("Delete")] 
        [ValidateAntiForgeryToken]
        public ActionResult ConfirmDelete(int id)
        {
            var strategyCode = _context.StrategyCodes.Find(id);
            if (strategyCode != null)
            {
                _context.StrategyCodes.Remove(strategyCode);
                _context.SaveChanges();
            }
            return RedirectToAction("Index", "StrategyCodes");
        }
        #endregion
    }
}
