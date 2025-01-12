namespace Web.Models.Disease
{
	public class DiseaseMainVM
	{
		public DiseaseMainVM() { }

		public DiseaseMainVM(int id)
		{
			DiseaseId = id;			
		}

		public DiseaseMainVM(string id)
		{
			PatientUuid = id;
		}

		public int DiseaseId { get; set; }

		public string PatientUuid { get; set; }

	}
}
