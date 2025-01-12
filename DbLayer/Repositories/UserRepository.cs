using AuthLayer.Models;
using DbLayer.Data;
using DbLayer.Interfaces;
using DbLayer.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace DbLayer.Repositories
{
	public class UserRepository : BaseRepository, IUsersRepository
	{
		private readonly IMSDbContext _context;

		public UserRepository(IMSDbContext context) 
		{
			_context = context;
		}

		/// <summary>
		/// Get User's Roles by User Id
		/// </summary>
		/// <param name="UserId"></param>
		/// <returns></returns>
		public async Task<List<ViewUsersVsRoles>> UserRolesListAsync(string UserId)
		{
			var result = await _context.ViewUsersVsRoles.Where(x => x.UserId == UserId).ToListAsync();

			if (!result.Any())
				return new List<ViewUsersVsRoles>();

			return result;
		}

		/// <summary>
		/// Get approves users with roles details 
		/// </summary>
		/// <returns></returns>
		public async Task<List<ViewUsersVsRoles>> UserRolesListAsync()
		{
			var result = await _context.ViewUsersVsRoles.Where(x => x.IsApproved).ToListAsync();

			if (!result.Any())
				return new List<ViewUsersVsRoles>();

			return result;
		}

		/// <summary>
		/// Add or Update user record to users table from asp net users 
		/// </summary>
		/// <param name="userId"></param>
		/// <param name="isUpdate"></param>
		/// <returns></returns>
		public async Task<string> UpdateUserFromIdentity(string userId, bool isUpdate = false)
		{
			try
			{
				if (isUpdate)
				{
					await _context.Database.ExecuteSqlRawAsync("EXEC [dbo].[SP_UPDATE_USERS_FROM_ASPNETUSER] @UserId",
															new SqlParameter("UserId", userId));
				}
				else
				{
					await _context.Database.ExecuteSqlRawAsync("EXEC [dbo].[SP_INSERT_USERS_FROM_ASPNETUSER] @UserId",
															new SqlParameter("UserId", userId));
				}

				return null;
			}
			catch (SqlException sqlEx)
			{
				return sqlEx.Message;
			}
			catch (Exception ex)
			{
				return ex.Message;
			}
		}
	}
}
