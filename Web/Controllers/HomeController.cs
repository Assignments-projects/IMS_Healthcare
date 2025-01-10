using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Web.Helper;
using Web.Models;

namespace Web.Controllers
{
    public class HomeController : BaseController
	{
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// Home index page dashboard
        /// </summary>
        /// <returns></returns>
        public IActionResult Index()
        {
            var currentUser = UserHelper.GetCurrentUser();
            return View();
        }

		/// <summary>
		/// Current user profile
		/// </summary>
		/// <returns></returns>
		public IActionResult Profile()
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
    }
}
