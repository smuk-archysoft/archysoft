

using Archysoft.Data.Entities;
using Archysoft.Domain.Model.Model.Employees;
using AutoMapper;

namespace Archysoft.Domain.Model.Mappings
{
    public class ExperienceMapping:Profile
    {
        public ExperienceMapping()
        {
            CreateMap<Experience, ExperienceModel>()
                .ForMember(x => x.Position, opt => opt.MapFrom(x => x.Position))
                .ForMember(x => x.Description, opt => opt.MapFrom(x => x.Description))
                .ForMember(x => x.BeginDate, opt => opt.MapFrom(x => x.BeginDate))
                .ForMember(x => x.EndDate, opt => opt.MapFrom(x => x.EndDate));
        }
    }
}
