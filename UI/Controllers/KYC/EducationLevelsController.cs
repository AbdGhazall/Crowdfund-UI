using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UI.Models.KYC;
using UI.Services;

namespace UI.Controllers.KYC
{
    public class EducationLevelsController : Controller
    {
        #region Fields
        private readonly ApplicationDbContext _context;
        #endregion

        #region Constructor
        public EducationLevelsController(ApplicationDbContext context)
        {
            _context = context;
        }
        #endregion

        #region Actions
        public ActionResult Index()
        {
            var educationLevels = _context.EducationLevels.OrderByDescending(p => p.Id).ToList();
            return View(educationLevels);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(EducationLevel model)
        {
            if (ModelState.IsValid)
            {
                _context.EducationLevels.Add(model);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(model);
        }

        public ActionResult Edit(int id)
        {
            var educationLevel = _context.EducationLevels.Find(id);
            if (educationLevel == null)
            {
                return NotFound();
            }
            return View(educationLevel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(EducationLevel model)
        {
            if (ModelState.IsValid)
            {
                _context.Entry(model).State = EntityState.Modified; // Update the entity
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(model);
        }

        public ActionResult Delete(int id)
        {
            var educationLevel = _context.EducationLevels.Find(id);
            if (educationLevel == null)
            {
                return NotFound();
            }
            return View(educationLevel);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult ConfirmDelete(int id)
        {
            var educationLevel = _context.EducationLevels.Find(id);
            if (educationLevel != null)
            {
                _context.EducationLevels.Remove(educationLevel);
                _context.SaveChanges();
            }
            return RedirectToAction("Index", "EducationLevels");
        }
        #endregion
    }
}

