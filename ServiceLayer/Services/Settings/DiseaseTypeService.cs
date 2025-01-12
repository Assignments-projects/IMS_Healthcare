using DbLayer.Helpers;
using DbLayer.Interfaces.Settings;
using DbLayer.Models.Patient;
using DbLayer.Models.Settings;
using ServiceLayer.Interfaces.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace ServiceLayer.Services.Settings
{
	public class DiseaseTypeService : BaseService, IDiseaseTypeService
	{
		private readonly IDiseaseTypeRepository _diseaseType;

		public DiseaseTypeService(IDiseaseTypeRepository diseaseType)
		{
			_diseaseType = diseaseType;
		}

		/// <summary>
		/// Load disease type list
		/// </summary>
		/// <returns></returns>
		public async Task<List<DiseaseType>> ListAsync()
		{
			return await _diseaseType.ListAsync();
		}

		/// <summary>
		/// Get disease type details by user uuid
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		public async Task<DiseaseType> DetailsAsync(int id)
		{
			return await _diseaseType.DetailsAsync(id);
		}

		/// <summary>
		/// Add disease type to the database
		/// </summary>
		/// <param name="model"></param>
		/// <returns></returns>
		public async Task<string> AddAsync(DiseaseType model, ICurrentUser user)
		{
			AddAudit(model, user);
			return await _diseaseType.AddAsync(model);
		}

		/// <summary>
		/// Update disease type record finding by id
		/// </summary>
		/// <param name="model"></param>
		/// <returns></returns>
		public async Task<string> UpdateAsync(DiseaseType model, ICurrentUser user)
		{
			UpdateAudit(model, user);
			return await _diseaseType.UpdateAsync(model);
		}

		/// <summary>
		/// Delete disease type record by id
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		public async Task<string> DeleteAsync(int id)
		{
			return await _diseaseType.DeleteAsync(id);
		}

		/// <summary>
		/// Disease Select list item
		/// </summary>
		/// <returns></returns>
		public async Task<List<SelectListItem>> DiseaseTypeSelectList()
		{
			var result = await _diseaseType.ListAsync();

			if (!result.Any())
				return new List<SelectListItem>();

			var list = result.Select(x => new SelectListItem
			{
				Value = x.DiseaseTypeId.ToString(),
				Text  = x.TypeName
			}).ToList();

			if (!list.Any())
				return new List<SelectListItem>();

			return list;
		}
	}
}
