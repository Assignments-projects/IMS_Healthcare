using DbLayer.Data;
using DbLayer.Helpers;
using DbLayer.Interfaces.Finance;
using DbLayer.Models.Finance;
using DbLayer.Models.Patient;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbLayer.Repositories.Finance
{
	public class StatementItemRepository : BaseRepository, IStatementItemRepository
	{
		private readonly IMSDbContext _context;

		public StatementItemRepository(IMSDbContext context)
		{
			_context = context;
		}

		/// <summary>
		/// Load statement item list
		/// </summary>
		/// <returns></returns>
		public async Task<List<StatementItem>> ListAsync()
		{
			return await MakeStatementItems(_context.StatementItems);
		}

		/// <summary>
		/// Load statement item list belong to statement id
		/// </summary>
		/// <returns></returns>
		public async Task<List<StatementItem>> ListAsync(int id)
		{
			return await MakeStatementItems(_context.StatementItems.Where(x => x.StatementId == id));
		}


		/// <summary>
		/// Get statement item details by id
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		public async Task<StatementItem> DetailsAsync(int id)
		{
			var result = _context.StatementItems.Where(x => x.StatementItemId == id);

			return (await MakeStatementItems(result)).FirstOrDefault();
		}

		/// <summary>
		/// Add statement item to the database
		/// </summary>
		/// <param name="model"></param>
		/// <param name="onSave"></param>
		/// <returns></returns>
		public async Task<string> AddAsync(StatementItem model, Action onSave = null)
		{
			try
			{
				await _context.AddAsync(model);
				await _context.SaveChangesAsync();

				onSave?.Invoke();
			}
			catch (SqlException sqlEx)
			{
				return sqlEx.Message;
			}
			catch (Exception ex)
			{
				return ex.Message;
			}

			return null;
		}

		/// <summary>
		/// Update statement item record finding by id
		/// </summary>
		/// <param name="model"></param>
		/// <param name="onSave"></param>
		/// <returns></returns>
		public async Task<string> UpdateAsync(StatementItem model, Action onSave = null)
		{
			try
			{
				var exist = await _context.StatementItems.FindAsync(model.DiseaseId);

				if (exist == null)
					return NotFound;

				exist.StatementItemId = model.StatementItemId;
				exist.DiseaseId       = model.DiseaseId;
				exist.StatementId     = model.StatementId;
				exist.Description     = model.Description;
				exist.TotalCost       = model.TotalCost;
				exist.UpdatedById     = model.UpdatedById;
				exist.UpdatedDate     = model.UpdatedDate;

				await _context.SaveChangesAsync();

				onSave?.Invoke();
			}
			catch (SqlException sqlEx)
			{
				return sqlEx.Message;
			}
			catch (Exception ex)
			{
				return ex.Message;
			}

			return null;
		}

		/// <summary>
		/// Delete statement item record by id
		/// </summary>
		/// <param name="id"></param>
		/// <param name="onSave"></param>
		/// <returns></returns>
		public async Task<string> DeleteAsync(int id, Action onSave = null)
		{
			try
			{
				var exist = await _context.StatementItems.FindAsync(id);

				if (exist == null)
					return NotFound;

				_context.StatementItems.Remove(exist);

				await _context.SaveChangesAsync();

				onSave?.Invoke();
			}
			catch (SqlException sqlEx)
			{
				return sqlEx.Message;
			}
			catch (Exception ex)
			{
				return ex.Message;
			}

			return null;
		}

		/// <summary>
		/// Make List of statement item with aditional datas
		/// </summary>
		/// <param name="found"></param>
		/// <returns></returns>
		private async Task<List<StatementItem>> MakeStatementItems(IQueryable<StatementItem> found)
		{
			var result = await found.Include(x => x.AddedBy)
									.Include(x => x.UpdatedBy)
									.Include(x => x.Disease)
									.Include(x => x.Statement)
									.ToListAsync();
			if (!result.Any())
				return new List<StatementItem>();

			AddAuditNames(result);
			return result;
		}

		/// <summary>
		/// Not found message
		/// </summary>
		private string NotFound => "The statement item not found.";
	}
}
