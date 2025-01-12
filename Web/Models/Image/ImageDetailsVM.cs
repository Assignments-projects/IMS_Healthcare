using System.Web.Mvc;
using Web.Models.Image;

namespace Web.Models.Image
{
	public class ImageDetailsVM
	{
		public ImageDetailsVM()
		{
			Details         = new ImageVM();
			List            = new List<ImageVM>();
			ImageTypeList   = new List<SelectListItem>();
			DiseaseList     = new List<SelectListItem>();
		}

		/// <summary>
		/// Image details obj
		/// </summary>
		public ImageVM Details { get; set; }

		/// <summary>
		/// Image details obj list 
		/// </summary>
		public List<ImageVM> List { get; set; }

		/// <summary>
		/// Image file details
		/// </summary>
		public IFormFile File { get; set; }

		/// <summary>
		/// Image type list for select picker
		/// </summary>
		public List<SelectListItem> ImageTypeList { get; set; }

		/// <summary>
		/// Patients list from registration for select picker
		/// </summary>
		public List<SelectListItem> DiseaseList { get; set; }
	}
}
