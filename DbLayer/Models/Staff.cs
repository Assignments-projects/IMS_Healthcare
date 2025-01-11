using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using DbLayer.Models.Patient;
using DbLayer.Helper;

namespace DbLayer.Models
{
	public class Staff : IAuditCurrent
	{
		/// <summary>
		/// Primary key
		/// </summary>
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int StaffId                { get; set; }


		//----- Foriegn keys ----------

		/// <summary>
		/// User's universal unique id from - Identity user
		/// </summary>
		[ForeignKey(nameof(User))]
		public string? StaffUuid      { get; set; }

		//-----------------------------

		/// <summary>
		/// First name of the Staff
		/// </summary>
		public string FirstName      { get; set; } = string.Empty;

		/// <summary>
		/// Last name of the Staff
		/// </summary>
		public string LastName       { get; set; } = string.Empty;

		/// <summary>
		/// Job of the staff
		/// </summary>
		public string Designation { get; set; } = string.Empty;

		/// <summary>
		/// Staff street address
		/// </summary>
		public string? Address       { get; set; }

		/// <summary>
		/// Staff phone number
		/// </summary>
		public string? PhoneNo       { get; set; }

		/// <summary>
		/// Staff street address
		/// </summary>
		public string? Gender        { get; set; }

		/// <summary>
		/// Staff phone number
		/// </summary>
		public DateTime? DateOfBirth { get; set; }

		/// <summary>
		/// National Identity no
		/// </summary>
		public string? IdentityNo    { get; set; }

		/// <summary>
		/// National Identity no
		/// </summary>
		public string? Educations    { get; set; }

		/// <summary>
		/// Any comments about the Staff
		/// </summary>
		public string? Comments      { get; set; }

		/// <summary>
		/// Cost of the Staff
		/// </summary>
		public decimal? Salary       { get; set; }


		//------ Additional props ---------

		[NotMapped]
		public string? AddedByName { get; set; }

		[NotMapped]
		public string? UpdatedByName { get; set; }


		// ------ System props ----------

		public string? AddedById     { get; set; }

		public string? UpdatedById   { get; set; }

		public DateTime? AddedDate   { get; set; }

		public DateTime? UpdatedDate { get; set; }

		public bool IsActive         { get; set; }

		//----- Foriegn key objects --------- 

		public User User { get; set; }

		//----------------------------------

		public virtual ICollection<Patients> Patient { get; set; }

		public virtual ICollection<Disease> Diseases { get; set; }

		public virtual ICollection<Image> Images { get; set; }

		public virtual User AddedBy { get; set; }

		public virtual User UpdatedBy { get; set; }

	}
}
