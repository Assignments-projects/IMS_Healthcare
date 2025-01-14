using DbLayer.Helpers;
using DbLayer.Interfaces.Finance;
using DbLayer.Interfaces.Patient;
using DbLayer.Models.Finance;
using ServiceLayer.Interfaces.Finance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Services.Finance
{
	public class StatementItemService : BaseService, IStatementItemService
	{
		private readonly IStatementItemRepository _item;
		private readonly IStatementService _statement;
		private readonly IPatientsRepository _patient;

		public StatementItemService(
			IStatementItemRepository item, 
			IStatementService statement,
			IPatientsRepository patients)
		{
			_item = item;
			_statement = statement;
			_patient = patients;
		}

		/// <summary>
		/// Load statement item list
		/// </summary>
		/// <returns></returns>
		public async Task<List<StatementItem>> ListAsync()
		{
			return await _item.ListAsync();
		}

		/// <summary>
		/// Load statement item list belong to statement id
		/// </summary>
		/// <returns></returns>
		public async Task<List<StatementItem>> ListAsync(int id)
		{
			return await _item.ListAsync(id);
		}

		/// <summary>
		/// Load statement item list belong to disease id
		/// </summary>
		/// <returns></returns>
		public async Task<List<StatementItem>> ListForDiseaseAsync(int id)
		{
			return await _item.ListForDiseaseAsync(id);
		}

		/// <summary>
		/// Get statement item details by id
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		public async Task<StatementItem> DetailsAsync(int id)
		{
			return await _item.DetailsAsync(id);
		}

		/// <summary>
		/// Add statement item to the database
		/// </summary>
		/// <param name="model"></param>
		/// <returns></returns>
		public async Task<string> AddAsync(StatementItem model, ICurrentUser user)
		{
			AddAudit(model, user);

			var result = await _item.AddAsync(model);

			if (string.IsNullOrEmpty(result))
				return await CaclculateTotals((int)model.StatementId);

			return result;
		}

		/// <summary>
		/// Update statement item record finding by id
		/// </summary>
		/// <param name="model"></param>
		/// <returns></returns>
		public async Task<string> UpdateAsync(StatementItem model, ICurrentUser user)
		{
			UpdateAudit(model, user);

			var result = await _item.UpdateAsync(model);

			if (string.IsNullOrEmpty(result))
				return await CaclculateTotals((int)model.StatementId);

			return result;
		}

		/// <summary>
		/// Delete statement item record by id
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		public async Task<string> DeleteAsync(int id, int statementId)
		{
			var result =  await _item.DeleteAsync(id);

			if(string.IsNullOrEmpty(result))
				return await CaclculateTotals(statementId);

			return result;
		}

		/// <summary>
		/// Calculate patient and statement total
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		public async Task<string> CaclculateTotals(int id)
		{
			var result = await _statement.CalculateStatementsTotal(id);

			if (string.IsNullOrEmpty(result))
			{
				var statement = await _statement.DetailsAsync(id);

				return await _patient.CalculatePatientsTotal(statement.PatientUuid);
			}
				
			return result;
		}
	}
}
