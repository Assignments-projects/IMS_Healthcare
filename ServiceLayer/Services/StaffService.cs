using DbLayer.Helpers;
using DbLayer.Interfaces;
using DbLayer.Models;
using ServiceLayer.Interfaces;

namespace ServiceLayer.Services
{
	public class StaffService : BaseService, IStaffService
	{
		private readonly IStaffsRepository _staff;

		public StaffService(IStaffsRepository staff)
		{
			_staff = staff;
		}

		/// <summary>
		/// Load staffs list
		/// </summary>
		/// <returns></returns>
		public async Task<List<Staff>> ListAsync()
		{
			return await _staff.ListAsync();
		}

		/// <summary>
		/// Get staff details by user uuid
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		public async Task<Staff> DetailsAsync(int id)
		{
			return await _staff.DetailsAsync(id);
		}

		/// <summary>
		/// Get staff details by user uuid
		/// </summary>
		/// <param name="userUuid"></param>
		/// <returns></returns>
		public async Task<Staff> DetailsAsync(string userUuid)
		{
			return await _staff.DetailsAsync(userUuid);
		}

		/// <summary>
		/// Add staffs to the database
		/// </summary>
		/// <param name="model"></param>
		/// <returns></returns>
		public async Task<string> AddAsync(Staff model, ICurrentUser user)
		{
			AddAudit(model, user);
			return await _staff.AddAsync(model);
		}

		/// <summary>
		/// Update staff record finding by id
		/// </summary>
		/// <param name="model"></param>
		/// <returns></returns>
		public async Task<string> UpdateAsync(Staff model, ICurrentUser user)
		{
			UpdateAudit(model, user);
			return await _staff.UpdateAsync(model);
		}

		/// <summary>
		/// Delete staff record by id
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		public async Task<string> DeleteAsync(int id)
		{
			return await _staff.DeleteAsync(id);
		}
	}
}
