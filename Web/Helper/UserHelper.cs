using AuthLayer.Helpers;
using DbLayer.Helpers;
using System.Security.Claims;
using Web.Models;

namespace Web.Helper
{
    public static class UserHelper
    {
        private static IHttpContextAccessor _httpContextAcc;

		public static void Initialize(IHttpContextAccessor httpContextAcc)
		{
			_httpContextAcc = httpContextAcc;
		}

		/// <summary>
		/// Get current user details from claims
		/// </summary>
		/// <returns></returns>
		/// <exception cref="UnauthorizedAccessException"></exception>
		public static CurrentUser GetCurrentUser()
        {
            if (_httpContextAcc.HttpContext?.User == null)
                throw new UnauthorizedAccessException();

			// Parse IsApproved string to bool and out the result
			bool.TryParse(_httpContextAcc.HttpContext.User.FindFirstValue(nameof(LoggedUser.IsApproved)), out bool result);

            return new CurrentUser
            {
                UserId         = _httpContextAcc.HttpContext.User.FindFirstValue(nameof(LoggedUser.Id)),
                FirstName      = _httpContextAcc.HttpContext.User.FindFirstValue(nameof(LoggedUser.FirstName)),
                LastName       = _httpContextAcc.HttpContext.User.FindFirstValue(nameof(LoggedUser.LastName)),
				FullName       = _httpContextAcc.HttpContext.User.FindFirstValue(nameof(LoggedUser.FullName)),
				Email          = _httpContextAcc.HttpContext.User.FindFirstValue(nameof(LoggedUser.Email)),
				ProfilePicPath = _httpContextAcc.HttpContext.User.FindFirstValue(nameof(LoggedUser.ProfilePicture)),
				Roles		   = _httpContextAcc.HttpContext.User.FindAll(ClaimTypes.Role).Select(roleClaim => roleClaim.Value).ToList(),
				IsApproved	   = result,
			};
        }

		/// <summary>
		/// Get role of current user
		/// </summary>
		/// <returns></returns>
		/// <exception cref="ArgumentNullException"></exception>
		public static CurrentUserRole GetCurrentRole()
		{
			if (_httpContextAcc.HttpContext?.User == null)
				throw new ArgumentNullException();

			var roles = _httpContextAcc.HttpContext.User.FindAll(ClaimTypes.Role).Select(roleClaim => roleClaim.Value).ToList();

			if (roles == null || !roles.Any())
				return new CurrentUserRole
				{
					IsAdmin  = false,
					IsPatient = false,
					IsStaff = false
				};

			return new CurrentUserRole
			{
				IsAdmin    = roles.Any(x => x == nameof(UserRole.Admin)),
				IsStaff    = roles.All(x => x != nameof(UserRole.Admin)) && roles.Any(x => x != nameof(UserRole.Patient)),
				IsPatient  = roles.All(x => x == nameof(UserRole.Patient))
			};
		}
    }
}
