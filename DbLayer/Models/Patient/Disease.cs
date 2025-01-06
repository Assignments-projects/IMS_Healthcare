using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DbLayer.Models.Settings;

namespace DbLayer.Models.Patient
{
	public class Disease
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


		// ------ System props ----------

		public string? AddedById { get; set; }

		public string? UpdatedById { get; set; }

		public DateTime? AddedDate { get; set; }

		public DateTime? UpdatedDate { get; set; }

		public bool IsActive { get; set; }


		//----- Foriegn key objects --------- 

		public Patients Patient { get; set; }

		public DiseaseType DiseaseType { get; set; }

		public Staff Doctor { get; set; }
		//-----------------------------------

		public ICollection<Prescription> Prescriptions { get; set; }
	}
}
