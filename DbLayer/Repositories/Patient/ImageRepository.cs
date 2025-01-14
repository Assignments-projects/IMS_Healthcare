using DbLayer.Data;
using DbLayer.Interfaces.Patient;
using DbLayer.Models.Patient;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace DbLayer.Repositories.Patient
{
	public class ImageRepository : BaseRepository, IImageRepository
	{
		private readonly IMSDbContext _context;

		public ImageRepository(IMSDbContext context)
		{
			_context = context;
		}

		/// <summary>
		/// Load image list
		/// </summary>
		/// <returns></returns>
		public async Task<List<Image>> ListAsync()
		{
			return await MakeImages(_context.Images);
		}

		/// <summary>
		/// Load image list belongs to the disease id
		/// </summary>
		/// <returns></returns>
		public async Task<List<Image>> ListAsync(int id)
		{
			return await MakeImages(_context.Images.Where(x => x.DiseaseId == id));
		}

		/// <summary>
		/// Get image details by id
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		public async Task<Image> DetailsAsync(int id)
		{
			var result = _context.Images.Where(x => x.ImageId == id);

			return (await MakeImages(result)).FirstOrDefault();
		}

		/// <summary>
		/// Add image to the database
		/// </summary>
		/// <param name="model"></param>
		/// <returns></returns>
		public async Task<string> AddAsync(Image model)
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
		/// Update image record finding by id
		/// </summary>
		/// <param name="model"></param>
		/// <returns></returns>
		public async Task<string> UpdateAsync(Image model)
		{
			try
			{
				var exist = await _context.Images.FindAsync(model.ImageId);

				if (exist == null)
					return NotFound;

				exist.ImageTypeId = model.ImageTypeId;
				exist.DiseaseId   = model.DiseaseId;
				exist.FileName    = model.FileName;
				exist.FileContent = model.FileContent;
				exist.MimeType    = model.MimeType;
				exist.Comments    = model.Comments;
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
		/// Delete image record by id
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		public async Task<string> DeleteAsync(int id)
		{
			try
			{
				var exist = await _context.Images.FindAsync(id);

				if (exist == null)
					return NotFound;

				_context.Images.Remove(exist);

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
		/// Make List of image with aditional datas
		/// </summary>
		/// <param name="found"></param>
		/// <returns></returns>
		private async Task<List<Image>> MakeImages(IQueryable<Image> found)
		{
			var result = await found.Include(x => x.AddedBy)
									.Include(x => x.UpdatedBy)
									.Include(x => x.Disease)
										.ThenInclude(x => x.DiseaseType)
									.Include(x => x.Disease)
										.ThenInclude(x => x.Doctor)
									.Include(x => x.Disease)
										.ThenInclude(x => x.Patient)
									.Include(x => x.ImageType)
									.AsNoTracking()
									.ToListAsync();
			if (!result.Any())
				return new List<Image>();

			AddAuditNames(result);
			return result;
		}

		/// <summary>
		/// Not found message
		/// </summary>
		private string NotFound => "The image not found.";
	}
}
