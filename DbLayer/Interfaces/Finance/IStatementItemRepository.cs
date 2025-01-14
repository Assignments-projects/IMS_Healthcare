using DbLayer.Helpers;
using DbLayer.Models.Finance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbLayer.Interfaces.Finance
{
	public interface IStatementItemRepository
	{
		/// <summary>
		/// Load statement item list
		/// </summary>
		/// <returns></returns>
		Task<List<StatementItem>> ListAsync();

		/// <summary>
		/// Load statement item list belong to statement id
		/// </summary>
		/// <returns></returns>
		Task<List<StatementItem>> ListAsync(int id);

		/// <summary>
		/// Get statement item details by id
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		Task<StatementItem> DetailsAsync(int id);

		/// <summary>
		/// Add statement item to the database
		/// </summary>
		/// <param name="model"></param>
		/// <param name="onSave"></param>
		/// <returns></returns>
		Task<string> AddAsync(StatementItem model, Action onSave = null);

		/// <summary>
		/// Update statement item record finding by id
		/// </summary>
		/// <param name="model"></param>
		/// <param name="onSave"></param>
		/// <returns></returns>
		Task<string> UpdateAsync(StatementItem model, Action onSave = null);

		/// <summary>
		/// Delete statement item record by id
		/// </summary>
		/// <param name="id"></param>
		/// <param name="onSave"></param>
		/// <returns></returns>
		Task<string> DeleteAsync(int id, Action onSave = null);
	}
}
