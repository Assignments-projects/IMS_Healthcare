using AutoMapper;
using DbLayer.Helpers;
using DbLayer.Models.Patient;
using Microsoft.AspNetCore.Mvc;
using ServiceLayer.Interfaces.Patient;
using ServiceLayer.Interfaces;
using Web.Helper;
using Web.Models.Disease;
using ServiceLayer.Interfaces.Settings;

namespace Web.Controllers
{
	public class DiseaseController : BaseController
	{
		private readonly IDiseaseService _disease;
		private readonly IPatientsService _patient;
		private readonly IStaffService _staff;
		private readonly IDiseaseTypeService _diseaseType;
		private readonly IMapper _mapper;

		public DiseaseController(
			IDiseaseService disease,
			IPatientsService patient,
			IStaffService staff,
			IDiseaseTypeService diseaseType,
			IMapper mapper)
		{
			_disease = disease;
			_patient = patient;
			_staff = staff;
			_diseaseType = diseaseType;
			_mapper  = mapper;
		}

		/// <summary>
		/// Disease index page
		/// </summary>
		/// <returns></returns>
		public IActionResult Index()
		{
			return View();
		}

		/// <summary>
		/// Disease details page by disease id
		/// </summary>
		/// <returns></returns>
		public IActionResult Details(int id)
		{
			return View(new DiseaseMainVM(id));
		}

		/// <summary>
		/// Load list of diseases
		/// </summary>
		/// <returns></returns>
		public async Task<PartialViewResult> DiseaseList()
		{
			var diseases = await _disease.ListAsync();
			var model = _mapper.Map<List<DiseaseVM>>(diseases);

			return PartialView("Containers/_DiseaseList", model);
		}

		/// <summary>
		/// Load details of disease by id
		/// </summary>
		/// <returns></returns>
		public async Task<PartialViewResult> DiseaseDetails(int id)
		{
			var disease = await _disease.DetailsAsync(id);
			var model   = _mapper.Map<DiseaseVM>(disease);

			return PartialView("Containers/_DiseaseDetails", model);
		}

		/// <summary>
		/// Load Add of edit modal for disease based on id passed
		/// </summary>
		/// <returns></returns>
		[HttpGet]
		public async Task<IActionResult> AddEdit(int id)
		{
			var model = new DiseaseDetailsVM()
			{
				PatientList     = await _patient.PatientSelectList(),
				StaffList       = await _staff.StaffSelectList(),
				DiseaseTypeList = await _diseaseType.DiseaseTypeSelectList()
			};

			if (id.IsZeroOrLess())
				return PartialView("Popups/_AddEditDisease", model);

			var disease = await _disease.DetailsAsync(id);
			model.Details = _mapper.Map<DiseaseVM>(disease);


			return PartialView("Popups/_AddEditDisease", model);
		}

		/// <summary>
		/// Add or edit disease
		/// </summary>
		/// <param name="model"></param>
		/// <returns></returns>
		[HttpPost]
		public async Task<IActionResult> AddEdit(DiseaseDetailsVM model)
		{
			if (!TryValidateModel(model.Details))
				return JsonError("Fields are not valid");

			var disease = _mapper.Map<Disease>(model.Details);
			var isAdd   = model.Details.DiseaseId.IsNullOrZero();

			var result = string.Empty;

			if (isAdd)
				result = await _disease.AddAsync(disease, UserHelper.GetCurrentUser());
			else
				result = await _disease.UpdateAsync(disease, UserHelper.GetCurrentUser());

			if (!string.IsNullOrEmpty(result))
				return JsonError(result);

			return JsonSuccess($"Disease {(isAdd ? "added" : "updated")} successfully.");
		}
	}
}
