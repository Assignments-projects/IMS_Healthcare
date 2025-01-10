using DbLayer.Helpers;
using DbLayer.Interfaces.Finance;
using DbLayer.Interfaces.Patient;
using DbLayer.Models.Finance;
using ServiceLayer.Interfaces.Finance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Services.Finance
{
	public class StatementService : BaseService, IStatementService
	{
		private readonly IStatementRepository _statement;

		public StatementService(IStatementRepository statement)
		{
			_statement = statement;
		}

		/// <summary>
		/// Load statement list
		/// </summary>
		/// <returns></returns>
		public async Task<List<Statement>> ListAsync()
		{
			return await _statement.ListAsync();
		}

		/// <summary>
		/// Get statement details by id
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		public async Task<Statement> DetailsAsync(int id)
		{
			return await _statement.DetailsAsync(id);
		}

		/// <summary>
		/// Add statement to the database
		/// </summary>
		/// <param name="model"></param>
		/// <returns></returns>
		public async Task<string> AddAsync(Statement model, ICurrentUser user)
		{
			AddAudit(model, user);
			return await _statement.AddAsync(model);
		}

		/// <summary>
		/// Update statement record finding by id
		/// </summary>
		/// <param name="model"></param>
		/// <returns></returns>
		public async Task<string> UpdateAsync(Statement model, ICurrentUser user)
		{
			UpdateAudit(model, user);
			return await _statement.UpdateAsync(model);
		}

		/// <summary>
		/// Delete statement record by id
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		public async Task<string> DeleteAsync(int id)
		{
			return await _statement.DeleteAsync(id);
		}
	}
}
