using DbLayer.Models.Settings;
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
	public class Image : IAuditCurrent
	{
		/// <summary>
		/// Primary key
		/// </summary>
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int ImageId           { get; set; }


		//----- Foriegn keys ----------

		/// <summary>
		/// Disease unique id
		/// </summary>
		[ForeignKey(nameof(ImageType))]
		public int ImageTypeId       { get; set; }

		/// <summary>
		/// Disease unique id
		/// </summary>
		[ForeignKey(nameof(Disease))]
		public int DiseaseId         { get; set; }

		/// <summary>
		/// Staff unique id
		/// </summary>
		[ForeignKey(nameof(Staff))]
		public string? StaffUuid { get; set; }

		//-------------------------------

		/// <summary>
		/// Name of the file
		/// </summary>
		public string FileName       { get; set; } = string.Empty;

		/// <summary>
		/// BLOB content of the file
		/// </summary>
		public byte[] FileContent    { get; set; } = new byte[0];

		/// <summary>
		/// Mime type of the file
		/// </summary>
		public string MimeType       { get; set; } = string.Empty;

		/// <summary>
		/// Condition about the Image
		/// </summary>
		public string? Condition     { get; set; }

		/// <summary>
		/// Any comments about the Image
		/// </summary>
		public string? Comments      { get; set; }


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

		public virtual ImageType ImageType   { get; set; }

		public virtual Disease Disease       { get; set; }

		public virtual Staff Staff           { get; set; }

		public virtual User AddedBy { get; set; }

		public virtual User UpdatedBy { get; set; }

		//-----------------------------------
	}
}
