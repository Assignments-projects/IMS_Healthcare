using DbLayer.Models.Patient;

namespace DbLayer.Interfaces.Patient
{
	public interface IDiseaseRepository
	{
		/// <summary>
		/// Load disease list
		/// </summary>
		/// <returns></returns>
		Task<List<Disease>> ListAsync();

		/// <summary>
		/// Load disease list for patient
		/// </summary>
		/// <param name="patientUuid"></param>
		/// <returns></returns>
		Task<List<Disease>> ListAsync(string patientUuid);

		/// <summary>
		/// Get disease details by id
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		Task<Disease> DetailsAsync(int id);

		/// <summary>
		/// Add disease to the database
		/// </summary>
		/// <param name="model"></param>
		/// <returns></returns>
		Task<string> AddAsync(Disease model);

		/// <summary>
		/// Update disease record finding by id
		/// </summary>
		/// <param name="model"></param>
		/// <returns></returns>
		Task<string> UpdateAsync(Disease model);

		/// <summary>
		/// Delete disease record by id
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		Task<string> DeleteAsync(int id);
	}
}
