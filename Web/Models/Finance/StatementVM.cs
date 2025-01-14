using DbLayer.Models.Finance;
using DbLayer.Models.Patient;
using DbLayer.Models.Settings;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Web.Models.Patient;

namespace Web.Models.Finance
{
	public class StatementVM
	{
		/// <summary>
		/// Primary key
		/// </summary>
		public int? StatementId { get; set; }


		//----- Foriegn keys ----------

		/// <summary>
		/// User's universal unique id from Patient
		/// </summary>
		[Required]
		public string PatientUuid { get; set; } = string.Empty;

		/// <summary>
		/// Status id - PK from OsStatus
		/// </summary>
		public int? StatusId { get; set; }

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

		public string? AddedByName { get; set; }

		public string? UpdatedByName { get; set; }


		//------ System props ----------

		public string? AddedById { get; set; }

		public string? UpdatedById { get; set; }

		public DateTime? AddedDate { get; set; }

		public DateTime? UpdatedDate { get; set; }

		public bool IsActive { get; set; }


		//----- Foriegn key objects --------- 

		public PatientVM? Patient { get; set; }

		public OsStatus? OsStatus { get; set; }

		//------------------------------------

		public ICollection<StatementItemVM>? Items { get; set; }
	}
}
