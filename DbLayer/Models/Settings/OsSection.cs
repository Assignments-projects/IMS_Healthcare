using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using DbLayer.Helper;

namespace DbLayer.Models.Settings
{
	public class OsSection
	{
		/// <summary>
		/// Primary key
		/// </summary>
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int SectionId { get; set; }

		/// <summary>
		/// Image type name
		/// </summary>
		public string Section { get; set; } = string.Empty;

		/// <summary>
		/// Description of image type
		/// </summary>
		public string? Description { get; set; }


		public bool IsActive { get; set; } = true;
	}
}
