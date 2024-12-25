using Microsoft.AspNetCore.Mvc;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Web.Controllers
{
	public class BaseController : Controller
	{
		/// <summary>
		/// Json Error retrun
		/// </summary>
		/// <param name="error"></param>
		/// <returns></returns>
		public JsonResult JsonError(string error)
		{
			return Json(new { success = false, message = error });
		}

		/// <summary>
		/// Json success return
		/// </summary>
		/// <param name="message"></param>
		/// <returns></returns>
		public JsonResult JsonSuccess(string message)
		{
			return Json(new { success = true, message = message });
		}
	}
}
