using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
	public class PatientController : BaseController
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
