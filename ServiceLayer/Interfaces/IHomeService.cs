using DbLayer.Helpers;
using DbLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Interfaces
{
	public interface IHomeService
	{
		/// <summary>
		/// Get dashboard details for user
		/// </summary>
		/// <param name="user"></param>
		/// <returns></returns>
		Task<Dashboard> DetailsAsync(ICurrentUser user);
	}
}
