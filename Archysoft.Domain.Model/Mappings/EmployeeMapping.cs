using System.Linq;
using Archysoft.Data.Entities;
using Archysoft.Domain.Model.Model.Employees;
using AutoMapper;

namespace Archysoft.Domain.Model.Mappings
{
    public class EmployeeMapping : Profile
    {
        public EmployeeMapping()
        {
            CreateMap<User, EmployeeDetailsModel>()
                .ForMember(x => x.FirstName, opt => opt.MapFrom(u => u.Profile.FirstName))
                .ForMember(x => x.LastName, opt => opt.MapFrom(u => u.Profile.LastName))
                .ForMember(x => x.PhoneNumber, opt => opt.MapFrom(u => u.PhoneNumber))
                .ForMember(x => x.Skype, opt => opt.MapFrom(u => u.Profile.Skype))
                .ForMember(x => x.Photo, opt => opt.MapFrom(u => u.Profile.Photo))
                .ForPath(x => x.Description.Title, opt => opt.MapFrom(u => u.Profile.Description.Title))
                .ForPath(x => x.Description.Text, opt => opt.MapFrom(u => u.Profile.Description.Text))
                .ForMember(x => x.Skills,
                    opt => opt.MapFrom(u => u.Profile.UserProfileSkills.Select(s => s.Skill.Name).ToList()))
                .ForMember(x => x.Languages,
                    opt => opt.MapFrom(u => u.Profile.UserProfileLanguages.Select(l => l.Language.Name).ToList()))
                .ForMember(x => x.Educations, opt => opt.MapFrom(u => u.Profile.Educations))
                .ForMember(x => x.Experiences, opt => opt.MapFrom(u => u.Profile.Experiences))
                .ForMember(x => x.City, opt => opt.MapFrom(u => u.Profile.City.Name))
                .ForMember(x => x.Country, opt => opt.MapFrom(u => u.Profile.City.Country.Name));
        }
    }
}
