using DbLayer.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace DbLayer.Helper
{
	public interface IAuditCurrent
	{
		string? AddedById { get; set; }

		string? UpdatedById { get; set; }

		DateTime? AddedDate { get; set; }

		DateTime? UpdatedDate { get; set; }

		string? AddedByName { get; set; }

		string? UpdatedByName { get; set; }

		User AddedBy { get; set; }

		User UpdatedBy { get; set; }
	}
}
