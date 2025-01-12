using System.ComponentModel.DataAnnotations;
using Web.Models.Patient;
using Web.Models.Settings;
using Web.Models.Staff;

namespace Web.Models.Disease
{
	public class DiseaseVM
	{
		/// <summary>
		/// Primary key
		/// </summary>
		public int? DiseaseId { get; set; }


		//----- Foriegn keys ----------

		/// <summary>
		/// User's universal unique id from - Identity user
		/// </summary>
		[Required]
		public string PatientUuid { get; set; } = string.Empty;

		/// <summary>
		/// Disease type unique id
		/// </summary>
		[Required]
		public int DiseaseTypeId { get; set; }


		/// <summary>
		/// Staff unique id
		/// </summary>
		public string? DoctorId { get; set; }

		//-------------------------------

		/// <summary>
		/// Specification of disease
		/// </summary>
		[Required]
		public string DiseaseSpec { get; set; } = string.Empty;

		/// <summary>
		/// Any comments about the disease
		/// </summary>
		public string? Comments { get; set; }


		//------ Additional props ---------

		public string? AddedByName { get; set; }

		public string? UpdatedByName { get; set; }


		// ------ System props ----------

		public string? AddedById { get; set; }

		public string? UpdatedById { get; set; }

		public DateTime? AddedDate { get; set; }

		public DateTime? UpdatedDate { get; set; }

		public bool IsActive { get; set; }


		//----- Foriegn key objects --------- 

		public PatientVM? Patient { get; set; }

		public DiseaseTypeVM? DiseaseType { get; set; }

		public StaffVM? Doctor { get; set; }
	}
}
