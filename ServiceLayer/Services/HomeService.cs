using DbLayer.Helpers;
using DbLayer.Interfaces;
using DbLayer.Models;
using ServiceLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Services
{
	public class HomeService : BaseService, IHomeService
	{
		private readonly IHomeRepository _home;

		public HomeService(IHomeRepository home) 
		{
			_home = home;
		}

		/// <summary>
		/// Get dashboard details for user
		/// </summary>
		/// <param name="user"></param>
		/// <returns></returns>
		public async Task<Dashboard> DetailsAsync(ICurrentUser user)
		{
			if(IsAdmin(user))
				return await _home.AdminDetailsAsync(user);

			if(IsStaff(user))
				return await _home.StaffDetailsAsync(user);

			else
				return await _home.PatientDetailsAsync(user);
		}
	}
}
