using DbLayer.Data;
using DbLayer.Models.Settings;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbLayer.Repositories.Settings
{
	public class DiseaseTypeRepository
	{
		private readonly IMSDbContext _context;

		public DiseaseTypeRepository(IMSDbContext context)
		{
			_context = context;
		}

		/// <summary>
		/// Load disease type list
		/// </summary>
		/// <returns></returns>
		public async Task<List<DiseaseType>> ListAsync()
		{
			var result = await _context.DiseaseTypes.ToListAsync();

			if (!result.Any())
				return new List<DiseaseType>();

			return result;
		}

		/// <summary>
		/// Get disease type details by user uuid
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		public async Task<DiseaseType> DetailsAsync(int id)
		{
			var result = await _context.DiseaseTypes.FindAsync(id);

			if (result == null)
				return new DiseaseType();

			return result;
		}

		/// <summary>
		/// Add disease type to the database
		/// </summary>
		/// <param name="model"></param>
		/// <returns></returns>
		public async Task<string> AddAsync(DiseaseType model)
		{
			try
			{
				await _context.AddAsync(model);
				await _context.SaveChangesAsync();
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
		/// Update disease type record finding by id
		/// </summary>
		/// <param name="model"></param>
		/// <returns></returns>
		public async Task<string> UpdateAsync(DiseaseType model)
		{
			try
			{
				var exist = await _context.DiseaseTypes.FindAsync(model.DiseaseTypeId);

				if (exist == null)
					return NotFound;

				exist.TypeName = model.TypeName;
				exist.Description = model.Description;
				exist.Comments = model.Comments;
				exist.UpdatedById = model.UpdatedById;
				exist.UpdatedDate = model.UpdatedDate;

				await _context.SaveChangesAsync();
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
		/// Delete disease type record by id
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		public async Task<string> DeleteAsync(int id)
		{
			try
			{
				var exist = await _context.DiseaseTypes.FindAsync(id);

				if (exist == null)
					return NotFound;

				_context.DiseaseTypes.Remove(exist);

				await _context.SaveChangesAsync();
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
		/// Not found message
		/// </summary>
		private string NotFound => "The disease type not found.";
	}
}
