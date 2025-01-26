using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UI.Models.KYC;
using UI.Services;

namespace UI.Controllers.KYC
{
    public class NetWorthRangesController : Controller
    {
        #region Fields
        private readonly ApplicationDbContext _context;
        #endregion

        #region Constructor
        public NetWorthRangesController(ApplicationDbContext context)
        {
            _context = context;
        }
        #endregion

        #region Actions
        public ActionResult Index()
        {
            var netWorthRanges = _context.NetWorthRanges.OrderByDescending(p => p.Id).ToList();
            return View(netWorthRanges);
        }


        public ActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(NetWorthRange model)
        {
            if (ModelState.IsValid)
            {
                _context.NetWorthRanges.Add(model);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(model);
        }


        public ActionResult Edit(int id)
        {
            var netWorthRanges = _context.NetWorthRanges.Find(id);
            if (netWorthRanges == null)
            {
                return NotFound();
            }
            return View(netWorthRanges);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(NetWorthRange model)
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
            var netWorthRanges = _context.NetWorthRanges.Find(id);
            if (netWorthRanges == null)
            {
                return NotFound();
            }
            return View(netWorthRanges);
        }


        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult ConfirmDelete(int id)
        {
            var netWorthranges = _context.NetWorthRanges.Find(id);
            if (netWorthranges != null)
            {
                _context.NetWorthRanges.Remove(netWorthranges);
                _context.SaveChanges();
            }
            return RedirectToAction("Index", "NetWorthRanges");
        }
        #endregion
    }
}
