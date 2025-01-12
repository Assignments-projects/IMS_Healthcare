using AuthLayer.Interfaces;
using AutoMapper;
using DbLayer.Helpers;
using DbLayer.Models;
using Microsoft.AspNetCore.Mvc;
using ServiceLayer.Interfaces;
using Web.Helper;
using Web.Models.Staff;

namespace Web.Controllers
{
	public class StaffController : BaseController
	{
		private readonly IStaffService _staff;
		private readonly IUserService _user;
		private readonly IMapper _mapper;

		public StaffController(
			IStaffService staff,
			IUserService user,
			IMapper mapper)
		{
			_user   = user;
			_staff  = staff;
			_mapper = mapper;
		}

		/// <summary>
		/// Staff index page
		/// </summary>
		/// <returns></returns>
		public IActionResult Index()
		{
			return View();
		}

		/// <summary>
		/// Staff details page by Id
		/// </summary>
		/// <returns></returns>
		public IActionResult Details(string id)
		{
			return View(new StaffMainDetails(id));
		}

		/// <summary>
		/// Load list of staffs
		/// </summary>
		/// <returns></returns>
		public async Task<PartialViewResult> StaffList()
		{
			var staffs = await _staff.ListAsync();
			var model = _mapper.Map<List<StaffVM>>(staffs);

			return PartialView("Containers/_StaffList", model);
		}

		/// <summary>
		/// Load details of staff by id
		/// </summary>
		/// <returns></returns>
		public async Task<PartialViewResult> StaffDetails(string id)
		{
			var staff = await _staff.DetailsAsync(id);
			var model = _mapper.Map<StaffVM>(staff);

			return PartialView("Containers/_StaffDetails", model);
		}

		/// <summary>
		/// Load Add of edit modal for staff based on id passed
		/// </summary>
		/// <returns></returns>
		[HttpGet]
		public async Task<IActionResult> AddEdit(string id)
		{
			var model = new StaffDetailsVM()
			{
				UsersList = await _user.UserBasedOnRoleList(UserRole.Staff),
			};

			if (string.IsNullOrEmpty(id))
				return PartialView("Popups/_AddEditStaff", model);

			var staff = await _staff.DetailsAsync(id);
			model.Details = _mapper.Map<StaffVM>(staff);


			return PartialView("Popups/_AddEditStaff", model);
		}

		/// <summary>
		/// Add or edit staff
		/// </summary>
		/// <param name="model"></param>
		/// <returns></returns>
		[HttpPost]
		public async Task<IActionResult> AddEdit(StaffDetailsVM model)
		{
			if (!TryValidateModel(model.Details))
				return JsonError("Fields are not valid");

			var staff = _mapper.Map<Staff>(model.Details);
			var isAdd = model.Details.StaffId.IsNullOrZero();

			var result = string.Empty;

			if (isAdd)
				result = await _staff.AddAsync(staff, UserHelper.GetCurrentUser());
			else
				result = await _staff.UpdateAsync(staff, UserHelper.GetCurrentUser());

			if (!string.IsNullOrEmpty(result))
				return JsonError(result);

			return JsonSuccess($"Staff {(isAdd ? "added" : "updated")} successfully.");
		}
	}
}
