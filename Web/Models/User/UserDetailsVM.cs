namespace Web.Models.User
{
    public class UserDetailsVM
    {
        public UserDetailsVM()
        {

        }

        public UserDetailsVM(string id)
        {
            UserId = id;
        }

        /// <summary>
        /// User unique id
        /// </summary>
        public string UserId               { get; set; }

        /// <summary>
        /// Is approve or unapprove
        /// </summary>
		public bool IsApprove              { get; set; } = false;


        //------------ Tab container id's ------------

        public string UserInformationTabId { get { return "jq-user-information-tab-id"; } }

		public string UserRolesTabId       { get { return "jq-user-roles-tab-id"; } }

	}
}
