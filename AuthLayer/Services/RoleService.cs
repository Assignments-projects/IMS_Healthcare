using AuthLayer.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace AuthLayer.Services
{
	public class RoleService : IRoleService
	{
		private readonly RoleManager<IdentityRole> _roleManager;

        public RoleService(RoleManager<IdentityRole> roleManager)
        {
            _roleManager = roleManager;
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

		/// <summary> as a list
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
	}
}
