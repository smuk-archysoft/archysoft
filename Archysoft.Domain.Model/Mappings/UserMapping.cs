using Archysoft.Data.Entities;
using Archysoft.Domain.Model.Model.Users;
using AutoMapper;

namespace Archysoft.Domain.Model.Mappings
{
    public class UserMapping : Profile
    {
        public UserMapping()
        {
            CreateMap<User, UserGridModel>()
                .ForMember(x => x.FirstName, opt => opt.MapFrom(u => u.Profile.FirstName))
                .ForMember(x => x.LastName, opt => opt.MapFrom(u => u.Profile.LastName))
                .ForMember(x => x.Photo, opt => opt.MapFrom(u => u.Profile.Photo));
        }
    }
}
