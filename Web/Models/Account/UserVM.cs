using System.ComponentModel.DataAnnotations;

namespace Web.Models.Account
{
	public class UserVM
	{

		/// <summary>
		/// User email address
		/// </summary>
		public string? Id { get; set; }

		/// <summary>
		/// User email address
		/// </summary>
		[Required]
		[EmailAddress]
		public string Email { get; set; } = string.Empty;

		/// <summary>
		/// First name of the user
		/// </summary>
		[Required]
		public string FirstName { get; set; } = string.Empty;

		/// <summary>
		/// Last name of the user
		/// </summary>
		[Required]
		public string LastName { get; set; } = string.Empty;

		/// <summary>
		/// Username to login to the system once registered successfully
		/// </summary>
		public string? UserName { get; set; }

		/// <summary>
		/// User street address
		/// </summary>
		public string? Address { get; set; }

		/// <summary>
		/// User phone number
		/// </summary>
		public string? PhoneNo { get; set; }

        /// <summary>
        /// User profile picture path
        /// </summary>
        public string? ProfilePicPath { get; set; }

		/// <summary>
		/// Is User approved ?
		/// </summary>
		public bool IsApproved { get; set; }
	}
}
