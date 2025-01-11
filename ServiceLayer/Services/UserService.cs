using AuthLayer.Interfaces;
using AuthLayer.Models;
using DbLayer.Helpers;
using DbLayer.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ServiceLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace ServiceLayer.Services
{
	public class UserService : IUserService
	{
		private readonly IUsersRepository _user;
		private readonly IAccountService _account;

		public UserService(IUsersRepository user, IAccountService account) 
		{
			_user    = user;
			_account = account;
		}

		/// <summary>
		/// Login with the user entered details
		/// </summary>
		/// <param name="model"></param>
		/// <returns></returns>
		public async Task<string> Login(Login model)
		{
			return await _account.Login(model);
		}

		/// <summary>
		/// Register User account to the system
		/// </summary>
		/// <returns></returns>
		public async Task<AuthResults> Register(Register model)
		{
			var results = await _account.Register(model);

			if (results.Success)
			{
				var error = await _user.UpdateUserFromIdentity(results.Out);

				if (!string.IsNullOrEmpty(error))
				{
					results.Errors.Add(error);
					results.Success = false;
				}
			}

			return results;
		}

		/// <summary>
		/// Logout from application
		/// </summary>
		public async void Logout()
		{
			_account.Logout();
		}

		/// <summary>
		/// Load application users list
		/// </summary>
		/// <returns></returns>
		public async Task<List<AppUser>> ListAsync()
		{
			return await _account.ListAsync();
		}

		/// <summary>
		/// Load Pending or approved application users list
		/// </summary>
		/// <param name="isApproved"></param>
		/// <returns></returns>
		public async Task<List<AppUser>> ListAsync(bool isApproved)
		{
			return await _account.ListAsync(isApproved);
		}

		/// <summary> as a list
		/// Get user details by id
		/// </summary>
		/// <returns></returns>
		public async Task<AppUser> DetailsAsync(string id)
		{
			return await _account.DetailsAsync(id);
		}

		/// <summary>
		/// Register User account to the system
		/// </summary>
		/// <returns></returns>
		public async Task<AuthResults> AddAsync(AppUser model)
		{
			var results =  await _account.AddAsync(model);

			if (results.Success)
			{
				var error = await _user.UpdateUserFromIdentity(results.Out);

				if (!string.IsNullOrEmpty(error))
				{
					results.Errors.Add(error);
					results.Success = false;
				}
			}

			return results;
		}

		/// <summary>
		/// Update exisiting user
		/// </summary>
		/// <param name="user"></param>
		/// <returns></returns>
		public async Task<AuthResults> UpdateAsync(AppUser user)
		{
			var results =  await _account.UpdateAsync(user);

			if (results.Success)
			{
				var error = await _user.UpdateUserFromIdentity(results.Out, true);

				if (!string.IsNullOrEmpty(error))
				{
					results.Errors.Add(error);
					results.Success = false;
				}
			}

			return results;
		}

		/// <summary>
		/// Approve pending user by user id
		/// </summary>
		/// <param name="role"></param>
		/// <returns></returns>
		public async Task<AuthResults> ApproveUserAsync(string id, bool isApprove)
		{
			var results = await _account.ApproveUserAsync(id, isApprove);

			if (results.Success)
			{
				var error = await _user.UpdateUserFromIdentity(results.Out, true);

				if (!string.IsNullOrEmpty(error))
				{
					results.Errors.Add(error);
					results.Success = false;
				}
			}

			return results;
		}


		/// <summary>
		/// Update profile picture by user id
		/// </summary>
		/// <param name="id"></param>
		/// <param name="picturePath"></param>
		/// <returns></returns>
		public async Task<AuthResults> UpdateProfilePic(string id, string picturePath)
		{
			var results = await _account.UpdateProfilePic(id, picturePath);

			if (results.Success)
			{
				var error = await _user.UpdateUserFromIdentity(results.Out, true);

				if (!string.IsNullOrEmpty(error))
				{
					results.Errors.Add(error);
					results.Success = false;
				}
			}

			return results;
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

		/// <summary>
		/// Get User Select list item belongs to the user
		/// </summary>
		/// <param name="role"></param>
		/// <returns></returns>
		public async Task<List<SelectListItem>> UserBasedOnRoleList(UserRole role)
		{
			var result = await _user.UserRolesListAsync();
			var list   = new List<SelectListItem>();

			if(!result.Any())
				return new List<SelectListItem>();

			if (role == UserRole.Admin || role == UserRole.Patient)
			{
				list = result.Where(x => x.RoleName == role.ToString())
							 .Select(x => new SelectListItem
							 {
								Value = x.UserId,
								Text = $"{x.FirstName} {x.LastName}"
							 }).ToList();
			}
			else
			{
				list = result.Where(x => x.RoleName != nameof(UserRole.Admin) && x.RoleName != nameof(UserRole.Patient))
							 .Select(x => new SelectListItem
							 {
								 Value = x.UserId,
								 Text = $"{x.FirstName} {x.LastName} - {x.RoleName}"
							 }).ToList();
			}

			if (!list.Any())
				return new List<SelectListItem>();

			return list;
		}
	}
}
