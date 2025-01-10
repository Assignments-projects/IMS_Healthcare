using DbLayer.Helpers;
using DbLayer.Interfaces.Patient;
using DbLayer.Interfaces.Settings;
using DbLayer.Models;
using DbLayer.Models.Settings;
using ServiceLayer.Interfaces.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Services.Settings
{
	public class ImageTypeService : BaseService, IImageTypeService
	{
		private readonly IImageTypeRepository _imageType;

		public ImageTypeService(IImageTypeRepository imageType)
		{
			_imageType = imageType;
		}

		/// <summary>
		/// Load image type list
		/// </summary>
		/// <returns></returns>
		public async Task<List<ImageType>> ListAsync()
		{
			return await _imageType.ListAsync();
		}

		/// <summary>
		/// Get image type details by user uuid
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		public async Task<ImageType> DetailsAsync(int id)
		{
			return await _imageType.DetailsAsync(id);
		}

		/// <summary>
		/// Add image type to the database
		/// </summary>
		/// <param name="model"></param>
		/// <returns></returns>
		public async Task<string> AddAsync(ImageType model, ICurrentUser user)
		{
			AddAudit(model, user);
			return await _imageType.AddAsync(model);
		}

		/// <summary>
		/// Update image type record finding by id
		/// </summary>
		/// <param name="model"></param>
		/// <returns></returns>
		public async Task<string> UpdateAsync(ImageType model, ICurrentUser user)
		{
			UpdateAudit(model, user);
			return await _imageType.UpdateAsync(model);
		}

		/// <summary>
		/// Delete image type record by id
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		public async Task<string> DeleteAsync(int id)
		{
			return await _imageType.DeleteAsync(id);
		}
	}
}
