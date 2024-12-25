using System.ComponentModel.DataAnnotations;

namespace Web.Models.Account
{
    public class RegisterVM
    {
        /// <summary>
        /// User email address
        /// </summary>
        [Required]
        [EmailAddress]
        public required string Email { get; set; }

        /// <summary>
        /// First name of the user
        /// </summary>
        [Required]
        [Display(Name = "First Name")]
        public required string FirstName { get; set; }

        /// <summary>
        /// Last name of the user
        /// </summary>
        [Required]
        [Display(Name = "Last Name")]
        public required string LastName { get; set; }

        /// <summary>
        /// Username to login to the system once registered successfully
        /// </summary>
        [Display(Name = "Username")]
        public string? UserName { get; set; }

        /// <summary>
        /// User street address
        /// </summary>
        [Display(Name = "Address")]
        public string? Address { get; set; }

        /// <summary>
        /// User phone number
        /// </summary>
        [Display(Name = "Phone No")]
        public string? PhoneNo { get; set; }

        /// <summary>
        /// Password belongs to the email
        /// </summary>
        [Required]
        [DataType(DataType.Password)]
        public required string Password { get; set; }

        /// <summary>
        /// Password confirmation
        /// </summary>
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public required string ConfirmPassword { get; set; }
    }
}
