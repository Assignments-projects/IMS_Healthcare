using System.Web.Mvc;

namespace Web.Models.Finance
{
	public class StatementDetailsVM
	{
		public StatementDetailsVM()
		{
			Details       = new StatementVM();
			PatientList   = new List<SelectListItem>();
			StatusList    = new List<SelectListItem>();
			StatementList = new List<SelectListItem>();
		}

		public bool FromPatient { get; set; } = false;

		public bool IsStatusChange { get; set; } = false;

		/// <summary>
		/// Statement details obj
		/// </summary>
		public StatementVM Details { get; set; }

		/// <summary>
		/// Patients list from registration for select picker
		/// </summary>
		public List<SelectListItem> PatientList { get; set; }

		/// <summary>
		/// Status list for select picker
		/// </summary>
		public List<SelectListItem> StatusList { get; set; }

		/// <summary>
		/// Statement list for select picker
		/// </summary>
		public List<SelectListItem> StatementList { get; set; }

	}
}
