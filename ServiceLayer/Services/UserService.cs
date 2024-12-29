using AuthLayer.Models;
using DbLayer.Interfaces;
using Microsoft.EntityFrameworkCore;
using ServiceLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Services
{
	public class UserService : IUserService
	{
		private readonly IUsersRepository _user;

		public UserService(IUsersRepository user) 
		{
			_user = user;
		}

		/// <summary>
		/// Get User's Roles by User Id
		/// </summary>
		/// <param name="UserId"></param>
		/// <returns></returns>
		public async Task<List<ViewUsersVsRoles>> UserRolesListAsync(string UserId)
		{
			return await _user.UserRolesListAsync(UserId);
		}
	}
}
