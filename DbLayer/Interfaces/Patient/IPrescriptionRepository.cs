using DbLayer.Models.Patient;

namespace DbLayer.Interfaces.Patient
{
	public interface IPrescriptionRepository
	{
		/// <summary>
		/// Load prescription list
		/// </summary>
		/// <returns></returns>
		Task<List<Prescription>> ListAsync();

		/// <summary>
		/// Get prescription details by id
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		Task<Prescription> DetailsAsync(int id);

		/// <summary>
		/// Add prescription to the database
		/// </summary>
		/// <param name="model"></param>
		/// <returns></returns>
		Task<string> AddAsync(Prescription model);

		/// <summary>
		/// Update prescription record finding by id
		/// </summary>
		/// <param name="model"></param>
		/// <returns></returns>
		Task<string> UpdateAsync(Prescription model);

		/// <summary>
		/// Delete prescription record by id
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		Task<string> DeleteAsync(int id);
	}
}
