using DbLayer.Helpers;
using DbLayer.Models.Patient;
using System.Web.Mvc;

namespace ServiceLayer.Interfaces.Patient
{
	public interface IPatientsService
	{
		/// <summary>
		/// Load patients list
		/// </summary>
		/// <returns></returns>
		Task<List<Patients>> ListAsync();

		/// <summary>
		/// Get patient details by user uuid
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
		Task<string> AddAsync(Patients model, ICurrentUser user);

		/// <summary>
		/// Update patient record finding by id
		/// </summary>
		/// <param name="model"></param>
		/// <returns></returns>
		Task<string> UpdateAsync(Patients model, ICurrentUser user);

		/// <summary>
		/// Delete patient record by id
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		Task<string> DeleteAsync(int id);

		/// <summary>
		/// Patient Select list item
		/// </summary>
		/// <returns></returns>
		Task<List<SelectListItem>> PatientSelectList();
	}
}
