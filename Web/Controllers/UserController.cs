using AuthLayer.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Web.Models.Account;
using Web.Models.Role;

namespace Web.Controllers
{
	public class UserController : Controller
	{
		private readonly IAccountService _account;
		private readonly IMapper _mapper;

		public UserController(IAccountService account, IMapper mapper)
        {
            _account = account;
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
		/// Load list of roles
		/// </summary>
		/// <returns></returns>
		public async Task<PartialViewResult> List(bool isApproved)
		{
			var users = await _account.ListAsync(isApproved);
			var model = _mapper.Map<List<UserVM>>(users);

			return PartialView("Containers/_UsersList", model);
		}
	}
}
