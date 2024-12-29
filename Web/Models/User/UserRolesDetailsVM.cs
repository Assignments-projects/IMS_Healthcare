using System.Web.Mvc;

namespace Web.Models.User
{
    public class UserRolesDetailsVM
    {
        public UserRolesDetailsVM()
        {
            RolesList = new List<SelectListItem>();
            List      = new List<UsersVsRolesVM>();
            Details   = new UsersVsRolesVM();
        }

        /// <summary>
        /// Rples list for select picker
        /// </summary>
        public UsersVsRolesVM Details         { get; set; }

        /// <summary>
        /// Rples list for select picker
        /// </summary>
        public List<UsersVsRolesVM> List      { get; set; }

        /// <summary>
        /// Rples list for select picker
        /// </summary>
        public List<SelectListItem> RolesList { get; set; }
    }
}
