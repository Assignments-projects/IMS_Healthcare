using DbLayer.Helpers;
using DbLayer.Models.Patient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Interfaces.Patient
{
	public interface IImageService
	{
		/// <summary>
		/// Load image list
		/// </summary>
		/// <returns></returns>
		Task<List<Image>> ListAsync();

		/// <summary>
		/// Get image details by id
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		Task<Image> DetailsAsync(int id);

		/// <summary>
		/// Add image to the database
		/// </summary>
		/// <param name="model"></param>
		/// <returns></returns>
		Task<string> AddAsync(Image model, ICurrentUser user);

		/// <summary>
		/// Update image record finding by id
		/// </summary>
		/// <param name="model"></param>
		/// <returns></returns>
		Task<string> UpdateAsync(Image model, ICurrentUser user);

		/// <summary>
		/// Delete image record by id
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		Task<string> DeleteAsync(int id);
	}
}
