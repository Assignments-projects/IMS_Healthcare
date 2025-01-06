using AuthLayer.Models;

namespace AuthLayer.Interfaces
{
    public interface IAccountService
    {
        /// <summary>
        /// Login with the user details
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<string> Login(Login model);

		/// <summary>
		/// Register User account to the system
		/// </summary>
		/// <returns></returns>
		Task<AuthResults> Register(Register model);

        /// <summary>
        /// Logout from application
        /// </summary>
        void Logout();

        #region Common user methods

        /// <summary>
        /// Load application users list
        /// </summary>
        /// <returns></returns>
        Task<List<AppUser>> ListAsync();

        /// <summary>
        /// Load Pending or approved application users list
        /// </summary>
        /// <param name="isApproved"></param>
        /// <returns></returns>
        Task<List<AppUser>> ListAsync(bool isApproved);

        /// <summary> as a list
        /// Get user details by id
        /// </summary>
        /// <returns></returns>
        Task<AppUser> DetailsAsync(string id);


        /// <summary>
        /// Register User account to the system
        /// </summary>
        /// <returns></returns>
        Task<AuthResults> AddAsync(AppUser model);

		/// <summary>
		/// Update exisiting user
		/// </summary>
		/// <param name="user"></param>
		/// <returns></returns>
		Task<AuthResults> UpdateAsync(AppUser user);

        /// <summary>
        /// Approve pending user by user id
        /// </summary>
        /// <param name="role"></param>
        /// <returns></returns>
        Task<AuthResults> ApproveUserAsync(string id, bool isApprove);

        /// <summary>
        /// Update profile picture by user id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="picturePath"></param>
        /// <returns></returns>
        Task<AuthResults> UpdateProfilePic(string id, string picturePath);

		#endregion
	}
}
