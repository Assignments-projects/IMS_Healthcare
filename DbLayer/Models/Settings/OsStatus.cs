using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using DbLayer.Helper;

namespace DbLayer.Models.Settings
{
	public class OsStatus 
	{
		/// <summary>
		/// Primary key
		/// </summary>
		[Key]
		public int StatusId { get; set; }

		//----- Foriegn keys ----------

		/// <summary>
		/// Section id - PK from OsSection
		/// </summary>
		[ForeignKey(nameof(OsSection))]
		public int SectionId { get; set; }

		//-------------------------------

		/// <summary>
		/// Image type name
		/// </summary>
		public string Status { get; set; } = string.Empty;

		/// <summary>
		/// Description of image type
		/// </summary>
		public string? Description { get; set; }


		public bool IsActive { get; set; } = true;


		//----- Foriegn key objects --------- 

		public virtual OsSection OsSection { get; set; }

		//------------------------------------
	}
}
