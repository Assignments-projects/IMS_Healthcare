using DbLayer.Models.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbLayer.Interfaces.Settings
{
	public interface IDiseaseTypeRepository
	{
		/// <summary>
		/// Load disease type list
		/// </summary>
		/// <returns></returns>
		Task<List<DiseaseType>> ListAsync();

		/// <summary>
		/// Get disease type details by user uuid
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		Task<DiseaseType> DetailsAsync(int id);

		/// <summary>
		/// Add disease type to the database
		/// </summary>
		/// <param name="model"></param>
		/// <returns></returns>
		Task<string> AddAsync(DiseaseType model);

		/// <summary>
		/// Update disease type record finding by id
		/// </summary>
		/// <param name="model"></param>
		/// <returns></returns>
		Task<string> UpdateAsync(DiseaseType model);

		/// <summary>
		/// Delete disease type record by id
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		Task<string> DeleteAsync(int id);
	}
}
