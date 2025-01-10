using AuthLayer.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Web.Models.Role;

namespace Web.Controllers
{
	public class RoleController : BaseController
	{
		private readonly IRoleService _role;
		private readonly IMapper _mapper;

		public RoleController(IRoleService role, IMapper mapper) 
		{
			_role   = role;
			_mapper = mapper;
		}


		/// <summary>
		/// Roles index page
		/// </summary>
		/// <returns></returns>
		public async Task<IActionResult> Index()
		{
			return View();
		}

		/// <summary>
		/// Load list of roles
		/// </summary>
		/// <returns></returns>
		public async Task<PartialViewResult> List()
		{
			var roles = await _role.ListAsync();
			var model = _mapper.Map<List<RoleVM>>(roles);

			return PartialView("Containers/_RolesList", model);
		}

		/// <summary>
		/// Load Add of edit modal based on id passed
		/// </summary>
		/// <returns></returns>
		[HttpGet]
		public async Task<PartialViewResult> AddEdit(string id)
		{
			if (string.IsNullOrEmpty(id))
				return PartialView("Popups/_AddEditRole");

			var role  = await _role.DetailsAsync(id);
			var model = _mapper.Map<RoleVM>(role);

			return PartialView("Popups/_AddEditRole", model);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="model"></param>
		/// <returns></returns>
		[HttpPost]
		public async Task<IActionResult> AddEdit(RoleVM model)
		{
			if (!ModelState.IsValid)
				return JsonError("Fields are not valid");

			var role   = _mapper.Map<IdentityRole>(model);
			var result = (success: true, errors: new List<string>());
			var isAdd  = string.IsNullOrEmpty(model.Id);

			if (isAdd)
				result = await _role.AddAsync(role);
			else
				result = await _role.UpdateAsync(role);

			if (!result.success)
			{
				foreach (var error in result.errors)
				{
					ModelState.AddModelError(string.Empty, error);
				}

				return JsonError("Submit role unsuccessful.");
			}
			return JsonSuccess($"Role {(isAdd? "added" : "updated")} successfully.");
		}

		/// <summary>
		/// Load delete modal belongs to given role id
		/// </summary>
		/// <returns></returns>
		[HttpGet]
		public async Task<PartialViewResult> Delete(string id)
		{
			var role  = await _role.DetailsAsync(id);
			var model = _mapper.Map<RoleVM>(role);

			return PartialView("Popups/_DeleteRole", model);
		}

		/// <summary>
		/// Delete role for the details given and return json
		/// </summary>
		/// <param name="model"></param>
		/// <returns></returns>
		[HttpPost]
		public async Task<JsonResult> Delete(RoleVM model)
		{
			var result = await _role.DeleteAsync(model.Id);

			if (!result.success)
			{
				foreach(var error in result.errors)
				{
					ModelState.AddModelError(string.Empty, error);
				}

				return JsonError("Delete unsuccessful.");
			}

			return JsonSuccess("Role deleted successfully.");
		}
	}
}
