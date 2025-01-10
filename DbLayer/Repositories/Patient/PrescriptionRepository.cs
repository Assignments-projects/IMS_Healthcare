using DbLayer.Data;
using DbLayer.Interfaces.Patient;
using DbLayer.Models.Patient;
using DbLayer.Models.Settings;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbLayer.Repositories.Patient
{
	public class PrescriptionRepository : BaseRepository, IPrescriptionRepository
	{
		private readonly IMSDbContext _context;

		public PrescriptionRepository(IMSDbContext context)
		{
			_context = context;
		}

		/// <summary>
		/// Load prescription list
		/// </summary>
		/// <returns></returns>
		public async Task<List<Prescription>> ListAsync()
		{
			return await MakePrescriptions(_context.Prescriptions);
		}

		/// <summary>
		/// Get prescription details by id
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		public async Task<Prescription> DetailsAsync(int id)
		{
			var result = _context.Prescriptions.Where(x => x.PrescriptionId == id);

			return (await MakePrescriptions(result)).FirstOrDefault();
		}

		/// <summary>
		/// Add prescription to the database
		/// </summary>
		/// <param name="model"></param>
		/// <returns></returns>
		public async Task<string> AddAsync(Prescription model)
		{
			try
			{
				await _context.AddAsync(model);
				await _context.SaveChangesAsync();
			}
			catch (SqlException sqlEx)
			{
				return sqlEx.Message;
			}
			catch (Exception ex)
			{
				return ex.Message;
			}

			return null;
		}

		/// <summary>
		/// Update prescription record finding by id
		/// </summary>
		/// <param name="model"></param>
		/// <returns></returns>
		public async Task<string> UpdateAsync(Prescription model)
		{
			try
			{
				var exist = await _context.Prescriptions.FindAsync(model.PrescriptionId);

				if (exist == null)
					return NotFound;

				exist.DiseaseId   = model.DiseaseId;
				exist.Medicines   = model.Medicines;
				exist.Description = model.Description;
				exist.Comments    = model.Comments;
				exist.TotalCost   = model.TotalCost;
				exist.UpdatedById = model.UpdatedById;
				exist.UpdatedDate = model.UpdatedDate;

				await _context.SaveChangesAsync();
			}
			catch (SqlException sqlEx)
			{
				return sqlEx.Message;
			}
			catch (Exception ex)
			{
				return ex.Message;
			}

			return null;
		}

		/// <summary>
		/// Delete prescription record by id
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		public async Task<string> DeleteAsync(int id)
		{
			try
			{
				var exist = await _context.Prescriptions.FindAsync(id);

				if (exist == null)
					return NotFound;

				_context.Prescriptions.Remove(exist);

				await _context.SaveChangesAsync();
			}
			catch (SqlException sqlEx)
			{
				return sqlEx.Message;
			}
			catch (Exception ex)
			{
				return ex.Message;
			}

			return null;
		}

		/// <summary>
		/// Make List of prescription type with aditional datas
		/// </summary>
		/// <param name="found"></param>
		/// <returns></returns>
		private async Task<List<Prescription>> MakePrescriptions(IQueryable<Prescription> found)
		{
			var result = await found.Include(x => x.AddedBy)
									.Include(x => x.UpdatedBy)
									.ToListAsync();
			if (!result.Any())
				return new List<Prescription>();

			AddAuditNames(result);
			return result;
		}

		/// <summary>
		/// Not found message
		/// </summary>
		private string NotFound => "The prescription not found.";
	}
}
