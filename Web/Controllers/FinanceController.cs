using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
	public class FinanceController : BaseController
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
