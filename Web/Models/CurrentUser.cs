namespace Web.Models
{
    public class CurrentUser
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


		public List<string> Roles { get; set; }
    }
}
