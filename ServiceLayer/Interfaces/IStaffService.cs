﻿using DbLayer.Models;

namespace ServiceLayer.Interfaces
{
	public interface IStaffService
	{
		/// <summary>
		/// Load staffs list
		/// </summary>
		/// <returns></returns>
		Task<List<Staff>> ListAsync();

		/// <summary>
		/// Get staff details by user uuid
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		Task<Staff> DetailsAsync(int id);

		/// <summary>
		/// Get staff details by user uuid
		/// </summary>
		/// <param name="userUuid"></param>
		/// <returns></returns>
		Task<Staff> DetailsAsync(string userUuid);

		/// <summary>
		/// Add staffs to the database
		/// </summary>
		/// <param name="model"></param>
		/// <returns></returns>
		Task<string> AddAsync(Staff model);

		/// <summary>
		/// Update staff record finding by id
		/// </summary>
		/// <param name="model"></param>
		/// <returns></returns>
		Task<string> UpdateAsync(Staff model);

		/// <summary>
		/// Delete staff record by id
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		Task<string> DeleteAsync(int id);
	}
}
