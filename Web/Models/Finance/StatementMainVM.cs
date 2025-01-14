namespace Web.Models.Finance
{
	public class StatementMainVM
	{
		public StatementMainVM() 
		{
			Details = new StatementVM();
		}

		public int StatementId { get; set; }

		/// <summary>
		/// Statement details obj
		/// </summary>
		public StatementVM Details { get; set; }
	}
}
