using DbLayer.Helper;
using DbLayer.Helpers;

namespace ServiceLayer.Services
{
	public class BaseService
	{
		/// <summary>
		/// Add audit details on add new record
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="obj"></param>
		/// <param name="user"></param>
		protected void AddAudit<T>(T obj, ICurrentUser user) where T : IAuditCurrent
		{
			if (obj == null || user == null) return;

			obj.AddedById   = user.UserId;
			obj.UpdatedById = user.UserId;
			obj.AddedDate   = DateTime.Now;
			obj.UpdatedDate = DateTime.Now;
		}

		/// <summary>
		/// Add audit details on update new record
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="obj"></param>
		/// <param name="user"></param>
		protected void UpdateAudit<T>(T obj, ICurrentUser user) where T : IAuditCurrent
		{
			if (obj == null || user == null) return;

			obj.UpdatedById = user.UserId;
			obj.UpdatedDate = DateTime.Now;
		}

		/// <summary>
		/// Check the current user has admin role
		/// </summary>
		/// <param name="user"></param>
		/// <returns></returns>
		protected bool IsAdmin(ICurrentUser user)
		{
			if (!user.Roles.Any())
				return false;

			return user.Roles.Contains(nameof(UserRole.Admin));
		}

		/// <summary>
		/// Check the current user has patient role
		/// </summary>
		/// <param name="user"></param>
		/// <returns></returns>
		protected bool IsPatient(ICurrentUser user)
		{
			if (!user.Roles.Any())
				return false;

			return user.Roles.Count == 1 && user.Roles.Contains(nameof(UserRole.Patient));
		}

		/// <summary>
		/// Check the current user has no admin and patient role
		/// </summary>
		/// <param name="user"></param>
		/// <returns></returns>
		protected bool IsStaff(ICurrentUser user)
		{
			if (!user.Roles.Any())
				return false;

			return !user.Roles.Contains(nameof(UserRole.Patient)) &&
				   !user.Roles.Contains(nameof(UserRole.Admin));
		}
	}
}
