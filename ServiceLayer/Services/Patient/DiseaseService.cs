using DbLayer.Helpers;
using DbLayer.Interfaces.Patient;
using DbLayer.Models.Patient;
using ServiceLayer.Interfaces.Patient;

namespace ServiceLayer.Services.Patient
{
	public class DiseaseService : BaseService, IDiseaseService
	{
		private readonly IDiseaseRepository _disease;

		public DiseaseService(IDiseaseRepository disease)
		{
			_disease = disease;
		}

		/// <summary>
		/// Load disease list
		/// </summary>
		/// <returns></returns>
		public async Task<List<Disease>> ListAsync()
		{
			return await _disease.ListAsync();
		}

		/// <summary>
		/// Get disease details by id
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		public async Task<Disease> DetailsAsync(int id)
		{
			return await _disease.DetailsAsync(id);
		}

		/// <summary>
		/// Add disease to the database
		/// </summary>
		/// <param name="model"></param>
		/// <returns></returns>
		public async Task<string> AddAsync(Disease model, ICurrentUser user)
		{
			AddAudit(model, user);
			return await _disease.AddAsync(model);
		}

		/// <summary>
		/// Update disease record finding by id
		/// </summary>
		/// <param name="model"></param>
		/// <returns></returns>
		public async Task<string> UpdateAsync(Disease model, ICurrentUser user)
		{
			UpdateAudit(model, user);
			return await _disease.UpdateAsync(model);
		}

		/// <summary>
		/// Delete disease record by id
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		public async Task<string> DeleteAsync(int id)
		{
			return await _disease.DeleteAsync(id);
		}
	}
}
