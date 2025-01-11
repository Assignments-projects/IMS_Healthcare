using AuthLayer.Helpers;
using AuthLayer.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace Web.Helper
{
    public class RefreshClaimsMiddleware
    {
        private readonly RequestDelegate _next;

        public RefreshClaimsMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context, UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
			if (context.User.Identity.IsAuthenticated)
			{
				var userId = context.User.FindFirst(nameof(LoggedUser.Id))?.Value;

				if (!string.IsNullOrEmpty(userId))
				{
					var user = await userManager.FindByIdAsync(userId);

					if (user != null)
					{
						// Create updated claims for the user
						var updatedClaims = new List<Claim>
						{
							new Claim(nameof(LoggedUser.Id), user.Id),
							new Claim(nameof(LoggedUser.FirstName), user.FirstName ?? ""),
							new Claim(nameof(LoggedUser.LastName), user.LastName ?? ""),
							new Claim(nameof(LoggedUser.FullName), $"{user.FirstName} {user.LastName}".Trim()),
							new Claim(nameof(LoggedUser.Email), user.Email ?? ""),
							new Claim(nameof(LoggedUser.ProfilePicture), user.ProfilePicPath ?? ""),
							new Claim(nameof(LoggedUser.IsApproved), user.IsApproved.ToString() ?? "false")
						};

						// Fetch updated roles and add them as claims
						var updatedRoles = await userManager.GetRolesAsync(user);
						updatedClaims.AddRange(updatedRoles.Select(role => new Claim(ClaimTypes.Role, role)));

						// Fetch current claims
						var currentClaims = context.User.Claims.ToList();

						// Detect any changes between current and updated claims
						var claimsChanged = currentClaims.Count != updatedClaims.Count ||
											!updatedClaims.All(uc =>
												currentClaims.Any(cc => cc.Type == uc.Type && cc.Value == uc.Value));

						if (claimsChanged)
						{
							// Update claims and sign the user in again
							var claimsIdentity = new ClaimsIdentity(updatedClaims, IdentityConstants.ApplicationScheme);
							var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);

							await signInManager.Context.SignInAsync(IdentityConstants.ApplicationScheme, claimsPrincipal);
						}
					}
				}
			}

			await _next(context);
		}
    }
}
