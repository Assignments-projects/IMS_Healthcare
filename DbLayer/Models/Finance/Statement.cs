using DbLayer.Models.Patient;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using DbLayer.Models.Settings;
using DbLayer.Helper;

namespace DbLayer.Models.Finance
{
	public class Statement : IAuditCurrent
	{
		/// <summary>
		/// Primary key
		/// </summary>
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int StatementId { get; set; }


		//----- Foriegn keys ----------

		/// <summary>
		/// User's universal unique id from Patient
		/// </summary>
		[ForeignKey(nameof(Patient))]
		public string? PatientUuid { get; set; }

		/// <summary>
		/// Status id - PK from OsStatus
		/// </summary>
		[ForeignKey(nameof(OsStatus))]
		public int StatusId { get; set; }

		//-------------------------------

		/// <summary>
		/// Any description about the statement
		/// </summary>
		public string? Description { get; set; }

		/// <summary>
		/// Cost of the statement
		/// </summary>
		public decimal? TotalCost { get; set; }

		/// <summary>
		/// Is the the statement generated ?
		/// </summary>
		public bool IsGenerated { get; set; } = false;

		/// <summary>
		/// Is the the statement sent to patient ?
		/// </summary>
		public bool IsSent { get; set; } = false;

		//------ Additional props ---------

		[NotMapped]
		public string? AddedByName { get; set; }

		[NotMapped]
		public string? UpdatedByName { get; set; }


		//------ System props ----------

		public string? AddedById { get; set; }

		public string? UpdatedById { get; set; }

		public DateTime? AddedDate { get; set; }

		public DateTime? UpdatedDate { get; set; }

		public bool IsActive { get; set; }


		//----- Foriegn key objects --------- 

		public virtual Patients Patient { get; set; }

		public virtual OsStatus OsStatus { get; set; }

		public virtual User AddedBy { get; set; }

		public virtual User UpdatedBy { get; set; }

		//------------------------------------

		public virtual ICollection<StatementItem> Items { get; set; }

	}
}
