using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UI.Models.KYC;
using UI.Services;

namespace UI.Controllers.KYC
{
    public class KnowledgeCodesController : Controller
    {
        #region Fields

        private readonly ApplicationDbContext _context;

        #endregion Fields

        #region Constructor

        public KnowledgeCodesController(ApplicationDbContext context)
        {
            _context = context;
        }

        #endregion Constructor

        #region Actions

        public ActionResult Index()
        {
            var knowledgeCodes = _context.KnowledgeCodes.OrderByDescending(p => p.Id).ToList();
            return View(knowledgeCodes);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(KnowledgeCode model)
        {
            if (ModelState.IsValid)
            {
                _context.KnowledgeCodes.Add(model);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(model);
        }

        public ActionResult Edit(int id)
        {
            var knowledgeCode = _context.KnowledgeCodes.Find(id);
            if (knowledgeCode == null)
            {
                return NotFound();
            }
            return View(knowledgeCode);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(KnowledgeCode model)
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
            var knowledgeCode = _context.KnowledgeCodes.Find(id);
            if (knowledgeCode == null)
            {
                return NotFound();
            }
            return View(knowledgeCode);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult ConfirmDelete(int id)
        {
            var knowledgeCode = _context.KnowledgeCodes.Find(id);
            if (knowledgeCode != null)
            {
                _context.KnowledgeCodes.Remove(knowledgeCode);
                _context.SaveChanges();
            }
            return RedirectToAction("Index", "KnowledgeCodes");
        }

        #endregion Actions
    }
}