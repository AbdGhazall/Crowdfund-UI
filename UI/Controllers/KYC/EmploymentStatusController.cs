using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UI.Models.KYC;
using UI.Services;

namespace UI.Controllers.KYC
{
    public class EmploymentStatusController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EmploymentStatusController(ApplicationDbContext context)
        {
            _context = context;
        }

        public ActionResult Index()
        {
            var employmentStatuses = _context.EmploymentStatuses.OrderByDescending(p => p.Id).ToList();
            return View(employmentStatuses);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(EmploymentStatus model)
        {
            if (ModelState.IsValid)
            {
                _context.EmploymentStatuses.Add(model);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(model);
        }

        public ActionResult Edit(int id)
        {
            var employmentStatus = _context.EmploymentStatuses.Find(id);
            if (employmentStatus == null)
            {
                return NotFound();
            }
            return View(employmentStatus);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(EmploymentStatus model)
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
            var employmentStatus = _context.EmploymentStatuses.Find(id);
            if (employmentStatus == null)
            {
                return NotFound();
            }
            return View(employmentStatus);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult ConfirmDelete(int id)
        {
            var employmentStatus = _context.EmploymentStatuses.Find(id);
            if (employmentStatus != null)
            {
                _context.EmploymentStatuses.Remove(employmentStatus);
                _context.SaveChanges();
            }
            return RedirectToAction("Index", "EmploymentStatus");
        }
    }
}