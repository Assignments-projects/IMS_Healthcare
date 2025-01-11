using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbLayer.Models
{
	public class Dashboard
	{
		public int TotalUsers { get; set; }

		public int TotalAdmins { get; set; }

		public int TotalStaffs { get; set; }

		public int TotalPatients { get; set; }

		public int TotalDiseases { get; set; }

		public int TotalActiveUsers { get; set; }

		public int TotalActivePatients { get; set; }

		public int TotalDischargedPatients { get; set; }
	}
}
