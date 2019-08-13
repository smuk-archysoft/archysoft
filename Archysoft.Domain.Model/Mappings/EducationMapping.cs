
using Archysoft.Data.Entities;
using Archysoft.Domain.Model.Model.Employees;
using AutoMapper;

namespace Archysoft.Domain.Model.Mappings
{
    public class EducationMapping : Profile
    {
        public EducationMapping()
        {
            CreateMap<Education, EducationModel>()
                .ForMember(x => x.Degree, opt => opt.MapFrom(e => e.Degree))
                .ForMember(x => x.School, opt => opt.MapFrom(e => e.School))
                .ForMember(x => x.YearAttendedFrom, opt => opt.MapFrom(e => e.YearAttendedFrom))
                .ForMember(x => x.YearAttendedTo, opt => opt.MapFrom(e => e.YearAttendedTo));
        }
    }
}
