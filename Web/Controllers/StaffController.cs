using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
	public class StaffController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}

		public IActionResult Details()
		{
			return View();
		}
	}
}
