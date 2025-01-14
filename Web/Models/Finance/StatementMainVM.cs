namespace Web.Models.Finance
{
	public class StatementMainVM
	{
		public StatementMainVM() { }

		public StatementMainVM(int id) 
		{
			StatementId = id;
		}

		public int StatementId { get; set; }	
	}
}
