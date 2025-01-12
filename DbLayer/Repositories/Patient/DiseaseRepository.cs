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
	public class DiseaseRepository : BaseRepository, IDiseaseRepository
	{
		private readonly IMSDbContext _context;

		public DiseaseRepository(IMSDbContext context)
		{
			_context = context;
		}

		/// <summary>
		/// Load disease list
		/// </summary>
		/// <returns></returns>
		public async Task<List<Disease>> ListAsync()
		{
			return await MakeDiseases(_context.Diseases);
		}

		/// <summary>
		/// Load disease list for patient
		/// </summary>
		/// <param name="patientUuid"></param>
		/// <returns></returns>
		public async Task<List<Disease>> ListAsync(string patientUuid)
		{
			return await MakeDiseases(_context.Diseases.Where(x => x.PatientUuid == patientUuid));
		}

		/// <summary>
		/// Get disease details by id
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		public async Task<Disease> DetailsAsync(int id)
		{
			var result = _context.Diseases.Where(x => x.DiseaseId == id);

			return (await MakeDiseases(result)).FirstOrDefault();
		}

		/// <summary>
		/// Add disease to the database
		/// </summary>
		/// <param name="model"></param>
		/// <returns></returns>
		public async Task<string> AddAsync(Disease model)
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
		/// Update disease record finding by id
		/// </summary>
		/// <param name="model"></param>
		/// <returns></returns>
		public async Task<string> UpdateAsync(Disease model)
		{
			try
			{
				var exist = await _context.Diseases.FindAsync(model.DiseaseId);

				if (exist == null)
					return NotFound;

				exist.DiseaseTypeId = model.DiseaseTypeId;
				exist.PatientUuid   = model.PatientUuid;
				exist.DoctorId      = model.DoctorId;
				exist.DiseaseSpec   = model.DiseaseSpec;
				exist.Comments      = model.Comments;
				exist.UpdatedById   = model.UpdatedById;
				exist.UpdatedDate   = model.UpdatedDate;

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
		/// Delete disease record by id
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		public async Task<string> DeleteAsync(int id)
		{
			try
			{
				var exist = await _context.Diseases.FindAsync(id);

				if (exist == null)
					return NotFound;

				_context.Diseases.Remove(exist);

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
		/// Make List of disease with aditional datas
		/// </summary>
		/// <param name="found"></param>
		/// <returns></returns>
		private async Task<List<Disease>> MakeDiseases(IQueryable<Disease> found)
		{
			var result = await found.Include(x => x.AddedBy)
									.Include(x => x.UpdatedBy)
									.Include(x => x.Patient)
									.Include(x => x.DiseaseType)
									.Include(x => x.Doctor)
									.AsNoTracking()
									.ToListAsync();
			if (!result.Any())
				return new List<Disease>();

			AddAuditNames(result);
			return result;
		}

		/// <summary>
		/// Not found message
		/// </summary>
		private string NotFound => "The disease not found.";
	}
}
