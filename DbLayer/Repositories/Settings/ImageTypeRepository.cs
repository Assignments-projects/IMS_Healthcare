using DbLayer.Data;
using DbLayer.Models.Patient;
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
	public class ImageTypeRepository
	{
		private readonly IMSDbContext _context;

		public ImageTypeRepository(IMSDbContext context)
		{
			_context = context;
		}

		/// <summary>
		/// Load image type list
		/// </summary>
		/// <returns></returns>
		public async Task<List<ImageType>> ListAsync()
		{
			var result = await _context.ImageTypes.ToListAsync();

			if (!result.Any())
				return new List<ImageType>();

			return result;
		}

		/// <summary>
		/// Get image type details by user uuid
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		public async Task<ImageType> DetailsAsync(int id)
		{
			var result = await _context.ImageTypes.FindAsync(id);

			if (result == null)
				return new ImageType();

			return result;
		}

		/// <summary>
		/// Add image type to the database
		/// </summary>
		/// <param name="model"></param>
		/// <returns></returns>
		public async Task<string> AddAsync(ImageType model)
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
		/// Update image type record finding by id
		/// </summary>
		/// <param name="model"></param>
		/// <returns></returns>
		public async Task<string> UpdateAsync(ImageType model)
		{
			try
			{
				var exist = await _context.ImageTypes.FindAsync(model.ImageTypeId);

				if (exist == null)
					return NotFound;

				exist.TypeName    = model.TypeName;
				exist.Description = model.Description;
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
		/// Delete image type record by id
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		public async Task<string> DeleteAsync(int id)
		{
			try
			{
				var exist = await _context.ImageTypes.FindAsync(id);

				if (exist == null)
					return NotFound;

				_context.ImageTypes.Remove(exist);

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
		private string NotFound => "The image type not found.";
	}
}
