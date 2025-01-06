using DbLayer.Models.Settings;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbLayer.Models.Patient
{
	public class Prescription
	{
		/// <summary>
		/// Primary key
		/// </summary>
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id                { get; set; }


		//----- Foriegn keys ----------

		/// <summary>
		/// Disease unique id
		/// </summary>
		[ForeignKey(nameof(Disease))]
		public int DiseaseId         { get; set; }

		//-------------------------------

		/// <summary>
		/// Specification of disease
		/// </summary>
		public string? Mediciense { get; set; }

		/// <summary>
		/// Description of prescription
		/// </summary>
		public string? Description   { get; set; }

		/// <summary>
		/// Any comments about the prescription
		/// </summary>
		public string? Comments      { get; set; }

		/// <summary>
		/// Cost of the Prescription
		/// </summary>
		public decimal? TotalCost { get; set; }


		// ------ System props ----------

		public string? AddedById     { get; set; }

		public string? UpdatedById   { get; set; }

		public DateTime? AddedDate   { get; set; }

		public DateTime? UpdatedDate { get; set; }

		public bool IsActive         { get; set; }


		//----- Foriegn key objects --------- 

		public Disease Disease       { get; set; }
	}
}
