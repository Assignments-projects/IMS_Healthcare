namespace DbLayer.Helpers
{
    public enum UserStatus
    {
        Approve,
        Pending
    }

	public enum UserRole
	{
		Admin,
		Patient,
		Staff
	}

	public enum ImageWith
	{
		ImageType,
		DiseaseType
	}

	public enum StatementOS
	{
		Pending = 1,
		Paid    = 2,
	}
}
