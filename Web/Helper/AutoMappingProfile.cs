using AuthLayer.Models;
using AutoMapper;
using Web.Models;

namespace Web.Helper
{
    public class AutoMappingProfile : Profile
    {
        public AutoMappingProfile()
        {
            CreateMap<LoginVM, Login>();
            CreateMap<RegisterVM, Register>();
        }
    }
}
