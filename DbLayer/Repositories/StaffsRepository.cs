using DbLayer.Data;
using DbLayer.Interfaces;
using DbLayer.Models;
using DbLayer.Models.Settings;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace DbLayer.Repositories
{
	public class StaffsRepository : BaseRepository, IStaffsRepository
	{
		private readonly IMSDbContext _context;

		public StaffsRepository(IMSDbContext context)
		{
			_context = context;
		}

		/// <summary>
		/// Load staffs list
		/// </summary>
		/// <returns></returns>
		public async Task<List<Staff>> ListAsync()
		{
			return await MakeStaffs(_context.Staffs);
		}

		/// <summary>
		/// Get staff details by user uuid
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		public async Task<Staff> DetailsAsync(int id)
		{
			var result = _context.Staffs.Where(x => x.StaffId == id);

			return (await MakeStaffs(result)).FirstOrDefault();
		}

		/// <summary>
		/// Get staff details by user uuid
		/// </summary>
		/// <param name="userUuid"></param>
		/// <returns></returns>
		public async Task<Staff> DetailsAsync(string userUuid)
		{
			var result = _context.Staffs.Where(x => x.StaffUuid == userUuid);

			return (await MakeStaffs(result)).FirstOrDefault();
		}

		/// <summary>
		/// Add staffs to the database
		/// </summary>
		/// <param name="model"></param>
		/// <returns></returns>
		public async Task<string> AddAsync(Staff model)
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
		/// Update staff record finding by id
		/// </summary>
		/// <param name="model"></param>
		/// <returns></returns>
		public async Task<string> UpdateAsync(Staff model)
		{
			try
			{
				var exist = await _context.Staffs.FindAsync(model.StaffId);

				if (exist == null)
					return NotFound;

				exist.StaffUuid    = model.StaffUuid;
				exist.FirstName   = model.FirstName;
				exist.LastName    = model.LastName;
				exist.Address     = model.Address;
				exist.PhoneNo     = model.PhoneNo;
				exist.DateOfBirth = model.DateOfBirth;
				exist.Comments    = model.Comments;
				exist.Gender      = model.Gender;
				exist.IdentityNo  = model.IdentityNo;
				exist.Educations  = model.Educations;
				exist.Salary      = model.Salary;
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
		/// Delete staff record by id
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		public async Task<string> DeleteAsync(int id)
		{
			try
			{
				var exist = await _context.Staffs.FindAsync(id);

				if (exist == null)
					return NotFound;

				_context.Staffs.Remove(exist);

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
		/// Make List of staffs with aditional datas
		/// </summary>
		/// <param name="found"></param>
		/// <returns></returns>
		private async Task<List<Staff>> MakeStaffs(IQueryable<Staff> found)
		{
			var result = await found.Include(x => x.AddedBy)
									.Include(x => x.UpdatedBy)
									.ToListAsync();
			if (!result.Any())
				return new List<Staff>();

			AddAuditNames(result);
			return result;
		}

		/// <summary>
		/// Not found message
		/// </summary>
		private string NotFound => "The staff not found.";
	}
}
