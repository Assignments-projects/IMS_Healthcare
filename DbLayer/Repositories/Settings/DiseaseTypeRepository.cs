using DbLayer.Data;
using DbLayer.Interfaces.Settings;
using DbLayer.Models.Settings;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace DbLayer.Repositories.Settings
{
	public class DiseaseTypeRepository : BaseRepository, IDiseaseTypeRepository
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
			return await MakeDiseaseTypes(_context.DiseaseTypes);
		}

		/// <summary>
		/// Get disease type details by user uuid
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		public async Task<DiseaseType> DetailsAsync(int id)
		{
			var result = _context.DiseaseTypes.Where(x => x.DiseaseTypeId == id);

			return (await MakeDiseaseTypes(result)).FirstOrDefault();
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
		/// Make List of disease type with aditional datas
		/// </summary>
		/// <param name="found"></param>
		/// <returns></returns>
		private async Task<List<DiseaseType>> MakeDiseaseTypes(IQueryable<DiseaseType> found)
		{
			var result = await found.Include(x => x.AddedBy)
									.Include(x => x.UpdatedBy)
									.Include(x => x.Diseases)
										.ThenInclude(x => x.Images)
											.ThenInclude(x => x.ImageType)
									.Include(x => x.Diseases)
										.ThenInclude(x => x.Patient)
									.ToListAsync();
			if (!result.Any())
				return new List<DiseaseType>();

			AddAuditNames(result);
			return result;
		}

		/// <summary>
		/// Not found message
		/// </summary>
		private string NotFound => "The disease type not found.";
	}
}
