namespace Web.Models.Staff
{
	public class StaffMainDetails
	{
		public StaffMainDetails()
		{
		}

		public StaffMainDetails(string id)
		{
			StaffUuid = id;
		}

		public string StaffUuid { get; set; }
	}
}
