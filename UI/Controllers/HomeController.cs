using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using UI.Models;
using UI.Models.ViewModels;

namespace UI.Controllers
{
    public class HomeController : Controller
    {
        #region fields

        private readonly ILogger<HomeController> _logger;

        #endregion fields

        #region ctor

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        #endregion ctor

        #region actions

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        #endregion actions
    }
}