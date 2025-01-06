namespace Web.Helper
{
	public static class GeneralHelper
	{
		public static string PropString(this object prop)
		{
			if (prop == null)
				return "-";

			return prop switch
			{
				string str when string.IsNullOrEmpty(str) => "-",
				DateTime dt when dt == default(DateTime) => "-",
				long l when l == 0 => "-",
				int i when i == 0 => "-",
				double d when d == 0.0 => "-",
				float f when Math.Abs(f) < float.Epsilon => "-",
				decimal dec when dec == 0 => "-",
				_ => prop.ToString()
			};
		}
	}
}
