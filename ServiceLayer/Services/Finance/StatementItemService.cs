using DbLayer.Helpers;
using DbLayer.Interfaces.Finance;
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

		public StatementItemService(IStatementItemRepository item, IStatementService statement)
		{
			_item = item;
			_statement = statement;
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
			return await _item.AddAsync(model, 
									async () => _statement.CalculateStatementsTotal((int)model.StatementId));
		}

		/// <summary>
		/// Update statement item record finding by id
		/// </summary>
		/// <param name="model"></param>
		/// <returns></returns>
		public async Task<string> UpdateAsync(StatementItem model, ICurrentUser user)
		{
			UpdateAudit(model, user);
			return await _item.UpdateAsync(model,
									async () => _statement.CalculateStatementsTotal((int)model.StatementId));
		}

		/// <summary>
		/// Delete statement item record by id
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		public async Task<string> DeleteAsync(int id)
		{
			return await _item.DeleteAsync(id,
									async () => _statement.CalculateStatementsTotal(id));
		}
	}
}
