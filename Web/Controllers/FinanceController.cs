using DbLayer.Helpers;
using DbLayer.Models;
using Microsoft.AspNetCore.Mvc;
using Web.Helper;
using Web.Models.Disease;
using AutoMapper;
using ServiceLayer.Interfaces;
using Web.Models.Finance;
using ServiceLayer.Interfaces.Patient;
using DbLayer.Models.Finance;
using ServiceLayer.Interfaces.Finance;
using DbLayer.Models.Settings;
using Web.Models.Image;
using Web.Models.Patient;
using Rotativa.AspNetCore;

namespace Web.Controllers
{
	public class FinanceController : BaseController
	{
		private readonly IStatementService _statement;
		private readonly IStatementItemService _item;
		private readonly IPatientsService _patient;
		private readonly IDiseaseService _disease;
		private readonly IUserService _user;
		private readonly IMapper _mapper;

		public FinanceController(
			IStatementService statement,
			IStatementItemService item,
			IPatientsService patient,
			IDiseaseService disease,
			IUserService user,
			IMapper mapper)
		{
			_user      = user;
			_patient   = patient;
			_statement = statement;
			_item      = item;
			_disease   = disease;
			_mapper    = mapper;
		}

		public IActionResult Index()
		{
			return View();
		}

		/// <summary>
		/// Statement details page by Id
		/// </summary>
		/// <returns></returns>
		public async Task<IActionResult> Details(int id)
		{
			var model = new StatementMainVM
			{
				Details		= _mapper.Map<StatementVM>(await _statement.DetailsAsync(id)),
				StatementId = id,
			};

			return View(model);
		}

		/// <summary>
		/// Statement report pdf
		/// </summary>
		/// <returns></returns>
		public async Task<IActionResult> StatementReport()
		{
			return new ViewAsPdf();
		}

		/// <summary>
		/// Load list of statements
		/// </summary>
		/// <returns></returns>
		public async Task<PartialViewResult> StatementList()
		{
			var statements = await _statement.ListAsync();
			var model      = _mapper.Map<List<StatementVM>>(statements);

			return PartialView("Containers/_StatementList", model);
		}


		/// <summary>
		/// Load list of statements for patient
		/// </summary>
		/// <returns></returns>
		public async Task<PartialViewResult> PatientStatementList(string id)
		{
			var statements = await _statement.ListAsync(id);
			var model = _mapper.Map<List<StatementVM>>(statements);

			return PartialView("Containers/_StatementList", model);
		}

		/// <summary>
		/// Load list of statements
		/// </summary>
		/// <returns></returns>
		public async Task<PartialViewResult> ItemList(int id)
		{
			var diseases = await _item.ListAsync(id);
			var model = _mapper.Map<List<StatementItemVM>>(diseases);

			return PartialView("Containers/_ItemList", model);
		}

		/// <summary>
		/// Load list of statements for disease
		/// </summary>
		/// <returns></returns>
		public async Task<PartialViewResult> DiseaseItemList(int id)
		{
			var diseases = await _item.ListForDiseaseAsync(id);
			var model    = _mapper.Map<List<StatementItemVM>>(diseases);

			return PartialView("Containers/_ItemList", model);
		}

		/// <summary>
		/// Load details of statement by id
		/// </summary>
		/// <returns></returns>
		public async Task<PartialViewResult> StatementDetails(int id)
		{
			var statement = await _statement.DetailsAsync(id);
			var model = _mapper.Map<StatementVM>(statement);

			return PartialView("Containers/_StatementDetails", model);
		}

		/// <summary>
		/// Load Add of edit modal for statement based on id passed
		/// </summary>
		/// <returns></returns>
		[HttpGet]
		public async Task<IActionResult> AddEdit(int id, string patientUuid = null, bool isStatus = false)
		{
			var model = new StatementDetailsVM()
			{
				PatientList = await _patient.PatientSelectList(),
				StatusList  = await _statement.StatusSelectList(),
			};

			if (!string.IsNullOrEmpty(patientUuid))
			{
				var patient = await _patient.DetailsAsync(patientUuid);

				if (patient == null)
					return JsonError("Patient not found");

				model.FromPatient         = true;
				model.Details.PatientUuid = patient.PatientUuid;
				model.Details.Patient     = _mapper.Map<PatientVM>(patient);
			}

			if (id.IsZeroOrLess())
				return PartialView("Popups/_AddEditStatement", model);

			var statement = await _statement.DetailsAsync(id);
			model.Details = _mapper.Map<StatementVM>(statement);

			model.IsStatusChange = isStatus;

			return PartialView("Popups/_AddEditStatement", model);
		}

		/// <summary>
		/// Add or edit statement
		/// </summary>
		/// <param name="model"></param>
		/// <returns></returns>
		[HttpPost]
		public async Task<IActionResult> AddEdit(StatementDetailsVM model)
		{
			if (!TryValidateModel(model.Details))
				return JsonError("Fields are not valid");

			var statement = _mapper.Map<Statement>(model.Details);
			var isAdd     = model.Details.StatementId.IsNullOrZero();
			var result    = string.Empty;

			if (model.Details.StatusId.IsNullOrZero())
				statement.StatusId = (int)StatementOS.Pending;

			if (isAdd)
				result = await _statement.AddAsync(statement, UserHelper.GetCurrentUser());
			else
				result = await _statement.UpdateAsync(statement, UserHelper.GetCurrentUser());

			if (!string.IsNullOrEmpty(result))
				return JsonError(result);

			return JsonSuccess($"Statement {(isAdd ? "added" : "updated")} successfully.");
		}

		/// <summary>
		/// Load Add modal for statement item
		/// </summary>
		/// <returns></returns>
		[HttpGet]
		public async Task<IActionResult> AddItem(int id)
		{
			var statement = _mapper.Map<StatementVM>(await _statement.DetailsAsync(id));

			var model = new ItemDetailsVM()
			{
				DiseaseList = await _disease.DiseaseSelectListForPatient(statement.PatientUuid)
			};

			model.ItemDetails.StatementId = (int)statement.StatementId;

			return PartialView("Popups/_AddItem", model);
		}

		/// <summary>
		/// Add statement item to the database
		/// </summary>
		/// <param name="model"></param>
		/// <returns></returns>
		[HttpPost]
		public async Task<IActionResult> AddItem(ItemDetailsVM model)
		{
			if (!TryValidateModel(model.ItemDetails))
				return JsonError("Fields are not valid");

			var statement = _mapper.Map<StatementItem>(model.ItemDetails);
			var result    = await _item.AddAsync(statement, UserHelper.GetCurrentUser());

			if (!string.IsNullOrEmpty(result))
				return JsonError(result);

			return JsonSuccess("Statement item added successfully.");
		}

		/// <summary>
		/// Load delete modal belongs to given image id
		/// </summary>
		/// <returns></returns>
		[HttpGet]
		public async Task<PartialViewResult> DeleteItem(int id)
		{
			var item = await _item.DetailsAsync(id);
			var model = _mapper.Map<StatementItemVM>(item);

			return PartialView("Popups/_ItemDelete", model);
		}

		/// <summary>
		/// Delete image for the details given and return json
		/// </summary>
		/// <param name="model"></param>
		/// <returns></returns>
		[HttpPost]
		public async Task<JsonResult> DeleteItem(StatementItemVM model)
		{
			var result = await _item.DeleteAsync((int)model.StatementItemId, model.StatementId);

			if (!string.IsNullOrEmpty(result))
				return JsonError(result);

			return JsonSuccess("Statement item deleted successfully.");
		}


		/// <summary>
		/// Load delete modal belongs to given image id
		/// </summary>
		/// <returns></returns>
		public async Task<JsonResult> RefreshTotal(int id)
		{
			var result = await _item.CaclculateTotals(id);

			if(!string.IsNullOrEmpty(result))
				return JsonError(result);

			return JsonSuccess("Total calculated successfully");
		}

	}
}
