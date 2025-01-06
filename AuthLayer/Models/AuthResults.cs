using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthLayer.Models
{
	public class AuthResults
	{
		public AuthResults() 
		{
			Errors = new List<string>();
		}

		public bool Success { get; set; } = true;

		public string? Error { get; set; }

		public string? Message { get; set; }

		public string? Out { get; set; }

		public List<string> Errors { get; set; }
	}
}
