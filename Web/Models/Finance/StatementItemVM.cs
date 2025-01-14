using DbLayer.Models.Finance;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Web.Models.Disease;

namespace Web.Models.Finance
{
	public class StatementItemVM
	{
		/// <summary>
		/// Primary key
		/// </summary>
		public int? StatementItemId { get; set; }


		//----- Foriegn keys ----------

		/// <summary>
		/// Disease id - PK from disease
		/// </summary>
		[Required]
		public int DiseaseId { get; set; }


		/// <summary>
		/// statement id - PK from statement
		/// </summary>
		public int? StatementId { get; set; }


		//-------------------------------

		/// <summary>
		/// Any description about the statement
		/// </summary>
		public string? Description { get; set; }

		/// <summary>
		/// Cost of the statement item
		/// </summary>
		public decimal? TotalCost { get; set; }


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

		public DiseaseVM? Disease { get; set; }

		public StatementVM? Statement { get; set; }
	}
}
