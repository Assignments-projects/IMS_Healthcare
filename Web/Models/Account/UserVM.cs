﻿using System.ComponentModel.DataAnnotations;

namespace Web.Models.Account
{
	public class UserVM
	{

		/// <summary>
		/// User email address
		/// </summary>
		public string Id { get; set; } = string.Empty;

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
		/// User profile picture path
		/// </summary>
		[Display(Name = "Profile picture")]
		public string? ProfilePicPath { get; set; }

		/// <summary>
		/// Is User approved ?
		/// </summary>
		[Display(Name = "Approved")]
		public bool IsApproved { get; set; }
	}
}
