using DbLayer.Models.Patient;

namespace DbLayer.Interfaces.Patient
{
	public interface IImageRepository
	{
		/// <summary>
		/// Load image list
		/// </summary>
		/// <returns></returns>
		Task<List<Image>> ListAsync();

		/// <summary>
		/// Load image list belongs to the disease id
		/// </summary>
		/// <returns></returns>
		Task<List<Image>> ListAsync(int id);

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
		Task<string> AddAsync(Image model);

		/// <summary>
		/// Update image record finding by id
		/// </summary>
		/// <param name="model"></param>
		/// <returns></returns>
		Task<string> UpdateAsync(Image model);

		/// <summary>
		/// Delete image record by id
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		Task<string> DeleteAsync(int id);
	}
}
