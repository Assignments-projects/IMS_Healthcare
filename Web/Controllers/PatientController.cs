using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
	public class PatientController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}

		public IActionResult Cost()
		{
			return View();
		}
	}
}
