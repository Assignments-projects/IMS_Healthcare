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
	}
}
