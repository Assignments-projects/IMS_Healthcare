using DbLayer.Models.Settings;

namespace DbLayer.Interfaces.Settings
{
	public interface IImageTypeRepository
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
		Task<string> AddAsync(ImageType model);

		/// <summary>
		/// Update image type record finding by id
		/// </summary>
		/// <param name="model"></param>
		/// <returns></returns>
		Task<string> UpdateAsync(ImageType model);

		/// <summary>
		/// Delete image type record by id
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		Task<string> DeleteAsync(int id);
	}
}
