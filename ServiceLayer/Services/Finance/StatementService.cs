using DbLayer.Helpers;
using DbLayer.Interfaces.Finance;
using DbLayer.Interfaces.Patient;
using DbLayer.Models.Finance;
using Microsoft.EntityFrameworkCore;
using ServiceLayer.Interfaces.Finance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace ServiceLayer.Services.Finance
{
	public class StatementService : BaseService, IStatementService
	{
		private readonly IStatementRepository _statement;
		private readonly IPatientsRepository _patient;

		public StatementService(IStatementRepository statement, IPatientsRepository patients)
		{
			_statement = statement;
			_patient   = patients;
		}

		/// <summary>
		/// Load statement list
		/// </summary>
		/// <returns></returns>
		public async Task<List<Statement>> ListAsync()
		{
			return await _statement.ListAsync();
		}

		/// <summary>
		/// Load statement list for patient uuid
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		public async Task<List<Statement>> ListAsync(string id)
		{
			return await _statement.ListAsync(id);
		}

		/// <summary>
		/// Get statement details by id
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		public async Task<Statement> DetailsAsync(int id)
		{
			return await _statement.DetailsAsync(id);
		}

		/// <summary>
		/// Add statement to the database
		/// </summary>
		/// <param name="model"></param>
		/// <returns></returns>
		public async Task<string> AddAsync(Statement model, ICurrentUser user)
		{
			var exist = await _statement.ListAsync(model.PatientUuid);

			if (exist.Any())
				return "The statement already created for the patient you selected.";

			AddAudit(model, user);
			return await _statement.AddAsync(model);
		}

		/// <summary>
		/// Update statement record finding by id
		/// </summary>
		/// <param name="model"></param>
		/// <returns></returns>
		public async Task<string> UpdateAsync(Statement model, ICurrentUser user)
		{
			UpdateAudit(model, user);
			return await _statement.UpdateAsync(model);
		}

		/// <summary>
		/// Delete statement record by id
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		public async Task<string> DeleteAsync(int id)
		{
			return await _statement.DeleteAsync(id);
		}

		/// <summary>
		/// Calculate statement total from statement item by given id
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		public async Task<string> CalculateStatementsTotal(int id)
		{
			var statement = await _statement.DetailsAsync(id);

			if (statement == null)
				return NotFound;

			return await _statement.CalculateStatementsTotal(id);
		}

		/// <summary>
		/// status Select list item
		/// </summary>
		/// <returns></returns>
		public async Task<List<SelectListItem>> StatusSelectList()
		{
			var result = await _statement.ListStatusAsync();

			if (!result.Any())
				return new List<SelectListItem>();

			var list = result.Select(x => new SelectListItem
			{
				Value = x.StatusId.ToString(),
				Text = x.Status
			}).ToList();

			if (!list.Any())
				return new List<SelectListItem>();

			return list;
		}

		/// <summary>
		/// Not found message
		/// </summary>
		private string NotFound => "The statement not found.";

	}
}
