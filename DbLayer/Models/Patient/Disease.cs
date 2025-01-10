using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DbLayer.Models.Settings;
using DbLayer.Helper;

namespace DbLayer.Models.Patient
{
	public class Disease : IAuditCurrent
	{
		/// <summary>
		/// Primary key
		/// </summary>
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int DiseaseId { get; set; }


		//----- Foriegn keys ----------

		/// <summary>
		/// User's universal unique id from - Identity user
		/// </summary>
		[ForeignKey(nameof(Patient))]
		public string? PatientUuid { get; set; }

		/// <summary>
		/// Disease type unique id
		/// </summary>
		[ForeignKey(nameof(DiseaseType))]
		public int DiseaseTypeId { get; set; }


		/// <summary>
		/// Staff unique id
		/// </summary>
		[ForeignKey(nameof(Doctor))]
		public string DoctorId { get; set; }

		//-------------------------------

		/// <summary>
		/// Specification of disease
		/// </summary>
		public string? DiseaseSpec { get; set; }

		/// <summary>
		/// Any comments about the disease
		/// </summary>
		public string? Comments { get; set; }


		//------ Additional props ---------

		[NotMapped]
		public string? AddedByName { get; set; }

		[NotMapped]
		public string? UpdatedByName { get; set; }


		// ------ System props ----------

		public string? AddedById { get; set; }

		public string? UpdatedById { get; set; }

		public DateTime? AddedDate { get; set; }

		public DateTime? UpdatedDate { get; set; }

		public bool IsActive { get; set; }


		//----- Foriegn key objects --------- 

		public virtual Patients Patient { get; set; }

		public virtual DiseaseType DiseaseType { get; set; }

		public virtual Staff Doctor { get; set; }

		public virtual User AddedBy { get; set; }

		public virtual User UpdatedBy { get; set; }

		//-----------------------------------

		public virtual ICollection<Prescription> Prescriptions { get; set; }
	}
}
