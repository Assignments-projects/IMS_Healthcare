using AuthLayer.Models;
using DbLayer.Data;
using DbLayer.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DbLayer.Repositories
{
	public class UserRepository : IUsersRepository
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
	}
}
