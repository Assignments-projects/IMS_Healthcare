using AuthLayer.Interfaces;
using AuthLayer.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Web.Mvc;

namespace AuthLayer.Services
{
	public class RoleService : IRoleService
	{
		private readonly RoleManager<IdentityRole> _roleManager;
		private readonly UserManager<AppUser> _userManager;


		public RoleService(
			RoleManager<IdentityRole> roleManager,
			UserManager<AppUser> userManager
		)
        {
            _roleManager = roleManager;
			_userManager = userManager;
        }

        /// <summary>
        /// Get Roles avaialable as a list
        /// </summary>
        /// <returns></returns>
        public async Task<List<IdentityRole>> ListAsync()
        {
            var result = await _roleManager.Roles.ToListAsync();

            if(!result.Any())
                return new List<IdentityRole>();

            return result;
        }

		/// <summary>
		/// Get Role details by id
		/// </summary>
		/// <returns></returns>
		public async Task<IdentityRole> DetailsAsync(string id)
		{
			var result = await _roleManager.FindByIdAsync(id);

			if (result == null)
				return new IdentityRole();

			return result;
		}

		/// <summary>
		/// Add new roles to the database identity role table
		/// </summary>
		/// <param name="role"></param>
		/// <returns></returns>
		public async Task<(bool success, List<string> errors)> AddAsync(IdentityRole role)
        {
			var errors    = new List<string>();

			try
			{
				var roleExist = await _roleManager.RoleExistsAsync(role.Name);

				if (roleExist)
				{
					errors.Add("Already the role is exist.");
					return (false, errors);
				}

				role.Id               = Guid.NewGuid().ToString();
				role.ConcurrencyStamp = Guid.NewGuid().ToString();

				// Add user roles to the identity role table
				var result = await _roleManager.CreateAsync(role);

				if (!result.Succeeded)
				{
					foreach (var e in result.Errors)
					{
						errors.Add(e.Description);
					}

					return (false, errors);
				}

				return (true, errors);
			}
			catch (Exception ex)
			{
				errors.Add(ex.Message);
				return (false, errors);
			}			
		}

		/// <summary>
		/// Update exisiting roles avaialable
		/// </summary>
		/// <param name="role"></param>
		/// <returns></returns>
		public async Task<(bool success, List<string> errors)> UpdateAsync(IdentityRole role)
		{
			var errors = new List<string>();

			try
			{
				// Reload the role from the data source to ensure there are no conflicts
				var existingRole = await _roleManager.FindByIdAsync(role.Id);

				if (existingRole == null)
				{
					errors.Add("Role not found.");
					return (false, errors);
				}

				existingRole.Name = role.Name;

				// Update exisiting role details
				var result = await _roleManager.UpdateAsync(existingRole);

				if (!result.Succeeded)
				{
					foreach (var e in result.Errors)
					{
						errors.Add(e.Description);
					}

					return (false, errors);
				}

				return (true, errors);

			}
			catch (Exception ex)
			{
				errors.Add(ex.Message);
				return (false, errors);
			}
		}

		/// <summary>
		/// Remove user roles from identity role table
		/// </summary>
		/// <param name="role"></param>
		/// <returns></returns>
		public async Task<(bool success, List<string> errors)> DeleteAsync(string id)
		{
			var errors = new List<string>();

			try
			{
				// Reload the role from the data source to ensure there are no conflicts
				var role = await _roleManager.FindByIdAsync(id);

				if (role == null)
				{
					errors.Add("Role not found.");
					return (false, errors);
				}

				// Remove user roles from identity role table
				var result = await _roleManager.DeleteAsync(role);

				if (!result.Succeeded)
				{
					foreach (var e in result.Errors)
					{
						errors.Add(e.Description);
					}

					return (false, errors);
				}

				return (true, errors);
			}
			catch (Exception ex)
			{
				errors.Add(ex.Message);
				return (false, errors);
			}
		}

		/// <summary>
		/// Get roles as select list
		/// </summary>
		/// <returns></returns>
		public async Task<List<SelectListItem>> RolesSelectList()
		{
			// Fetch all roles
			var roles = await _roleManager.Roles
										.Select(x => new SelectListItem
										{
											Value = x.Id,
											Text  = x.Name 
										}).ToListAsync();

			return roles;
		}

		#region Users vs Roles

		/// <summary>
		/// Assign or Un assign user role  
		/// </summary>
		/// <param name="userRole"></param>
		/// <param name="removeRole"></param>
		/// <returns></returns>
		public async Task<(bool success, List<string> errors)> AssignRoleAsync(ViewUsersVsRoles userRole, bool removeRole = false)
		{
			var errors = new List<string>();

			try
			{
				// Fetch the user by id
				var user = await _userManager.FindByIdAsync(userRole.UserId);

				if (user == null)
				{
					errors.Add("User not found.");
					return (false, errors);
				}

				// Fetch the roles by id
				var role = await _roleManager.FindByIdAsync(userRole.RoleId);

				if (role == null)
				{
					errors.Add("Role not found.");
					return (false, errors);
				}

				// Check if the user is already in the specified role
				var isInRole = await _userManager.IsInRoleAsync(user, role.Name);

				var result = new IdentityResult();

				if (removeRole)
				{
					if (!isInRole)
					{
						errors.Add("The role isn't assigned to un assign.");
						return (false, errors);
					}

					// Assign the role to the user
					result = await _userManager.RemoveFromRoleAsync(user, role.Name);
				}
				else
				{
					if (isInRole)
					{
						errors.Add("The role is already assigned.");
						return (false, errors);
					}

					// Assign the role to the user
					result = await _userManager.AddToRoleAsync(user, role.Name);
				}
				
				if (!result.Succeeded)
				{
					foreach (var e in result.Errors)
					{
						errors.Add(e.Description);
					}

					return (false, errors);
				}

				return (true, errors);

			}
			catch (Exception ex)
			{
				errors.Add(ex.Message);
				return (false, errors);
			}
		}

		#endregion
	}
}
