using AuthLayer.Models;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Web.Models.Account;
using Web.Models.Role;

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
        }
    }
}
