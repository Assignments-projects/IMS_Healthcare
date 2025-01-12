using DbLayer.Helpers;
using DbLayer.Models.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace ServiceLayer.Interfaces.Settings
{
	public interface IImageTypeService
	{
		/// <summary>
		/// Load image type list
		/// </summary>
		/// <returns></returns>
		Task<List<ImageType>> ListAsync();

		/// <summary>
		/// Get image type details by user uuid
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		Task<ImageType> DetailsAsync(int id);

		/// <summary>
		/// Add image type to the database
		/// </summary>
		/// <param name="model"></param>
		/// <returns></returns>
		Task<string> AddAsync(ImageType model, ICurrentUser user);

		/// <summary>
		/// Update image type record finding by id
		/// </summary>
		/// <param name="model"></param>
		/// <returns></returns>
		Task<string> UpdateAsync(ImageType model, ICurrentUser user);

		/// <summary>
		/// Delete image type record by id
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		Task<string> DeleteAsync(int id);

		/// <summary>
		/// Image Select list item
		/// </summary>
		/// <returns></returns>
		Task<List<SelectListItem>> ImageTypeSelectList();
	}
}
