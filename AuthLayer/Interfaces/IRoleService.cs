using AuthLayer.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace AuthLayer.Interfaces
{
	public interface IRoleService
	{

		/// <summary>
		/// Get Roles avaialable as a list
		/// </summary>
		/// <returns></returns>
		Task<List<IdentityRole>> ListAsync();

		/// <summary> as a list
		/// Get Role details by id
		/// </summary>
		/// <returns></returns>
		Task<IdentityRole> DetailsAsync(string id);

		/// <summary>
		/// Add new roles to the database identity role table
		/// </summary>
		/// <param name="role"></param>
		/// <returns></returns>
		Task<(bool success, List<string> errors)> AddAsync(IdentityRole role);

		/// <summary>
		/// Update exisiting roles avaialable
		/// </summary>
		/// <param name="role"></param>
		/// <returns></returns>
		Task<(bool success, List<string> errors)> UpdateAsync(IdentityRole role);

		/// <summary>
		/// Remove user roles from identity role table
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		Task<(bool success, List<string> errors)> DeleteAsync(string id);

		/// <summary>
		/// Get roles as select list
		/// </summary>
		/// <returns></returns>
		Task<List<SelectListItem>> RolesSelectList();

		#region User vs Roles

		/// <summary>
		/// Assign or Un assign user role  
		/// </summary>
		/// <param name="userRole"></param>
		/// <param name="removeRole"></param>
		/// <returns></returns>
		Task<(bool success, List<string> errors)> AssignRoleAsync(ViewUsersVsRoles userRole, bool removeRole = false);

		#endregion
	}
}
