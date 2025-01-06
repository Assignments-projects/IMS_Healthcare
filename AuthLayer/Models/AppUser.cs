using Microsoft.AspNetCore.Identity;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthLayer.Models
{
    public class AppUser : IdentityUser
    {
        /// <summary>
        /// First name of the user
        /// </summary>
        public string FirstName          { get; set; } = string.Empty;

        /// <summary>
        /// Last name of the user
        /// </summary>
        public string LastName           { get; set; } = string.Empty;

        /// <summary>
        /// User street address
        /// </summary>
        public string? Address           { get; set; }

        /// <summary>
        /// User phone number
        /// </summary>
        public string? PhoneNo           { get; set; }

		/// <summary>
		/// User profile picture path
		/// </summary>
		public string? ProfilePicPath    { get; set; }

		/// <summary>
		/// Is user account approved
		/// </summary>
		public bool IsApproved           { get; set; } = false;

	}
}
