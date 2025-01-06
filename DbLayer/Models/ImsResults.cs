using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbLayer.Models
{
	public class ImsResults
	{
		public ImsResults()
		{
			Errors = new List<string>();
		}

		public bool Success { get; set; } = false;

		public string? Error { get; set; }

		public string? Message { get; set; }

		public string? Out { get; set; }

		public List<string> Errors { get; set; }
	}
}
