using AutoMapper;
using WebsiteLibrary.Models;
using WebsiteLibrary.ViewModels;

namespace WebsiteLibrary
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<UserRegistrationViewModel, User>()
                .ForMember(u => u.UserName, opt => opt.MapFrom(x => x.Email));
        }
    }
}
