using DbLayer.Data;
using DbLayer.Helpers;
using DbLayer.Interfaces;
using DbLayer.Models;
using Microsoft.EntityFrameworkCore;

namespace DbLayer.Repositories
{
	public class HomeRepository : BaseRepository, IHomeRepository
	{
		private readonly IMSDbContext _context;

		public HomeRepository(IMSDbContext context)
		{
			_context = context;
		}

		/// <summary>
		/// Get dashboard details for admin
		/// </summary>
		/// <param name="user"></param>
		/// <returns></returns>
		public async Task<Dashboard> AdminDetailsAsync(ICurrentUser user)
		{
			return await MakeDashboardStats();
		}

		/// <summary>
		/// Get dashboard details for patient
		/// </summary>
		/// <param name="user"></param>
		/// <returns></returns>
		public async Task<Dashboard> PatientDetailsAsync(ICurrentUser user)
		{
			var result = await MakeDashboardStats();

			result.TotalDiseases = await _context.Diseases.Where(x => x.PatientUuid == user.UserId).CountAsync();

			return result;
		}

		/// <summary>
		/// Get dashboard details for staff
		/// </summary>
		/// <param name="user"></param>
		/// <returns></returns>
		public async Task<Dashboard> StaffDetailsAsync(ICurrentUser user)
		{
			var result = await MakeDashboardStats();

			result.TotalDiseases = await _context.Diseases.Where(x => x.DoctorId == user.UserId).CountAsync();
			result.TotalPatients = await _context.Patients.Where(x => x.InChargeuUud == user.UserId).CountAsync();

			return result;
		}

		/// <summary>
		/// Make stats of dashboard
		/// </summary>
		/// <returns></returns>
		private async Task<Dashboard> MakeDashboardStats()
		{
			var result = new Dashboard()
			{
				TotalUsers              = await _context.Users.CountAsync(),
				TotalStaffs             = await _context.Staffs.CountAsync(),
				TotalPatients           = await _context.Patients.CountAsync(),
				TotalAdmins             = await _context.ViewUsersVsRoles.Where(x => x.RoleName == nameof(UserRole.Admin)).CountAsync(),
				TotalActiveUsers        = await _context.Users.Where(x => x.IsApproved).CountAsync(),
				TotalActivePatients     = await _context.Patients.Where(x => !x.IsDischarged).CountAsync(),
				TotalDischargedPatients = await _context.Patients.Where(x => x.IsDischarged).CountAsync(),
				TotalDiseases           = await _context.Diseases.CountAsync(),
			};

			if (result == null)
				return new Dashboard();

			return result;
		}
	}
}
