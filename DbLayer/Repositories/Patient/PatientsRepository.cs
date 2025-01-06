using DbLayer.Data;
using DbLayer.Interfaces.Patient;
using DbLayer.Models.Patient;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace DbLayer.Repositories.Patient
{
	public class PatientsRepository : IPatientsRepository
	{
		private readonly IMSDbContext _context;

		public PatientsRepository(IMSDbContext context)
		{
			_context = context;
		}

		/// <summary>
		/// Load patients list
		/// </summary>
		/// <returns></returns>
		public async Task<List<Patients>> ListAsync()
		{
			var result = await _context.Patients.ToListAsync();

			if (!result.Any())
				return new List<Patients>();

			return result;
		}

		/// <summary>
		/// Get patient details by user uuid
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		public async Task<Patients> DetailsAsync(int id)
		{
			var result = await _context.Patients.FindAsync(id);

			if (result == null)
				return new Patients();

			return result;
		}

		/// <summary>
		/// Get patient details by user uuid
		/// </summary>
		/// <param name="userUuid"></param>
		/// <returns></returns>
		public async Task<Patients> DetailsAsync(string userUuid)
		{
			var result = await _context.Patients.FirstOrDefaultAsync(x => x.UserUuid == userUuid);

			if (result == null)
				return new Patients();

			return result;
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

				exist.UserUuid = model.UserUuid;
				exist.FirstName = model.FirstName;
				exist.LastName = model.LastName;
				exist.Address = model.Address;
				exist.PhoneNo = model.PhoneNo;
				exist.DateOfBirth = model.DateOfBirth;
				exist.Comments = model.Comments;
				exist.Gender = model.Gender;
				exist.IdentityNo = model.IdentityNo;
				exist.TotalCost = model.TotalCost;
				exist.IsDischarged = model.IsDischarged;
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
		/// Not found message
		/// </summary>
		private string NotFound => "The patient not found.";
	}
}
