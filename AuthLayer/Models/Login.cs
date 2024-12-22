
namespace AuthLayer.Models
{
    public class Login
    {
        /// <summary>
        /// User email address
        /// </summary>
        public required string Email    { get; set; }

        /// <summary>
        /// Account password
        /// </summary>
        public required string Password { get; set; }

        /// <summary>
        /// Want to remember the login details
        /// </summary>
        public bool RememberMe          { get; set; }
    }
}
