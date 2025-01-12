using AuthLayer.Interfaces;
using DbLayer.Helpers;
using DbLayer.Interfaces;
using DbLayer.Models;
using DbLayer.Models.Patient;
using ServiceLayer.Interfaces;
using System.Web.Mvc;

namespace ServiceLayer.Services
{
	public class StaffService : BaseService, IStaffService
	{
		private readonly IStaffsRepository _staff;
		private readonly IAccountService _account;

		public StaffService(IStaffsRepository staff, IAccountService account)
		{
			_staff = staff;
			_account = account;
		}

		/// <summary>
		/// Load staffs list
		/// </summary>
		/// <returns></returns>
		public async Task<List<Staff>> ListAsync()
		{
			return await _staff.ListAsync();
		}

		/// <summary>
		/// Get staff details by user uuid
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		public async Task<Staff> DetailsAsync(int id)
		{
			return await _staff.DetailsAsync(id);
		}

		/// <summary>
		/// Get staff details by user uuid
		/// </summary>
		/// <param name="userUuid"></param>
		/// <returns></returns>
		public async Task<Staff> DetailsAsync(string userUuid)
		{
			return await _staff.DetailsAsync(userUuid);
		}

		/// <summary>
		/// Add staffs to the database
		/// </summary>
		/// <param name="model"></param>
		/// <returns></returns>
		public async Task<string> AddAsync(Staff model, ICurrentUser user)
		{
			var result = BindRegistrationDetails(model);

			if (result == null)
				return "Registration details missing";

			AddAudit(model, user);
			return await _staff.AddAsync(model);
		}

		/// <summary>
		/// Update staff record finding by id
		/// </summary>
		/// <param name="model"></param>
		/// <returns></returns>
		public async Task<string> UpdateAsync(Staff model, ICurrentUser user)
		{
			var result = BindRegistrationDetails(model);

			if (result == null)
				return "Registration details missing";

			UpdateAudit(model, user);
			return await _staff.UpdateAsync(model);
		}

		/// <summary>
		/// Delete staff record by id
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		public async Task<string> DeleteAsync(int id)
		{
			return await _staff.DeleteAsync(id);
		}

		/// <summary>
		/// Staff Select list item
		/// </summary>
		/// <returns></returns>
		public async Task<List<SelectListItem>> StaffSelectList()
		{
			var result = await _staff.ListAsync();

			if (!result.Any())
				return new List<SelectListItem>();

			var list = result.Select(x => new SelectListItem
			{
				Value = x.StaffUuid,
				Text = $"{x.FirstName} {x.LastName}"
			}).ToList();

			if (!list.Any())
				return new List<SelectListItem>();

			return list;
		}

		/// <summary>
		/// Bind registration details
		/// </summary>
		/// <param name="model"></param>
		/// <returns></returns>
		private async Task<Staff> BindRegistrationDetails(Staff model)
		{
			var result = await _account.DetailsAsync(model.StaffUuid);

			if(result == null)
				return new Staff();

			model.FirstName = result.FirstName;
			model.LastName  = result.LastName;
			model.Address   = result.Address;
			model.PhoneNo   = result.PhoneNo;

			return model;
		}
	}
}
