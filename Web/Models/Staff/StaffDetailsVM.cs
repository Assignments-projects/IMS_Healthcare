using System.Web.Mvc;

namespace Web.Models.Staff
{
	public class StaffDetailsVM
	{
		public StaffDetailsVM()
		{
			List      = new List<StaffVM>();
			Details   = new StaffVM();
			UsersList = new List<SelectListItem>();
		}

		/// <summary>
		/// Staff details obj
		/// </summary>
		public StaffVM Details { get; set; }

		/// <summary>
		/// Staff details obj list 
		/// </summary>
		public List<StaffVM> List { get; set; }

		/// <summary>
		/// Users list from registration for select picker
		/// </summary>
		public List<SelectListItem> UsersList { get; set; }
	}
}
