using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using UI.Models.KYC;
using UI.Services;

namespace UI.Controllers.KYC
{
    public class QuestionnairesController : Controller
    {
        #region Fields

        private readonly ApplicationDbContext _context;

        #endregion Fields

        #region Constructor

        public QuestionnairesController(ApplicationDbContext context)
        {
            _context = context;
        }

        #endregion Constructor

        #region Actions

        public ActionResult Index()
        {
            var questionnaires = _context.Questionnaires.OrderByDescending(q => q.Id).ToList();
            return View(questionnaires);
        }

        public ActionResult Create()
        {
            ViewBag.QuestionTypes = Enum.GetValues(typeof(QuestionType))
                .Cast<QuestionType>()
                .Select(q => new SelectListItem
                {
                    Value = ((int)q).ToString(),
                    Text = q.GetDisplayName()
                });
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Questionnaire model)
        {
            if (ModelState.IsValid)
            {
                _context.Questionnaires.Add(model);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.QuestionTypes = Enum.GetValues(typeof(QuestionType))
                .Cast<QuestionType>()
                .Select(q => new SelectListItem
                {
                    Value = ((int)q).ToString(),
                    Text = q.GetDisplayName()
                });
            return View(model);
        }

        public ActionResult Edit(int id)
        {
            var questionnaire = _context.Questionnaires.Find(id);
            if (questionnaire == null)
            {
                return NotFound();
            }
            ViewBag.QuestionTypes = Enum.GetValues(typeof(QuestionType))
                .Cast<QuestionType>()
                .Select(q => new SelectListItem
                {
                    Value = ((int)q).ToString(),
                    Text = q.GetDisplayName()
                });
            return View(questionnaire);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Questionnaire model)
        {
            if (ModelState.IsValid)
            {
                _context.Entry(model).State = EntityState.Modified;
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.QuestionTypes = Enum.GetValues(typeof(QuestionType))
                .Cast<QuestionType>()
                .Select(q => new SelectListItem
                {
                    Value = ((int)q).ToString(),
                    Text = q.GetDisplayName()
                });
            return View(model);
        }

        public ActionResult Delete(int id)
        {
            var questionnaire = _context.Questionnaires.Find(id);
            if (questionnaire == null)
            {
                return NotFound();
            }
            return View(questionnaire);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult ConfirmDelete(int id)
        {
            var questionnaire = _context.Questionnaires.Find(id);
            if (questionnaire != null)
            {
                _context.Questionnaires.Remove(questionnaire);
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        #endregion Actions
    }
}