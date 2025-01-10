using DbLayer.Helpers;
using DbLayer.Interfaces.Patient;
using DbLayer.Models.Patient;
using ServiceLayer.Interfaces.Patient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Services.Patient
{
	public class PrescriptionService : BaseService, IPrescriptionService
	{
		private readonly IPrescriptionRepository _prescription;

		public PrescriptionService(IPrescriptionRepository prescription)
		{
			_prescription = prescription;
		}

		/// <summary>
		/// Load prescription list
		/// </summary>
		/// <returns></returns>
		public async Task<List<Prescription>> ListAsync()
		{
			return await _prescription.ListAsync();
		}

		/// <summary>
		/// Get prescription details by id
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		public async Task<Prescription> DetailsAsync(int id)
		{
			return await _prescription.DetailsAsync(id);
		}

		/// <summary>
		/// Add prescription to the database
		/// </summary>
		/// <param name="model"></param>
		/// <returns></returns>
		public async Task<string> AddAsync(Prescription model, ICurrentUser user)
		{
			AddAudit(model, user);
			return await _prescription.AddAsync(model);
		}

		/// <summary>
		/// Update prescription record finding by id
		/// </summary>
		/// <param name="model"></param>
		/// <returns></returns>
		public async Task<string> UpdateAsync(Prescription model, ICurrentUser user)
		{
			UpdateAudit(model, user);
			return await _prescription.UpdateAsync(model);
		}

		/// <summary>
		/// Delete prescription record by id
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		public async Task<string> DeleteAsync(int id)
		{
			return await _prescription.DeleteAsync(id);
		}
	}
}
