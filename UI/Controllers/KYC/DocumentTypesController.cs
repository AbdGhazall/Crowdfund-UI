using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UI.Models.KYC;
using UI.Services;

namespace UI.Controllers.KYC
{
    public class DocumentTypesController : Controller
    {
        #region Fields
        private readonly ApplicationDbContext _context;
        #endregion

        #region Constructor
        public DocumentTypesController(ApplicationDbContext context)
        {
            _context = context;
        }
        #endregion

        #region Actions
        public ActionResult Index()
        {
            var documentTypes = _context.DocumentTypes.OrderByDescending(p => p.Id).ToList();
            return View(documentTypes);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(DocumentType model)
        {
            if (ModelState.IsValid)
            {
                _context.DocumentTypes.Add(model);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(model);
        }

        public ActionResult Edit(int id)
        {
            var documentType = _context.DocumentTypes.Find(id);
            if (documentType == null)
            {
                return NotFound();
            }
            return View(documentType);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(DocumentType model)
        {
            if (ModelState.IsValid)
            {
                _context.Entry(model).State = EntityState.Modified; // Update with new data
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(model);
        }

        public ActionResult Delete(int id)
        {
            var documentType = _context.DocumentTypes.Find(id);
            if (documentType == null)
            {
                return NotFound();
            }
            return View(documentType);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult ConfirmDelete(int id)
        {
            var documentType = _context.DocumentTypes.Find(id);
            if (documentType != null)
            {
                _context.DocumentTypes.Remove(documentType);
                _context.SaveChanges();
            }
            return RedirectToAction("Index", "DocumentTypes");
        }
        #endregion
    }
}

