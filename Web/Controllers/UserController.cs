using AuthLayer.Interfaces;
using AuthLayer.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ServiceLayer.Interfaces;
using Web.Models.Account;
using Web.Models.User;

namespace Web.Controllers
{
    public class UserController : BaseController
	{
		private readonly IUserService _user;
		private readonly IRoleService _role;
		private readonly IMapper _mapper;

		public UserController(
			IUserService user,
			IRoleService role,
			IMapper mapper)
        {
			_user    = user;
			_role    = role;
			_mapper  = mapper;
        }

        /// <summary>
        /// Application users index page
        /// </summary>
        /// <returns></returns>
        public IActionResult Index()
		{
			return View();
		}		

		/// <summary>
		/// Application users details page
		/// </summary>
		/// <returns></returns>
		public IActionResult Details(string id)
		{
			return View(new UserDetailsVM(id));
		}

		/// <summary>
		/// Load list of users approved or not
		/// </summary>
		/// <returns></returns>
		public async Task<PartialViewResult> List(bool isApproved)
		{
			var users = await _user.ListAsync(isApproved);
			var model = _mapper.Map<List<UserVM>>(users);

			return PartialView("Containers/_UsersList", model);
		}

		/// <summary>
		/// Load details of user by id
		/// </summary>
		/// <returns></returns>
		public async Task<PartialViewResult> UserDetails(string id)
		{
			var users = await _user.DetailsAsync(id);
			var model = _mapper.Map<UserVM>(users);

			return PartialView("Containers/_UserDetails", model);
		}

		/// <summary>
		/// Load mini details of user by id
		/// </summary>
		/// <returns></returns>
		public async Task<PartialViewResult> UserDetailsMini(string id)
		{
			var users = await _user.DetailsAsync(id);
			var model = _mapper.Map<UserVM>(users);

			return PartialView("Containers/_UserDetailsMini", model);
		}

		/// <summary>
		/// Load Add of edit modal based on id passed
		/// </summary>
		/// <returns></returns>
		[HttpGet]
		public async Task<PartialViewResult> AddEdit(string id)
		{
			if (string.IsNullOrEmpty(id))
				return PartialView("Popups/_AddEditUser");

			var user  = await _user.DetailsAsync(id);
			var model = _mapper.Map<UserVM>(user);

			return PartialView("Popups/_AddEditUser", model);
		}

		/// <summary>
		/// Add or update users to the system
		/// </summary>
		/// <param name="model"></param>
		/// <returns></returns>
		[HttpPost]
		public async Task<IActionResult> AddEdit(UserVM model)
		{
			if (!ModelState.IsValid)
				return JsonError("Fields are not valid");

			var user   = _mapper.Map<AppUser>(model);
			var result = new AuthResults();
			var isAdd  = string.IsNullOrEmpty(model.Id);

			if (isAdd)
				result = await _user.AddAsync(user);
			else
				result = await _user.UpdateAsync(user);

			if (!result.Success)
			{
				foreach (var error in result.Errors)
				{
					ModelState.AddModelError(string.Empty, error);
				}

				return JsonError("Submit user unsuccessful.");
			}
			return JsonSuccess($"User {(isAdd ? "added" : "updated")} successfully.");
		}

        /// <summary>
        /// Load Add of edit modal based on id passed
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> ApproveUnApprove(string id, bool isApprove = false)
        {
			if (string.IsNullOrEmpty(id))
				return JsonError("User id not found.");

            var model = new UserDetailsVM()
			{
				UserId    = id,
				IsApprove = isApprove
			};

            return PartialView("Popups/_ApproveUser", model);
        }

		/// <summary>
		/// Approve or un approve user by id
		/// </summary>
		/// <param name="model"></param>
		/// <returns></returns>
		[HttpPost]
		public async Task<IActionResult> ApproveUnApprove(UserDetailsVM model)
		{
            var result = await _user.ApproveUserAsync(model.UserId, model.IsApprove);

            if (!result.Success)
                return JsonError("User status change unsuccessful.");

            return JsonSuccess($"User {(model.IsApprove ? "approved" : "un-approved")} successfully.");
        }

		/// <summary>
		/// Load list of user roles for the user id givem
		/// </summary>
		/// <returns></returns>
		public async Task<PartialViewResult> UserRoleList(string id)
		{
			var roles   = await _user.UserRolesListAsync(id);
			var list = _mapper.Map<List<UsersVsRolesVM>>(roles);

			var model = new UserRolesDetailsVM()
			{
				List = list
            };

			model.Details.UserId = id;

            return PartialView("Containers/_UserRolesList", model);
		}

		/// <summary>
		/// Load assign role modal based on id passed
		/// </summary>
		/// <returns></returns>
		[HttpGet]
		public async Task<IActionResult> AssignRole(string id)
		{
			if (string.IsNullOrEmpty(id))
				return JsonError("User id not found.");

			var user = await _user.DetailsAsync(id);

			if (user == null)
				return JsonError("User not found.");

			var roles = await _role.RolesSelectList();

			var model = new UserRolesDetailsVM()
			{
				RolesList = roles
			};

			model.Details.UserId = user.Id;

			return PartialView("Popups/_AssignRole", model);
		}

        /// <summary>
        /// Assign a role to the user
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> AssignRole(UserRolesDetailsVM model)
        {
            if (!TryValidateModel(model.Details))
                return JsonError("Fields are not valid");

            var userRole = _mapper.Map<ViewUsersVsRoles>(model.Details);
            var result   = await _role.AssignRoleAsync(userRole);

            if (!result.success)
            {
                foreach (var error in result.errors)
                {
                    ModelState.AddModelError(string.Empty, error);
                }

                return JsonError(result.errors[0]);
            }
            return JsonSuccess($"Role assigned to the user successfully.");
        }

		/// <summary>
		/// Load un - assign role modal based on ids passed
		/// </summary>
		/// <returns></returns>
		[HttpGet]
		public async Task<IActionResult> UnAssignRole(string id, string userId)
		{
			if (string.IsNullOrEmpty(id))
				return JsonError("Role id not found.");

			if (string.IsNullOrEmpty(userId))
				return JsonError("User id not found.");

			var model = new UserRolesDetailsVM();

			model.Details.RoleId = id;
			model.Details.UserId = userId;

			return PartialView("Popups/_UnAssignRole", model);
		}

        /// <summary>
        /// Assign a role to the user
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> UnAssignRole(UserRolesDetailsVM model)
        {
            if (!TryValidateModel(model.Details))
                return JsonError("Fields are not valid");

            var userRole = _mapper.Map<ViewUsersVsRoles>(model.Details);
            var result   = await _role.AssignRoleAsync(userRole, true);

            if (!result.success)
            {
                foreach (var error in result.errors)
                {
                    ModelState.AddModelError(string.Empty, error);
                }

                return JsonError(result.errors[0]);
            }
            return JsonSuccess($"Role un-assigned to the user successfully.");
        }

		/// <summary>
		/// Upload profile picture and return path
		/// </summary>
		/// <param name="file"></param>
		/// <param name="id"></param>
		/// <returns></returns>
		[HttpPost]
		public async Task<IActionResult> UploadProfilePic(IFormFile file, string id)
		{
			if (file == null || file.Length == 0)
				return JsonError("Uploaded file not found.");

			// Define the target directory and file name
			var uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images/uploads");
			Directory.CreateDirectory(uploadsFolder);

			var uniqueFileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
			var filePath       = Path.Combine(uploadsFolder, uniqueFileName);

			// Save the file locally
			using (var fileStream = new FileStream(filePath, FileMode.Create))
			{
				await file.CopyToAsync(fileStream);
			}

			// Save the path to the database
			var imagePath = $"/images/uploads/{uniqueFileName}";

			// appload to the database
			var result = await _user.UpdateProfilePic(id, imagePath);

			if (!result.Success)
				return JsonError(result.Errors[0]);

			return JsonSuccess(result.Message);
		}
    }
}
