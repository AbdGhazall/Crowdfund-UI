using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UI.Models.KYC;
using UI.Services;

namespace UI.Controllers.KYC
{
    public class DeclarationsController : Controller
    {
        #region Fields
        private readonly ApplicationDbContext _context;
        #endregion

        #region Constructor
        public DeclarationsController(ApplicationDbContext context)
        {
            _context = context;
        }
        #endregion

        #region Actions

        // Index Action - List all declarations
        public ActionResult Index()
        {
            var declarations = _context.Declarations.OrderByDescending(d => d.Id).ToList();
            return View(declarations);
        }

        // Create Action - Display the form to create a new declaration
        public ActionResult Create()
        {
            return View();
        }

        // Create Post Action - Save the new declaration to the database
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Declaration model)
        {
            if (ModelState.IsValid)
            {
                _context.Declarations.Add(model);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(model);
        }

        // Edit Action - Display the form to edit an existing declaration
        public ActionResult Edit(int id)
        {
            var declaration = _context.Declarations.Find(id);
            if (declaration == null)
            {
                return NotFound();
            }
            return View(declaration);
        }

        // Edit Post Action - Update the declaration data in the database
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Declaration model)
        {
            if (ModelState.IsValid)
            {
                _context.Entry(model).State = EntityState.Modified;
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(model);
        }

        // Delete Action - Display the confirmation view to delete a declaration
        public ActionResult Delete(int id)
        {
            var declaration = _context.Declarations.Find(id);
            if (declaration == null)
            {
                return NotFound();
            }
            return View(declaration);
        }

        // Delete Confirm Action - Delete the declaration from the database
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult ConfirmDelete(int id)
        {
            var declaration = _context.Declarations.Find(id);
            if (declaration != null)
            {
                _context.Declarations.Remove(declaration);
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        #endregion
    }
}

