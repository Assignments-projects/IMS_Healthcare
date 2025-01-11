using AuthLayer.Helpers;
using System.Security.Claims;

namespace Web.Helper
{
	public class AuthorizationMiddleware
	{
		private readonly RequestDelegate _next;

		public AuthorizationMiddleware(RequestDelegate next)
		{
			_next = next;
		}

		public async Task InvokeAsync(HttpContext context)
		{
			var user = context.User;

			// Allow account controller
			if (context.Request.Path.StartsWithSegments("/Account"))
			{
				await _next(context);
				return;
			}

			if (user.Identity != null && user.Identity.IsAuthenticated)
			{
				// Check if user is approved
				var isApprovedClaim = user.Claims.FirstOrDefault(c => c.Type == nameof(LoggedUser.IsApproved))?.Value;
				var isApproved      = isApprovedClaim != null && bool.TryParse(isApprovedClaim, out var approved) && approved;

				// Check if user has roles
				var roles = user.Claims.Where(c => c.Type == ClaimTypes.Role).Select(c => c.Value);

				if (!isApproved)
				{
					// Redirect to the error page
					context.Response.Redirect("/Account/AccessDeclined");
					return;
				}
				else if (!roles.Any())
				{
					context.Response.Redirect("/Account/NoUserRoles");
					return;
				}
			}

			// Continue to the next middleware
			await _next(context);
		}
	}
}
