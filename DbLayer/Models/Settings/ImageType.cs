using DbLayer.Models.Patient;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DbLayer.Helper;

namespace DbLayer.Models.Settings
{
	public class ImageType : IAuditCurrent
	{
		/// <summary>
		/// Primary key
		/// </summary>
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int ImageTypeId { get; set; }

		/// <summary>
		/// Image type name
		/// </summary>
		public string TypeName { get; set; } = string.Empty;

		/// <summary>
		/// Description of image type
		/// </summary>
		public string? Description { get; set; }

		/// <summary>
		/// Any comments about the disease
		/// </summary>
		public string? Comments { get; set; }


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

		public bool IsActive { get; set; } = true;

		//--------------------------------- 

		public virtual User AddedBy { get; set; }

		public virtual User UpdatedBy { get; set; }

	}
}
