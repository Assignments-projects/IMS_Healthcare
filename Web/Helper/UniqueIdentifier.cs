namespace Web.Helper
{
	/// <summary>
	/// General unique id's static class
	/// </summary>
	public static class UniqueIdentifier
	{
		public const string MainModelId = "jq-main-popup-modal-id";
	}

	/// <summary>
	/// General unique id's static class
	/// </summary>
	public static class UniqueClass
	{
		public const string ProfilePicUpload = "jq-profile-pic-file-upload-field-class";
		public const string ProfilePic       = "jq-profile-pic-image-class";
		public const string UserSpecificProfilePic = "jq-user-specific-profile-pic-image-class";
	}

	/// <summary>
	/// Unique container id's static class
	/// </summary>
	public static class ContainerId
	{
		public const string RolesList = "jq-roles-list-container-id";
		public const string UsersList = "jq-users-list-container-id";
	}

	/// <summary>
	/// Unique button id's static class
	/// </summary>
	public static class ButtonId
	{
		public const string RoleAddNew = "jq-add-new-role-button-id";
		public const string UserAddNew = "jq-add-new-user-button-id";
		public const string UserEdit   = "jq-edit-exisitng-user-button-id";

		public const string UserApproved = "jq-approved-user-button-id";
		public const string UserPending = "jq-pending-user-button-id";
		public const string AssignRole = "jq-assign-new-role-button-id";

	}

	/// <summary>
	/// Unique button class's static class
	/// </summary>
	public static class ButtonClass
	{
		public const string MainModalSubmit      = "jq-main-modal-submit-button-class";

		public const string RoleEdit             = "jq-edit-role-button-class";
		public const string RoleDelete           = "jq-delete-role-button-class";

		public const string UserEdit             = "jq-edit-user-button-class";
		public const string UserView             = "jq-view-user-button-class";
		public const string UserApprove          = "jq-approve-user-button-class";
		public const string UserProfilePicUpdate = "jq-user--profile-pic-update-button-class";
        public const string UnAssignRole         = "jq-un-assign-role-button-class";
    }

    /// <summary>
    /// Unique table id's static class
    /// </summary>
    public static class TableId
	{
		public const string RolesList = "jq-roles-list-table-id";
		public const string UsersList = "jq-users-list-table-id";

	}
}
