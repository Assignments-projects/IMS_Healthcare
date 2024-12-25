using System.ComponentModel.DataAnnotations;

namespace Web.Models.Role
{
	public class RoleVM
	{
		/// <summary>
		/// Gets or sets the primary key for this role.
		/// </summary>
		public string? Id { get; set; }

		/// <summary>
		/// Gets or sets the name for this role.
		/// </summary>
		[Required]
		public required string Name { get; set; }

		/// <summary>
		/// Gets or sets the normalized name for this role.
		/// </summary>
		public string? NormalizedName { get; set; }
	}
}
