using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthLayer.Models
{
    public class Register
    {
        /// <summary>
        /// User email address
        /// </summary>
        public required string Email     { get; set; }

        /// <summary>
        /// First name of the user
        /// </summary>
        public required string FirstName { get; set; }

        /// <summary>
        /// Last name of the user
        /// </summary>
        public required string LastName  { get; set; }

        /// <summary>
        /// Username to login to the system once registered successfully
        /// </summary>
        public string? UserName          { get; set; }

        /// <summary>
        /// User street address
        /// </summary>
        public string? Address           { get; set; }

        /// <summary>
        /// User phone number
        /// </summary>
        public string? PhoneNo           { get; set; }

        /// <summary>
        /// Password belongs to the email
        /// </summary>
        public required string Password  { get; set; }

		// ------ System props ----------

		public string? AddedById         { get; set; }

		public string? UpdatedById       { get; set; }

		public DateTime? AddedDate       { get; set; }

		public DateTime? UpdatedDate     { get; set; }
	}
}
