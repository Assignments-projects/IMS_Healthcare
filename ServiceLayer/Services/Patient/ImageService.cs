using DbLayer.Helpers;
using DbLayer.Interfaces.Patient;
using DbLayer.Models.Patient;
using ServiceLayer.Interfaces.Patient;

namespace ServiceLayer.Services.Patient
{
	public class ImageService : BaseService, IImageService
	{
		private readonly IImageRepository _image;

		public ImageService(IImageRepository image)
		{
			_image = image;
		}

		/// <summary>
		/// Load image list
		/// </summary>
		/// <returns></returns>
		public async Task<List<Image>> ListAsync()
		{
			return await _image.ListAsync();
		}

		/// <summary>
		/// Load image list belongs to the disease id
		/// </summary>
		/// <returns></returns>
		public async Task<List<Image>> ListAsync(int id)
		{
			return await _image.ListAsync(id);
		}

		/// <summary>
		/// Get image details by id
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		public async Task<Image> DetailsAsync(int id)
		{
			return await _image.DetailsAsync(id);
		}

		/// <summary>
		/// Add image to the database
		/// </summary>
		/// <param name="model"></param>
		/// <returns></returns>
		public async Task<string> AddAsync(Image model, ICurrentUser user)
		{
			AddAudit(model, user);
			return await _image.AddAsync(model);
		}

		/// <summary>
		/// Update image record finding by id
		/// </summary>
		/// <param name="model"></param>
		/// <returns></returns>
		public async Task<string> UpdateAsync(Image model, ICurrentUser user)
		{
			UpdateAudit(model, user);
			return await _image.UpdateAsync(model);
		}

		/// <summary>
		/// Delete image record by id
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		public async Task<string> DeleteAsync(int id)
		{
			return await _image.DeleteAsync(id);
		}
	}
}
