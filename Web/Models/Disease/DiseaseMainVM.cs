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

		public int DiseaseId           { get; set; }

		public string PatientUuid      { get; set; }

		public string DiseaseInfoTabId { get { return "jq-disease-information-tab-id"; } }

		public string ImageTabId       { get { return "jq-disease-image-tab-id"; } }

		public string StatementItemTabId { get { return "jq-disease-statement-item-tab-id"; } }


	}
}
