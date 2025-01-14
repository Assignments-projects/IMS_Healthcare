using DbLayer.Models.Patient;

namespace DbLayer.Interfaces.Patient
{
	public interface IPatientsRepository
	{
		/// <summary>
		/// Load patients list
		/// </summary>
		/// <returns></returns>
		Task<List<Patients>> ListAsync();

		/// <summary>
		/// Get patient details by id
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		Task<Patients> DetailsAsync(int id);

		/// <summary>
		/// Get patient details by user uuid
		/// </summary>
		/// <param name="userUuid"></param>
		/// <returns></returns>
		Task<Patients> DetailsAsync(string userUuid);

		/// <summary>
		/// Add patients to the database
		/// </summary>
		/// <param name="model"></param>
		/// <returns></returns>
		Task<string> AddAsync(Patients model);

		/// <summary>
		/// Update patient record finding by id
		/// </summary>
		/// <param name="model"></param>
		/// <returns></returns>
		Task<string> UpdateAsync(Patients model);

		/// <summary>
		/// Delete patient record by id
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		Task<string> DeleteAsync(int id);

		/// <summary>
		/// Calculate patients total from statement by given id 
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		Task<string> CalculatePatientsTotal(string id);
	}
}
