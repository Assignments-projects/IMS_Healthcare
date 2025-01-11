using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbLayer.Helpers
{
	public static class StringHelper
	{
		/// <summary>
		/// check contains with ignoring cases
		/// </summary>
		/// <param name="source"></param>
		/// <param name="check"></param>
		/// <returns></returns>
		public static bool ContainsCaseIgnore(this string source, string check) 
		{
			if(string.IsNullOrEmpty(source) || string.IsNullOrEmpty(check)) 
				return false;

			return source.IndexOf(check, StringComparison.OrdinalIgnoreCase) >= 0;
		}
	}
}
