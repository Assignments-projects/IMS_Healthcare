using AuthLayer.Models;
using AutoMapper;
using DbLayer.Models.Settings;
using Microsoft.AspNetCore.Identity;
using Web.Models.Account;
using Web.Models.Role;
using Web.Models.Settings;
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

			CreateMap<ImageTypeVM, ImageType>().ReverseMap();
			CreateMap<DiseaseTypeVM, DiseaseType>().ReverseMap();
		}
	}
}
