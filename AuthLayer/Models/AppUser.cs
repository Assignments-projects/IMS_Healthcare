using Microsoft.AspNetCore.Identity;
using System;
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
        public required string FirstName { get; set; }

        /// <summary>
        /// Last name of the user
        /// </summary>
        public required string LastName  { get; set; }

        /// <summary>
        /// User street address
        /// </summary>
        public string? Address           { get; set; }

        /// <summary>
        /// User phone number
        /// </summary>
        public string? PhoneNo           { get; set; }

        /// <summary>
        /// Is user account approved
        /// </summary>
        public bool IsApproved           { get; set; } = false;
    }
}
