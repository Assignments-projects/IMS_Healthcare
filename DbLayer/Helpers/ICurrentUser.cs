using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbLayer.Helpers
{
	public interface ICurrentUser
	{
		string UserId          { get; set; }

		string FirstName       { get; set; }

		string LastName        { get; set; }

		public string FullName { get; set; }

		string Email           { get; set; }

		string ProfilePicPath  { get; set; }

		List<string> Roles     { get; set; }

	}
}
