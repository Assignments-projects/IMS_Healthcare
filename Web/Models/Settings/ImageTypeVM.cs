using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Web.Models.Image;

namespace Web.Models.Settings
{
	public class ImageTypeVM
	{
		/// <summary>
		/// Primary key
		/// </summary>
		public int? ImageTypeId       { get; set; }

		/// <summary>
		/// Image type name
		/// </summary>
		[Required]
		public string TypeName       { get; set; } = string.Empty;

		/// <summary>
		/// Description of image type
		/// </summary>
		public string? Description   { get; set; }

		/// <summary>
		/// Any comments about the disease
		/// </summary>
		public string? Comments      { get; set; }

		//------ Additional props --------

		public string? AddedByName { get; set; }

		public string? UpdatedByName { get; set; }

		// ------ System props ----------

		public string? AddedById     { get; set; }

		public string? UpdatedById   { get; set; }

		public DateTime? AddedDate   { get; set; }

		public DateTime? UpdatedDate { get; set; }

		public bool IsActive         { get; set; } = true;

		// -----------------------------

		public ICollection<ImageVM>? Images { get; set; }

	}
}
