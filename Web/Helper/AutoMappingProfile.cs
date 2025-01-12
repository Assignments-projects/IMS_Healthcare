using AuthLayer.Models;
using AutoMapper;
using DbLayer.Models;
using DbLayer.Models.Patient;
using DbLayer.Models.Settings;
using Microsoft.AspNetCore.Identity;
using Web.Models.Account;
using Web.Models.Disease;
using Web.Models.Home;
using Web.Models.Image;
using Web.Models.Patient;
using Web.Models.Role;
using Web.Models.Settings;
using Web.Models.Staff;
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

			CreateMap<StaffVM, Staff>().ReverseMap();

			CreateMap<PatientVM, Patients>().ReverseMap();
			CreateMap<DiseaseVM, Disease>().ReverseMap();

			// Explicit mapping for Image to handle complex navigation properties
			CreateMap<Image, ImageVM>().ReverseMap();


			CreateMap<Dashboard, DashboardVM>();
		}
	}
}
