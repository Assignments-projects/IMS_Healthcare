using System.Web.Mvc;
using Web.Models.Disease;

namespace Web.Models.Disease
{
	public class DiseaseDetailsVM
	{
		public DiseaseDetailsVM()
		{
			Details         = new DiseaseVM();
			List            = new List<DiseaseVM>();
			DiseaseTypeList = new List<SelectListItem>();
			PatientList     = new List<SelectListItem>();
			StaffList       = new List<SelectListItem>();
		}

		/// <summary>
		/// Disease details obj
		/// </summary>
		public DiseaseVM Details { get; set; }

		/// <summary>
		/// Disease details obj list 
		/// </summary>
		public List<DiseaseVM> List { get; set; }

		/// <summary>
		/// Disease type list for select picker
		/// </summary>
		public List<SelectListItem> DiseaseTypeList { get; set; }

		/// <summary>
		/// Patients list from registration for select picker
		/// </summary>
		public List<SelectListItem> PatientList { get; set; }

		/// <summary>
		/// Staffs list for select picker
		/// </summary>
		public List<SelectListItem> StaffList { get; set; }
	}
}
