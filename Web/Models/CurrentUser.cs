using DbLayer.Helpers;

namespace Web.Models
{
    public class CurrentUser : ICurrentUser
    {
        public CurrentUser()
        {
            Roles = new List<string>();
        }

        public string UserId         { get; set; }

        public string FirstName      { get; set; } = string.Empty;

        public string LastName       { get; set; } = string.Empty;

		public string FullName       { get; set; } = string.Empty;

		public string Email          { get; set; } = string.Empty;

		public string ProfilePicPath { get; set; } = string.Empty;

        public bool IsApproved { get; set; } = false;

		public List<string> Roles { get; set; }
    }

    public class CurrentUserRole
    {
        public bool IsAdmin { get; set; } = false;

        public bool IsStaff { get; set; } = false;

        public bool IsPatient { get; set; } = false;
    }
}
