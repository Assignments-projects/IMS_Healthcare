using DbLayer.Interfaces.Patient;
using DbLayer.Models;
using DbLayer.Models.Patient;
using ServiceLayer.Interfaces.Patient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Services.Patient
{
	public class PatientsService : IPatientsService
	{
		private readonly IPatientsRepository _patient;

		public PatientsService(IPatientsRepository patient)
		{
			_patient = patient;
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
		public async Task<string> AddAsync(Patients model)
		{
			return await _patient.AddAsync(model);
		}

		/// <summary>
		/// Update patient record finding by id
		/// </summary>
		/// <param name="model"></param>
		/// <returns></returns>
		public async Task<string> UpdateAsync(Patients model)
		{
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
	}
}
