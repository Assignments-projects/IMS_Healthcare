using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using DbLayer.Models.Patient;
using DbLayer.Helper;

namespace DbLayer.Models.Finance
{
	public class StatementItem : IAuditCurrent
	{
		/// <summary>
		/// Primary key
		/// </summary>
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int StatementItemId { get; set; }


		//----- Foriegn keys ----------

		/// <summary>
		/// Disease id - PK from disease
		/// </summary>
		[ForeignKey(nameof(Disease))]
		public int DiseaseId { get; set; }


		/// <summary>
		/// statement id - PK from statement
		/// </summary>
		[ForeignKey(nameof(Statement))]
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

		[NotMapped]
		public string? AddedByName { get; set; }

		[NotMapped]
		public string? UpdatedByName { get; set; }


		// ------ System props ----------

		public string? AddedById { get; set; }

		public string? UpdatedById { get; set; }

		public DateTime? AddedDate { get; set; }

		public DateTime? UpdatedDate { get; set; }

		public bool IsActive { get; set; }


		//----- Foriegn key objects --------- 

		public virtual Disease Disease { get; set; }

		public virtual Statement Statement { get; set; }

		public virtual User AddedBy { get; set; }

		public virtual User UpdatedBy { get; set; }

		//------------------------------------
	}
}
