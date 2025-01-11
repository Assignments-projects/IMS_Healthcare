using AuthLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbLayer.Interfaces
{
	public interface IUsersRepository
	{
		/// <summary>
		/// Get User's Roles by User Id
		/// </summary>
		/// <param name="UserId"></param>
		/// <returns></returns>
		Task<List<ViewUsersVsRoles>> UserRolesListAsync(string UserId);

		/// <summary>
		/// Get users with roles details
		/// </summary>
		/// <returns></returns>
		Task<List<ViewUsersVsRoles>> UserRolesListAsync();

		/// <summary>
		/// Add or Update user record to users table from asp net users 
		/// </summary>
		/// <param name="userId"></param>
		/// <param name="isUpdate"></param>
		/// <returns></returns>
		Task<string> UpdateUserFromIdentity(string userId, bool isUpdate = false);
	}
}
