using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbLayer.Helpers
{
	public static class PropHelper
	{
		public static bool IsNullOrZero(this int? value)
		{
			return value == null || value == 0;
		}

		public static bool IsZeroOrLess(this int value)
		{
			return value <= 0;
		}
	}
}
