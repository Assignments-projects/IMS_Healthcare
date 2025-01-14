using System.Web.Mvc;

namespace Web.Models.Finance
{
	public class ItemDetailsVM
	{
		public ItemDetailsVM()
		{
			ItemDetails = new StatementItemVM();
			DiseaseList = new List<SelectListItem>();
		}

		/// <summary>
		/// Statement details obj
		/// </summary>
		public StatementItemVM ItemDetails { get; set; }

		/// <summary>
		/// Disease list for select picker
		/// </summary>
		public List<SelectListItem> DiseaseList { get; set; }
	}
}
