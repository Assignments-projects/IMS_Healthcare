using DbLayer.Data;
using DbLayer.Interfaces.Patient;
using DbLayer.Models.Patient;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace DbLayer.Repositories.Patient
{
	public class PatientsRepository : BaseRepository, IPatientsRepository
	{
		private readonly IMSDbContext _context;

		public PatientsRepository(IMSDbContext context)
		{
			_context = context;
		}

		/// <summary>
		/// Load patient list
		/// </summary>
		/// <returns></returns>
		public async Task<List<Patients>> ListAsync()
		{
			return await MakePatients(_context.Patients);
		}

		/// <summary>
		/// Get patient details by id
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		public async Task<Patients> DetailsAsync(int id)
		{
			var result = _context.Patients.Where(x => x.PateintId == id);

			return (await MakePatients(result)).FirstOrDefault();
		}

		/// <summary>
		/// Get patient details by user uuid
		/// </summary>
		/// <param name="userUuid"></param>
		/// <returns></returns>
		public async Task<Patients> DetailsAsync(string userUuid)
		{
			var result = _context.Patients.Where(x => x.PatientUuid == userUuid);

			return (await MakePatients(result)).FirstOrDefault();
		}

		/// <summary>
		/// Add patients to the database
		/// </summary>
		/// <param name="model"></param>
		/// <returns></returns>
		public async Task<string> AddAsync(Patients model)
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
		/// Update patient record finding by id
		/// </summary>
		/// <param name="model"></param>
		/// <returns></returns>
		public async Task<string> UpdateAsync(Patients model)
		{
			try
			{
				var exist = await _context.Patients.FindAsync(model.PateintId);

				if (exist == null)
					return NotFound;

				exist.PatientUuid  = model.PatientUuid;
				exist.InChargeuUud = model.InChargeuUud;
				exist.FirstName    = model.FirstName;
				exist.LastName     = model.LastName;
				exist.Address      = model.Address;
				exist.PhoneNo      = model.PhoneNo;
				exist.DateOfBirth  = model.DateOfBirth;
				exist.Comments     = model.Comments;
				exist.Gender       = model.Gender;
				exist.IdentityNo   = model.IdentityNo;
				exist.WardNo       = model.WardNo;
				exist.TotalCost    = model.TotalCost;
				exist.IsDischarged = model.IsDischarged;
				exist.UpdatedById  = model.UpdatedById;
				exist.UpdatedDate  = model.UpdatedDate;

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
		/// Delete patient record by id
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		public async Task<string> DeleteAsync(int id)
		{
			try
			{
				var exist = await _context.Patients.FindAsync(id);

				if (exist == null)
					return NotFound;

				_context.Patients.Remove(exist);

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
		/// Calculate patients total from statement by given id 
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		public async Task<string> CalculatePatientsTotal(string id)
		{
			try
			{
				await _context.Database.ExecuteSqlRawAsync("EXEC [dbo].[SP_UPDATE_PATIENT_TOTAL] @PatientUuid",
															new SqlParameter("PatientUuid", id));

				return null;
			}
			catch (SqlException sqlEx)
			{
				return sqlEx.Message;
			}
			catch (Exception ex)
			{
				return ex.Message;
			}
		}

		/// <summary>
		/// Make List of patients with aditional datas
		/// </summary>
		/// <param name="found"></param>
		/// <returns></returns>
		private async Task<List<Patients>> MakePatients(IQueryable<Patients> found)
		{
			var result = await found.Include(x => x.AddedBy)
									.Include(x => x.UpdatedBy)
									.Include(X => X.Staff)
									.AsNoTracking()
									.ToListAsync();
			if (!result.Any())
				return new List<Patients>();

			AddAuditNames(result);
			return result;
		}

		/// <summary>
		/// Not found message
		/// </summary>
		private string NotFound => "The patient not found.";
	}
}
