using DbLayer.Models.Finance;

namespace DbLayer.Interfaces.Finance
{
	public interface IStatementRepository
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
		Task<string> AddAsync(Statement model);

		/// <summary>
		/// Update statement record finding by id
		/// </summary>
		/// <param name="model"></param>
		/// <returns></returns>
		Task<string> UpdateAsync(Statement model);

		/// <summary>
		/// Delete statement record by id
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		Task<string> DeleteAsync(int id);
	}
}
