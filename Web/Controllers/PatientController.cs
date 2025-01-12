using AutoMapper;
using DbLayer.Helpers;
using DbLayer.Models;
using DbLayer.Models.Patient;
using Microsoft.AspNetCore.Mvc;
using ServiceLayer.Interfaces;
using ServiceLayer.Interfaces.Patient;
using Web.Helper;
using Web.Models.Disease;
using Web.Models.Patient;

namespace Web.Controllers
{
	public class PatientController : BaseController
	{
		private readonly IPatientsService _patient;
		private readonly IStaffService _staff;
		private readonly IDiseaseService _disease;
		private readonly IUserService _user;
		private readonly IMapper _mapper;

		public PatientController(
			IPatientsService patient,
			IStaffService staff,
			IDiseaseService disease,
			IUserService user,
			IMapper mapper)
		{
			_user    = user;
			_staff = staff;
			_patient = patient;
			_disease = disease;
			_mapper  = mapper;
		}

		/// <summary>
		/// Patient index page
		/// </summary>
		/// <returns></returns>
		public IActionResult Index()
		{
			return View();
		}

		/// <summary>
		/// Patient details page by Id
		/// </summary>
		/// <returns></returns>
		public IActionResult Details(string id)
		{
			return View(new PatientMainVM(id));
		}

		/// <summary>
		/// Load list of patients
		/// </summary>
		/// <returns></returns>
		public async Task<PartialViewResult> PatientList()
		{
			var patients = await _patient.ListAsync();
			var model = _mapper.Map<List<PatientVM>>(patients);

			return PartialView("Containers/_PatientList", model);
		}

		/// <summary>
		/// Load list of patients
		/// </summary>
		/// <returns></returns>
		public async Task<PartialViewResult> DiseasetList(string id)
		{
			var diseases = await _disease.ListAsync(id);
			var model = _mapper.Map<List<DiseaseVM>>(diseases);

			return PartialView("Containers/_DiseaseList", model);
		}

		/// <summary>
		/// Load details of patient by id
		/// </summary>
		/// <returns></returns>
		public async Task<PartialViewResult> PatientDetails(string id)
		{
			var patient = await _patient.DetailsAsync(id);
			var model = _mapper.Map<PatientVM>(patient);

			return PartialView("Containers/_PatientDetails", model);
		}

		/// <summary>
		/// Load Add of edit modal for patient based on id passed
		/// </summary>
		/// <returns></returns>
		[HttpGet]
		public async Task<IActionResult> AddEdit(string id)
		{
			var model = new PatientDetailsVM()
			{
				UsersList = await _user.UserBasedOnRoleList(UserRole.Patient),
				StaffList = await _staff.StaffSelectList()
			};

			if (string.IsNullOrEmpty(id))
				return PartialView("Popups/_AddEditPatient", model);

			var patient = await _patient.DetailsAsync(id);
			model.Details = _mapper.Map<PatientVM>(patient);


			return PartialView("Popups/_AddEditPatient", model);
		}

		/// <summary>
		/// Add or edit patient
		/// </summary>
		/// <param name="model"></param>
		/// <returns></returns>
		[HttpPost]
		public async Task<IActionResult> AddEdit(PatientDetailsVM model)
		{
			if (!TryValidateModel(model.Details))
				return JsonError("Fields are not valid");

			var patient = _mapper.Map<Patients>(model.Details);
			var isAdd = model.Details.PateintId.IsNullOrZero();

			var result = string.Empty;

			if (isAdd)
				result = await _patient.AddAsync(patient, UserHelper.GetCurrentUser());
			else
				result = await _patient.UpdateAsync(patient, UserHelper.GetCurrentUser());

			if (!string.IsNullOrEmpty(result))
				return JsonError(result);

			return JsonSuccess($"Patient {(isAdd ? "added" : "updated")} successfully.");
		}
	}
}
