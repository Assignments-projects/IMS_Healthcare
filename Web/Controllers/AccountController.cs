using AuthLayer.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ServiceLayer.Interfaces;
using Web.Models.Account;

namespace Web.Controllers
{
    public class AccountController : BaseController
	{
        private readonly IUserService _user;
        private readonly IMapper _mapper;

        public AccountController(IUserService account, IMapper mapper)
        {
            _user = account;
            _mapper  = mapper;
        }

        /// <summary>
        /// Load Login form page
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> Login()
        {
			if (User.Identity != null && User.Identity.IsAuthenticated)
				return LocalRedirect("/Home/Index");
			else
				return View();
		}

		/// <summary>
		/// Login to the system with login details
		/// </summary>
		/// <param name="model"></param>
		/// <returns></returns>
		[HttpPost]
		public async Task<IActionResult> Login(LoginVM model)
		{

			if (ModelState.IsValid)
			{
				var data   = _mapper.Map<Login>(model);
				var result = await _user.Login(data);

				if (string.IsNullOrEmpty(result))
				{
					return LocalRedirect("/Home/Index");
				}
				else
				{
					ModelState.AddModelError(string.Empty, result);
					return View();
				}
			}

			return View();
		}

		/// <summary>
		/// Load Register form page
		/// </summary>
		/// <returns></returns>
		[HttpGet]
        public async Task<IActionResult> Register()
        {
            return View();
        }

		/// <summary>
		/// Register a new account
		/// </summary>
		/// <param name="model"></param>
		/// <returns></returns>
		[HttpPost]
		public async Task<IActionResult> Register(RegisterVM model)
		{
			if (ModelState.IsValid)
			{
				var data   = _mapper.Map<Register>(model);
				var result = await _user.Register(data);

				if (result.Success)
					return RedirectToAction(nameof(Login));

				if (result.Errors.Any())
				{
					foreach (var error in result.Errors)
					{
						ModelState.AddModelError(string.Empty, error);
					}
				}
				else
				{
					ModelState.AddModelError(string.Empty, "Something went wrong ! Please Try again");
					return View();
				}
			}

			return View();
		}

		/// <summary>
		/// Logout and redirect to login page
		/// </summary>
		/// <returns></returns>
		[HttpPost]
		public async Task<IActionResult> Logout()
		{
			_user.Logout();
			return RedirectToAction(nameof(Login));
		}

		/// <summary>
		/// Display not found page
		/// </summary>
		/// <returns></returns>
		public async Task<IActionResult> NotFound()
		{
			return View("Errors/NotFoundError");
		}

		/// <summary>
		/// Display server error page page
		/// </summary>
		/// <returns></returns>
		public async Task<IActionResult> ServerError()
		{
			return View("Errors/ServerError");
		}

		/// <summary>
		/// Display accss denied page
		/// </summary>
		/// <returns></returns>
		public async Task<IActionResult> AccessDenied()
		{
			return View("Errors/AccessDenied");
		}

		/// <summary>
		/// Display accss declined page
		/// </summary>
		/// <returns></returns>
		public async Task<IActionResult> AccessDeclined()
		{
			string message = "You are not approved to use this account. Please contact admin.";

			return View("Errors/UnauthorizedError", message);
		}

		/// <summary>
		/// Display unauthorized coz has no user roles page
		/// </summary>
		/// <returns></returns>
		public async Task<IActionResult> NoUserRoles()
		{
			string message = "You have no assigned roles to login. Please contact admin.";

			return View("Errors/UnauthorizedError", message);
		}
	}
}
