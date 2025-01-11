using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ServiceLayer.Interfaces;
using System.Diagnostics;
using Web.Helper;
using Web.Models;
using Web.Models.Home;

namespace Web.Controllers
{
    public class HomeController : BaseController
	{
        private readonly ILogger<HomeController> _logger;
        private readonly IHomeService _home;
		private readonly IMapper _mapper;

		public HomeController(
            ILogger<HomeController> logger, 
            IHomeService home,
			IMapper mapper)
        {
            _logger = logger;
            _home   = home;
            _mapper = mapper;
        }

        /// <summary>
        /// Home index page dashboard
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> Index()
        {
            var result = await _home.DetailsAsync(UserHelper.GetCurrentUser());
            var model  = _mapper.Map<DashboardVM>(result);

			return View(model);
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
