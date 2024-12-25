using System.ComponentModel.DataAnnotations;

namespace Web.Models.Account
{
    public class LoginVM
    {
        /// <summary>
        /// User email address
        /// </summary>
        [Required]
        public required string Email { get; set; }

        /// <summary>
        /// Account password
        /// </summary>
        [Required]
        [DataType(DataType.Password)]
        public required string Password { get; set; }

        /// <summary>
        /// Want to remember the login details
        /// </summary>
        public bool RememberMe { get; set; }
    }
}
