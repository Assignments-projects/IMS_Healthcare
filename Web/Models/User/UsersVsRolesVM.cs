using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Web.Models.User
{
	public class UsersVsRolesVM
	{
        /// <summary>
        /// User unique id
        /// </summary>
        [Required]
        public string UserId                  { get; set; }

		/// <summary>
		/// User's role id
		/// </summary>
		[Required]
		public string RoleId                  { get; set; }

		/// <summary>
		/// User role name
		/// </summary>
		public string? RoleName                { get; set; }

		/// <summary>
		/// Normalized role name
		/// </summary>
		public string? RoleNormalizedName      { get; set; }

		/// <summary>
		/// Is the user approved ?
		/// </summary>
		public bool IsApproved                { get; set; }

    }
}
