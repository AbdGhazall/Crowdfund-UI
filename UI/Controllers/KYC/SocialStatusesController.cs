using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UI.Models.KYC;
using UI.Services;

namespace UI.Controllers.KYC
{
    public class SocialStatusesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SocialStatusesController(ApplicationDbContext context)
        {
            _context = context;
        }

        public ActionResult Index()
        {
            var socialStatuses = _context.SocialStatuses.OrderByDescending(s => s.Id).ToList();
            return View(socialStatuses);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(SocialStatus model)
        {
            if (ModelState.IsValid)
            {
                _context.SocialStatuses.Add(model);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(model);
        }

        public ActionResult Edit(int id)
        {
            var socialStatus = _context.SocialStatuses.Find(id);
            if (socialStatus == null)
            {
                return NotFound();
            }
            return View(socialStatus);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(SocialStatus model)
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
            var socialStatus = _context.SocialStatuses.Find(id);
            if (socialStatus == null)
            {
                return NotFound();
            }
            return View(socialStatus);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult ConfirmDelete(int id)
        {
            var socialStatus = _context.SocialStatuses.Find(id);
            if (socialStatus != null)
            {
                _context.SocialStatuses.Remove(socialStatus);
                _context.SaveChanges();
            }
            return RedirectToAction("Index", "SocialStatuses");
        }
    }
}

