using AuthLayer.Models;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Web.Models.Account;
using Web.Models.Role;
using Web.Models.User;

namespace Web.Helper
{
    public class AutoMappingProfile : Profile
    {
        public AutoMappingProfile()
        {
            CreateMap<LoginVM, Login>();
            CreateMap<RegisterVM, Register>();
            CreateMap<UserVM, AppUser>().ReverseMap();
            CreateMap<RoleVM, IdentityRole>().ReverseMap();
			CreateMap<UsersVsRolesVM, ViewUsersVsRoles>().ReverseMap();

		}
	}
}
