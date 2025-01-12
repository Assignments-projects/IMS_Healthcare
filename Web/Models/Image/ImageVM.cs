using System.ComponentModel.DataAnnotations;
using Web.Models.Account;
using Web.Models.Disease;
using Web.Models.Settings;

namespace Web.Models.Image
{
	public class ImageVM
	{
		/// <summary>
		/// Primary key
		/// </summary>
		public int? ImageId { get; set; }


		//----- Foriegn keys ----------

		/// <summary>
		/// Disease unique id
		/// </summary>
		[Required]
		public int ImageTypeId { get; set; }

		/// <summary>
		/// Disease unique id
		/// </summary>
		[Required]
		public int DiseaseId { get; set; }

		//-------------------------------

		/// <summary>
		/// Name of the file
		/// </summary>
		
		public string? FileName { get; set; }

		/// <summary>
		/// BLOB content of the file
		/// </summary>
		public byte[]? FileContent { get; set; }

		/// <summary>
		/// Mime type of the file
		/// </summary>
		public string? MimeType { get; set; }

		/// <summary>
		/// Image url
		/// </summary>
		public string? ImageUrl { get; set; }

		/// <summary>
		/// Condition about the Image
		/// </summary>
		public string? Condition { get; set; }

		/// <summary>
		/// Any comments about the Image
		/// </summary>
		public string? Comments { get; set; }


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

		public ImageTypeVM? ImageType { get; set; }

		public DiseaseVM? Disease { get; set; }

		//-----------------------------------
	}
}
