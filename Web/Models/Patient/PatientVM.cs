using DbLayer.Models.Patient;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Web.Models.Staff;
using Web.Models.Account;

namespace Web.Models.Patient
{
	public class PatientVM
	{

		/// <summary>
		/// Primary key
		/// </summary>
		public int? PateintId { get; set; }


		//----- Foriegn keys ----------

		/// <summary>
		/// User's universal unique id from - Identity user
		/// </summary>
		[Required]
		public string PatientUuid { get; set; } = string.Empty;

		/// <summary>
		/// Doctor any staff who is incharge of the patient uuid
		/// </summary>
		public string? InChargeuUud { get; set; }

		//-------------------------------

		/// <summary>
		/// First name of the Patient
		/// </summary>
		public string? FirstName { get; set; }

		/// <summary>
		/// Last name of the Patient
		/// </summary>
		public string? LastName { get; set; }

		/// <summary>
		/// Full name of the Patient
		/// </summary>
		public string? FullName { get { return $"{FirstName ?? ""} {LastName ?? ""}"; } }

		/// <summary>
		/// Patient street address
		/// </summary>
		public string? Address { get; set; }

		/// <summary>
		/// Patient phone number
		/// </summary>
		public string? PhoneNo { get; set; }

		/// <summary>
		/// Patient street address
		/// </summary>
		public string? Gender { get; set; }

		/// <summary>
		/// Patient phone number
		/// </summary>
		public DateTime? DateOfBirth { get; set; }

		/// <summary>
		/// National Identity no
		/// </summary>
		public string? IdentityNo { get; set; }

		/// <summary>
		/// Ward Number if admittied
		/// </summary>
		public string? WardNo { get; set; }

		/// <summary>
		/// Any comments about the patient
		/// </summary>
		public string? Comments { get; set; }

		/// <summary>
		/// Cost of the patient
		/// </summary>
		public decimal? TotalCost { get; set; }

		/// <summary>
		/// Is the patient disharged ?
		/// </summary>
		public bool IsDischarged { get; set; }


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

		public UserVM? User { get; set; }

		public StaffVM? Staff { get; set; }

		//----------------------------------

	}
}
