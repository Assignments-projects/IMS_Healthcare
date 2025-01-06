using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DbLayer.Models.Patient;

namespace DbLayer.Models.Settings
{
	public class DiseaseType
	{
		/// <summary>
		/// Primary key
		/// </summary>
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int DiseaseTypeId { get; set; }

		/// <summary>
		/// Image type name
		/// </summary>
		public required string TypeName { get; set; }

		/// <summary>
		/// Description of disease type
		/// </summary>
		public string? Description { get; set; }

		/// <summary>
		/// Any comments about the disease type
		/// </summary>
		public string? Comments { get; set; }


		// ------ System props ----------

		public string? AddedById { get; set; }

		public string? UpdatedById { get; set; }

		public DateTime? AddedDate { get; set; }

		public DateTime? UpdatedDate { get; set; }

		public bool IsActive { get; set; }

		//--------------------------------- 

		public ICollection<Disease> Diseases { get; set; }
	}
}
