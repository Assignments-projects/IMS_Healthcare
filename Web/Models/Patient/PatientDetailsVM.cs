using System.Web.Mvc;
using Web.Models.Staff;

namespace Web.Models.Patient
{
	public class PatientDetailsVM
	{
		public PatientDetailsVM()
		{
			Details   = new PatientVM();
			List      = new List<PatientVM>();
			UsersList = new List<SelectListItem>();
			StaffList = new List<SelectListItem>();
		}

		/// <summary>
		/// Patient details obj
		/// </summary>
		public PatientVM Details { get; set; }

		/// <summary>
		/// Patient details obj list 
		/// </summary>
		public List<PatientVM> List { get; set; }

		/// <summary>
		/// Users list from registration for select picker
		/// </summary>
		public List<SelectListItem> UsersList { get; set; }

		/// <summary>
		/// Staffs list for select picker
		/// </summary>
		public List<SelectListItem> StaffList { get; set; }
	}
}
