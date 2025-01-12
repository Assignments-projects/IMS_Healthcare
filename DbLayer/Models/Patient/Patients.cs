using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DbLayer.Helper;

namespace DbLayer.Models.Patient
{
	public class Patients : IAuditCurrent
	{
		/// <summary>
		/// Primary key
		/// </summary>
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int PateintId         { get; set; }


		//----- Foriegn keys ----------

		/// <summary>
		/// User's universal unique id from - Identity user
		/// </summary>
		[ForeignKey(nameof(User))]
		public string? PatientUuid      { get; set; }

		/// <summary>
		/// Doctor any staff who is incharge of the patient uuid
		/// </summary>
		[ForeignKey(nameof(Staff))]
		public string? InChargeuUud  { get; set; }

		//-------------------------------

		/// <summary>
		/// First name of the Patient
		/// </summary>
		public string FirstName      { get; set; } = string.Empty;

		/// <summary>
		/// Last name of the Patient
		/// </summary>
		public string LastName       { get; set; } = string.Empty;

		/// <summary>
		/// Patient street address
		/// </summary>
		public string? Address       { get; set; }

		/// <summary>
		/// Patient phone number
		/// </summary>
		public string? PhoneNo       { get; set; }

		/// <summary>
		/// Patient street address
		/// </summary>
		public string? Gender        { get; set; }

		/// <summary>
		/// Patient phone number
		/// </summary>
		public DateTime? DateOfBirth { get; set; }

		/// <summary>
		/// National Identity no
		/// </summary>
		public string? IdentityNo    { get; set; }

		/// <summary>
		/// Ward Number if admittied
		/// </summary>
		public string? WardNo { get; set; }

		/// <summary>
		/// Any comments about the patient
		/// </summary>
		public string? Comments      { get; set; }

		/// <summary>
		/// Cost of the patient
		/// </summary>
		public decimal? TotalCost    { get; set; }

		/// <summary>
		/// Is the patient disharged ?
		/// </summary>
		public bool IsDischarged     { get; set; }


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

		public virtual User User			 { get; set; }

		public virtual Staff Staff           { get; set; }

		public virtual User AddedBy { get; set; }

		public virtual User UpdatedBy { get; set; }

		//----------------------------------

		public virtual ICollection<Disease> Disease { get; set; }
	}
}
