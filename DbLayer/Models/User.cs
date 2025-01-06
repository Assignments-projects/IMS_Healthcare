using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbLayer.Models
{
	public class User
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }
		public string UserUuid { get; set; }

		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string? Address { get; set; }
		public string? PhoneNo { get; set; }
		public bool IsApproved { get; set; }

		public string? UserName { get; set; }
		public string? NormalizedUserName { get; set; }
		public string? Email { get; set; }
		public string? NormalizedEmail { get; set; }

		public bool EmailConfirmed { get; set; }

		public DateTime? LockoutEnd { get; set; }
		public bool LockoutEnabled { get; set; }
		public int AccessFailedCount { get; set; }

		public string? ProfilePicPath { get; set; }

		public DateTime AddedDate { get; set; }
		public DateTime? UpdatedDate { get; set; }
	}
}
