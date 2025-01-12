using AuthLayer.Interfaces;
using DbLayer.Helpers;
using DbLayer.Interfaces.Patient;
using DbLayer.Models;
using DbLayer.Models.Patient;
using ServiceLayer.Interfaces.Patient;
using System.Web.Mvc;

namespace ServiceLayer.Services.Patient
{
	public class PatientsService : BaseService, IPatientsService
	{
		private readonly IPatientsRepository _patient;
		private readonly IAccountService _account;

		public PatientsService(IPatientsRepository patient, IAccountService account)
		{
			_patient = patient;
			_account = account;
		}

		/// <summary>
		/// Load patients list
		/// </summary>
		/// <returns></returns>
		public async Task<List<Patients>> ListAsync()
		{
			return await _patient.ListAsync();
		}

		/// <summary>
		/// Get patient details by user uuid
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		public async Task<Patients> DetailsAsync(int id)
		{
			return await _patient.DetailsAsync(id);
		}

		/// <summary>
		/// Get patient details by user uuid
		/// </summary>
		/// <param name="userUuid"></param>
		/// <returns></returns>
		public async Task<Patients> DetailsAsync(string userUuid)
		{
			return await _patient.DetailsAsync(userUuid);
		}

		/// <summary>
		/// Add patients to the database
		/// </summary>
		/// <param name="model"></param>
		/// <returns></returns>
		public async Task<string> AddAsync(Patients model, ICurrentUser user)
		{
			var result = BindRegistrationDetails(model);

			if (result == null)
				return "Registration details missing";

			AddAudit(model, user);
			return await _patient.AddAsync(model);
		}

		/// <summary>
		/// Update patient record finding by id
		/// </summary>
		/// <param name="model"></param>
		/// <returns></returns>
		public async Task<string> UpdateAsync(Patients model, ICurrentUser user)
		{
			var result = BindRegistrationDetails(model);

			if (result == null)
				return "Registration details missing";

			UpdateAudit(model, user);
			return await _patient.UpdateAsync(model);
		}

		/// <summary>
		/// Delete patient record by id
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		public async Task<string> DeleteAsync(int id)
		{
			return await _patient.DeleteAsync(id);
		}

		/// <summary>
		/// Patient Select list item
		/// </summary>
		/// <returns></returns>
		public async Task<List<SelectListItem>> PatientSelectList()
		{
			var result = await _patient.ListAsync();

			if(!result.Any())
				return new List<SelectListItem>();

			var list = result.Select(x => new SelectListItem
			{
				Value = x.PatientUuid,
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
		private async Task<Patients> BindRegistrationDetails(Patients model)
		{
			var result = await _account.DetailsAsync(model.PatientUuid);

			if (result == null)
				return new Patients();

			model.FirstName = result.FirstName;
			model.LastName = result.LastName;
			model.Address = result.Address;
			model.PhoneNo = result.PhoneNo;

			return model;
		}
	}
}
