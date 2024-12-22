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
        Task<(bool, List<string>)> Register(Register model);

        /// <summary>
        /// Logout from application
        /// </summary>
        void Logout();
    }
}
