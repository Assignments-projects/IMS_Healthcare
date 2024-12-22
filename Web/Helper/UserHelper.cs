using AuthLayer.Helpers;
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

            return new CurrentUser
            {
                UserId    = _httpContextAcc.HttpContext.User.FindFirstValue(nameof(LoggedUser.Id)),
                FirstName = _httpContextAcc.HttpContext.User.FindFirstValue(nameof(LoggedUser.FirstName)),
                LastName  = _httpContextAcc.HttpContext.User.FindFirstValue(nameof(LoggedUser.LastName)),
                Email     = _httpContextAcc.HttpContext.User.FindFirstValue(nameof(LoggedUser.Email)),
                Roles     = _httpContextAcc.HttpContext.User.FindAll(ClaimTypes.Role).Select(roleClaim => roleClaim.Value).ToList()
            };
        }
    }
}
