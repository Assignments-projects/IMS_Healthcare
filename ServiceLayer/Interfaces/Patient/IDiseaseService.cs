using DbLayer.Helpers;
using DbLayer.Models.Patient;
using System.Web.Mvc;

namespace ServiceLayer.Interfaces.Patient
{
	public interface IDiseaseService
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
		Task<string> AddAsync(Disease model, ICurrentUser user);

		/// <summary>
		/// Update disease record finding by id
		/// </summary>
		/// <param name="model"></param>
		/// <returns></returns>
		Task<string> UpdateAsync(Disease model, ICurrentUser user);

		/// <summary>
		/// Delete disease record by id
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		Task<string> DeleteAsync(int id);

		/// <summary>
		/// Disease Select list item
		/// </summary>
		/// <returns></returns>
		Task<List<SelectListItem>> DiseaseSelectListForPatient(string patientUuid);

		/// <summary>
		/// Disease Select list item
		/// </summary>
		/// <returns></returns>
		Task<List<SelectListItem>> DiseaseSelectList();
	}
}
