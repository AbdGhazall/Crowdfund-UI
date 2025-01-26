using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UI.Models.KYC;
using UI.Services;

namespace UI.Controllers.KYC
{
    public class SourceOfWealthesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SourceOfWealthesController(ApplicationDbContext context)
        {
            _context = context;
        }

        public ActionResult Index()
        {
            var sourcesOfWealth = _context.SourceOfWealths.OrderByDescending(s => s.Id).ToList();
            return View(sourcesOfWealth);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(SourceOfWealth model)
        {
            if (ModelState.IsValid)
            {
                _context.SourceOfWealths.Add(model);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(model);
        }

        public ActionResult Edit(int id)
        {
            var sourceOfWealth = _context.SourceOfWealths.Find(id);
            if (sourceOfWealth == null)
            {
                return NotFound();
            }
            return View(sourceOfWealth);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(SourceOfWealth model)
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
            var sourceOfWealth = _context.SourceOfWealths.Find(id);
            if (sourceOfWealth == null)
            {
                return NotFound();
            }
            return View(sourceOfWealth);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult ConfirmDelete(int id)
        {
            var sourceOfWealth = _context.SourceOfWealths.Find(id);
            if (sourceOfWealth != null)
            {
                _context.SourceOfWealths.Remove(sourceOfWealth);
                _context.SaveChanges();
            }
            return RedirectToAction("Index", "SourceOfWealthes");
        }
    }
}
