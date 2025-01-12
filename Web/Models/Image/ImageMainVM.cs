using System.Web.Mvc;

namespace Web.Models.Image
{
	public class ImageMainVM
	{
		public ImageMainVM()
		{
				
		}

		/// <summary>
		/// Disease type list for select picker
		/// </summary>
		public List<SelectListItem> DiseaseTypeList { get; set; }



		/// <summary>
		/// Image type list for select picker
		/// </summary>
		public List<SelectListItem> ImageTypeList { get; set; }
	}
}
