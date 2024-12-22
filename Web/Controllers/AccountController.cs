using AuthLayer.Interfaces;
using AuthLayer.Models;
using AutoMapper;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using Web.Models;

namespace Web.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAccountService _account;
        private readonly IMapper _mapper;

        public AccountController(IAccountService account, IMapper mapper)
        {
            _account = account;
            _mapper  = mapper;
        }

        /// <summary>
        /// Load Login form page
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> Login()
        {
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
				var result = await _account.Login(data);

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
				var result = await _account.Register(data);

				if (result.Item1)
					return RedirectToAction(nameof(Login));

				if (result.Item2.Any())
				{
					foreach (var error in result.Item2)
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
			_account.Logout();
			return RedirectToAction(nameof(Login));
		}
	}
}
