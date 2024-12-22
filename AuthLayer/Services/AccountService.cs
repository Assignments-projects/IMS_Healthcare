using AuthLayer.Helpers;
using AuthLayer.Interfaces;
using AuthLayer.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using System.Linq;
using System.Security.Claims;

namespace AuthLayer.Services
{
    public class AccountService : IAccountService
    {
        private readonly SignInManager<AppUser> _signInManager;
        private readonly UserManager<AppUser> _userManager;
        private readonly IUserStore<AppUser> _userStore;
        private readonly IUserEmailStore<AppUser> _emailStore;

        public AccountService(
            SignInManager<AppUser> signInManager,
            UserManager<AppUser> userManager,
            IUserStore<AppUser> userStore)
        {
            _signInManager = signInManager;
            _userManager   = userManager;
            _userStore     = userStore;
            _emailStore    = GetEmailStore();
        }

        /// <summary>
        /// Login with the user entered details
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<string> Login(Login model)
        {
            var user = await _userManager.FindByNameAsync(model.Email);

            if (user == null)
                user = await _userManager.FindByEmailAsync(model.Email);

            if (user != null)
            {
                var result = await _signInManager.PasswordSignInAsync(user.UserName, model.Password, model.RememberMe, lockoutOnFailure: false);

                if (!result.Succeeded)
                    return "Invalid login attempt";

                else if (result.IsLockedOut)
                    return "Your account is not approved at the movement. Please contact admin";

                if (user.Id == null)
                    return "Something went wrong! please try again later";

                var customClaims = new List<Claim>
                {
                    new Claim(nameof(LoggedUser.Id), user.Id.ToString()),
                    new Claim(nameof(LoggedUser.FirstName), user.FirstName ?? ""),
                    new Claim(nameof(LoggedUser.LastName), user.LastName ?? ""),
                    new Claim(nameof(LoggedUser.Email), user.Email ?? ""),
                };

                // Get user roles
                var roles = await _userManager.GetRolesAsync(user);

                if (roles.Any())
                {
                    foreach (var role in roles)
                    {
                        customClaims.Add(new Claim(ClaimTypes.Role, role));
                    }
                }

                var claimsIdentity  = new ClaimsIdentity(customClaims, IdentityConstants.ApplicationScheme);
                var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);

                await _signInManager.Context.SignInAsync(IdentityConstants.ApplicationScheme, claimsPrincipal);

                return null;
            }
            else
                return "Invalid login attempt";

        }

        /// <summary>
        /// Register User account to the system
        /// </summary>
        /// <returns></returns>
        public async Task<(bool, List<string>)> Register(Register model)
        {
            var user = CreateUser();
            var username = model.UserName ?? model.Email;

            // Bind custom data to identity user
            user.FirstName   = model.FirstName;
            user.LastName    = model.LastName;
            user.Address     = model.Address;
            user.PhoneNumber = model.PhoneNo;

            await _userStore.SetUserNameAsync(user, username, CancellationToken.None);
            await _emailStore.SetEmailAsync(user, model.Email, CancellationToken.None);

            var result = await _userManager.CreateAsync(user, model.Password);

            if (!result.Succeeded)
            {
                List<string> errors = new();

                foreach (var e in result.Errors)
                {
                    errors.Add(e.Description);
                }

                return (false, errors);
            }

            return (true, new List<string>());
        }

        /// <summary>
        /// Logout from application
        /// </summary>
        public async void Logout()
        {
            await _signInManager.SignOutAsync();
        }

        #region Helper methods

        /// <summary>
        /// Create a App User Instance to use AppUser and Identity User properties
        /// </summary>
        /// <returns></returns>
        /// <exception cref="InvalidOperationException"></exception>
        private AppUser CreateUser()
        {
            try
            {
                return Activator.CreateInstance<AppUser>();
            }
            catch
            {
                throw new InvalidOperationException($"Can't create an instance of '{nameof(AppUser)}'. " +
                    $"Ensure that '{nameof(AppUser)}' is not an abstract class and has a parameterless constructor");
            }
        }

        /// <summary>
        /// Get email to store
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NotSupportedException"></exception>
        private IUserEmailStore<AppUser> GetEmailStore()
        {
            if (!_userManager.SupportsUserEmail)
            {
                throw new NotSupportedException("The default UI requires a user store with email support.");
            }
            return (IUserEmailStore<AppUser>)_userStore;
        }

        #endregion
    }
}
