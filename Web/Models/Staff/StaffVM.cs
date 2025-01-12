using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Web.Models.Staff
{
	public class StaffVM
	{
		/// <summary>
		/// Primary key
		/// </summary>
		public int? StaffId { get; set; }


		//----- Foriegn keys ----------

		/// <summary>
		/// User's universal unique id from - Identity user
		/// </summary>
		[Required]
		public string StaffUuid { get; set; } =  string.Empty;

		//-----------------------------

		/// <summary>
		/// First name of the Staff
		/// </summary>
		public string? FirstName { get; set; }

		/// <summary>
		/// Last name of the Staff
		/// </summary>
		public string? LastName { get; set; }

		/// <summary>
		/// Full name of the Staff
		/// </summary>
		public string? FullName { get { return $"{FirstName ?? ""} {LastName ?? ""}"; } }

		/// <summary>
		/// Job of the staff
		/// </summary>
		[Required]
		public string Designation { get; set; } = string.Empty;

		/// <summary>
		/// Staff street address
		/// </summary>
		public string? Address { get; set; }

		/// <summary>
		/// Staff phone number
		/// </summary>
		public string? PhoneNo { get; set; }

		/// <summary>
		/// Staff street address
		/// </summary>
		public string? Gender { get; set; }

		/// <summary>
		/// Staff phone number
		/// </summary>
		public DateTime? DateOfBirth { get; set; }

		/// <summary>
		/// National Identity no
		/// </summary>
		public string? IdentityNo { get; set; }

		/// <summary>
		/// National Identity no
		/// </summary>
		public string? Educations { get; set; }

		/// <summary>
		/// Any comments about the Staff
		/// </summary>
		public string? Comments { get; set; }

		/// <summary>
		/// Cost of the Staff
		/// </summary>
		public decimal? Salary { get; set; }


		//------ Additional props ---------

		public string? AddedByName { get; set; }

		public string? UpdatedByName { get; set; }


		// ------ System props ----------

		public string? AddedById { get; set; }

		public string? UpdatedById { get; set; }

		public DateTime? AddedDate { get; set; }

		public DateTime? UpdatedDate { get; set; }

		public bool IsActive { get; set; }
	}
}
