using AuthLayer.Helpers;
using AuthLayer.Interfaces;
using AuthLayer.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Security.Claims;
using static System.Runtime.InteropServices.JavaScript.JSType;

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
				if (user.Id == null)
					return "Something went wrong! please try again later";

				else if (!user.IsApproved)
					return "Your account is not approved at the movement. Please contact admin";

				var result = await _signInManager.PasswordSignInAsync(user.UserName, model.Password, model.RememberMe, lockoutOnFailure: false);

                if (!result.Succeeded)
                    return "Invalid login attempt";

                var customClaims = new List<Claim>
                {
                    new Claim(nameof(LoggedUser.Id), user.Id.ToString()),
                    new Claim(nameof(LoggedUser.FirstName), user.FirstName ?? ""),
                    new Claim(nameof(LoggedUser.LastName), user.LastName ?? ""),
	                new Claim(nameof(LoggedUser.FullName), $"{user.FirstName} {user.LastName}" ?? ""),
					new Claim(nameof(LoggedUser.Email), user.Email ?? ""),
		            new Claim(nameof(LoggedUser.ProfilePicture), user.ProfilePicPath ?? ""),
					new Claim(nameof(LoggedUser.IsApproved), user.IsApproved.ToString() ?? "false"),
				};

                // Get user roles and add to the claims
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
        public async Task<AuthResults> Register(Register model)
        {
			var results = new AuthResults();

            var user = CreateUser();
            var username = model.UserName ?? model.Email;

            // Bind custom data to identity user
            user.FirstName   = model.FirstName;
            user.LastName    = model.LastName;
            user.Address     = model.Address;
            user.PhoneNo     = model.PhoneNo;

            await _userStore.SetUserNameAsync(user, username, CancellationToken.None);
            await _emailStore.SetEmailAsync(user, model.Email, CancellationToken.None);

            var result = await _userManager.CreateAsync(user, model.Password);

            if (!result.Succeeded)
            {
                foreach (var e in result.Errors)
                {
                    results.Errors.Add(e.Description);
                }

				results.Success = false;
                return results;
            }

			results.Out = user.Id;
            return results;
        }

        /// <summary>
        /// Logout from application
        /// </summary>
        public async void Logout()
        {
            await _signInManager.SignOutAsync();
        }

		#region Common user methods

        /// <summary>
        /// Load application users list
        /// </summary>
        /// <returns></returns>
        public async Task<List<AppUser>> ListAsync()
        {
			var result = await _userManager.Users.ToListAsync();

			if (!result.Any())
				return new List<AppUser>();

			return result;
		}

		/// <summary>
        /// Load Pending or approved application users list
		/// </summary>
		/// <param name="isApproved"></param>
		/// <returns></returns>
		public async Task<List<AppUser>> ListAsync(bool isApproved)
		{
			var result = await _userManager.Users.Where(x => x.IsApproved == isApproved).ToListAsync();

			if (!result.Any())
				return new List<AppUser>();

			return result;
		}

		/// <summary> as a list
		/// Get user details by id
		/// </summary>
		/// <returns></returns>
		public async Task<AppUser> DetailsAsync(string id)
		{
			var result = await _userManager.FindByIdAsync(id);

			if (result == null)
				return new AppUser();

			return result;
		}

		/// <summary>
		/// Register User account to the system
		/// </summary>
		/// <returns></returns>
		public async Task<AuthResults> AddAsync(AppUser model)
		{
			var results = new AuthResults();

			try
			{
				var user = CreateUser();
				var username = model.UserName ?? model.Email;

				// Bind custom data to identity user
				user.FirstName  = model.FirstName;
				user.LastName   = model.LastName;
				user.Address    = model.Address;
				user.PhoneNo    = model.PhoneNo;
				user.IsApproved = model.IsApproved;

				await _userStore.SetUserNameAsync(user, username, CancellationToken.None);
				await _emailStore.SetEmailAsync(user, model.Email, CancellationToken.None);

				var result = await _userManager.CreateAsync(user, Constants.DEFAULT_PASSWORD);

				if (!result.Succeeded)
				{

					foreach (var e in result.Errors)
					{
						results.Errors.Add(e.Description);
					}

					results.Success = false;
					return results;
				}

				results.Out = user.Id;
				return results;
			}
			catch (Exception ex)
			{
				results.Success = false;
				results.Errors.Add(ex.Message);
				return results;
			}
		}

		/// <summary>
		/// Update exisiting user
		/// </summary>
		/// <param name="user"></param>
		/// <returns></returns>
		public async Task<AuthResults> UpdateAsync(AppUser user)
		{
			var results = new AuthResults();

			try
			{
				// Reload the users from the data source to ensure there are no conflicts
				var existingUser = await _userManager.FindByIdAsync(user.Id);

				if (existingUser == null)
				{
					results.Errors.Add("User not found.");

					results.Success = false;
					return results;
				}

                // Bind model values
				existingUser.FirstName  = user.FirstName;
                existingUser.LastName   = user.LastName;
                existingUser.Email      = user.Email;
                existingUser.Address    = user.Address;
                existingUser.PhoneNo    = user.PhoneNo;
                existingUser.IsApproved = user.IsApproved;
                existingUser.UserName   = user.UserName;

				// Update exisiting users details
				var result = await _userManager.UpdateAsync(existingUser);

				if (!result.Succeeded)
				{
					foreach (var e in result.Errors)
					{
						results.Errors.Add(e.Description);
					}

					results.Success = false;
					return results;
				}

				results.Out = existingUser.Id;
				return results;

			}
			catch (Exception ex)
			{
				results.Success = false;
				results.Errors.Add(ex.Message);
				return results;
			}
		}

		/// <summary>
		/// Approve pending user by user id
		/// </summary>
		/// <param name="role"></param>
		/// <returns></returns>
		public async Task<AuthResults> ApproveUserAsync(string id, bool isApprove)
		{
			var results = new AuthResults();

			try
			{
				// Reload the users from the data source to ensure there are no conflicts
				var existingUser = await _userManager.FindByIdAsync(id);

				if (existingUser == null)
				{
					results.Errors.Add("User not found.");

					results.Success = false;
					return results;
				}

				// Bind model values
				existingUser.IsApproved = isApprove;

				// Update exisiting users details
				var result = await _userManager.UpdateAsync(existingUser);

				if (!result.Succeeded)
				{
					foreach (var e in result.Errors)
					{
						results.Errors.Add(e.Description);
					}

					results.Success = false;
					return results;
				}

				results.Out = existingUser.Id;
				return results;

			}
			catch (Exception ex)
			{
				results.Success = false;
				results.Errors.Add(ex.Message);
				return results;
			}
		}

		/// <summary>
		/// Update profile picture by user id
		/// </summary>
		/// <param name="id"></param>
		/// <param name="picturePath"></param>
		/// <returns></returns>
		public async Task<AuthResults> UpdateProfilePic(string id, string picturePath)
		{
			var results = new AuthResults();

			try
			{
				// Reload the users from the data source to ensure there are no conflicts
				var existingUser = await _userManager.FindByIdAsync(id);

				if (existingUser == null)
				{
					results.Errors.Add("User not found.");

					results.Success = false;
					return results;
				}

				// Bind model values
				existingUser.ProfilePicPath = picturePath;

				// Update exisiting users details
				var result = await _userManager.UpdateAsync(existingUser);

				if (!result.Succeeded)
				{
					foreach (var e in result.Errors)
					{
						results.Errors.Add(e.Description);
					}

					results.Success = false;
					return results;
				}

				results.Out     = existingUser.Id;
				results.Message = existingUser.ProfilePicPath;

				return results;

			}
			catch (Exception ex)
			{
				results.Success = false;
				results.Errors.Add(ex.Message);
				return results;
			}
		}

		#endregion


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
