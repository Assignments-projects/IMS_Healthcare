using DbLayer.Helpers;
using DbLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbLayer.Interfaces
{
	public interface IHomeRepository
	{
		/// <summary>
		/// Get dashboard details for user
		/// </summary>
		/// <param name="user"></param>
		/// <returns></returns>
		Task<Dashboard> AdminDetailsAsync(ICurrentUser user);

		/// <summary>
		/// Get dashboard details for patient
		/// </summary>
		/// <param name="user"></param>
		/// <returns></returns>
		Task<Dashboard> PatientDetailsAsync(ICurrentUser user);

		/// <summary>
		/// Get dashboard details for staff
		/// </summary>
		/// <param name="user"></param>
		/// <returns></returns>
		Task<Dashboard> StaffDetailsAsync(ICurrentUser user);
	}
}
