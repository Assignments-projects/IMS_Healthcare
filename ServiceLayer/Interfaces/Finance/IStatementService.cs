using DbLayer.Helpers;
using DbLayer.Models.Finance;
using DbLayer.Models.Patient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Interfaces.Finance
{
	public interface IStatementService
	{
		/// <summary>
		/// Load statement list
		/// </summary>
		/// <returns></returns>
		Task<List<Statement>> ListAsync();

		/// <summary>
		/// Get statement details by id
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		Task<Statement> DetailsAsync(int id);

		/// <summary>
		/// Add statement to the database
		/// </summary>
		/// <param name="model"></param>
		/// <returns></returns>
		Task<string> AddAsync(Statement model, ICurrentUser user);

		/// <summary>
		/// Update statement record finding by id
		/// </summary>
		/// <param name="model"></param>
		/// <returns></returns>
		Task<string> UpdateAsync(Statement model, ICurrentUser user);

		/// <summary>
		/// Delete statement record by id
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		Task<string> DeleteAsync(int id);
	}
}
