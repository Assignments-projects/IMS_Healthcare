using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthLayer.Models
{
	public class ViewUsersVsRoles
	{
		public string UserId             { get; set; }
		public string RoleId             { get; set; }
		public string FirstName          { get; set; }
		public string LastName           { get; set; }
		public string UserName           { get; set; }
		public string Email              { get; set; }
		public bool IsApproved           { get; set; }
		public string RoleName           { get; set; }
		public string RoleNormalizedName { get; set; }
	}
}
