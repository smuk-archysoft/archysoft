using Archysoft.Domain.Model.Model.Employees;
using Archysoft.Domain.Model.Services.Abstract;
using System;
using System.Linq;
using Archysoft.Data.Repositories.Abstract;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace Archysoft.Domain.Model.Services.Concrete
{
    public class EmployeesService : IEmployeesService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly IPdfService _pdfService;

        public EmployeesService(IUserRepository userRepository, IMapper mapper, IPdfService pdfService)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _pdfService = pdfService;
        }

        public EmployeeDetailsModel Get(Guid id)
        {
 
            var employeeDetails = _userRepository
                .GetReadonly()
                .Include(u => u.Profile).ThenInclude(p => p.UserProfileSkills).ThenInclude(x => x.Skill)
                .Include(u => u.Profile).ThenInclude(p => p.UserProfileLanguages).ThenInclude(x => x.Language)
                .Include(u=>u.Profile).ThenInclude(p=>p.Description)
                .Include(u=>u.Profile).ThenInclude((p=>p.Educations))
                .Include(u=>u.Profile).ThenInclude(p=>p.Experiences)
                .Include(u=>u.Profile).ThenInclude(p=>p.City).ThenInclude(c=>c.Country)
                .Select(x => _mapper.Map<EmployeeDetailsModel>(x)).FirstOrDefault(employee => employee.Id == id);
           
            return employeeDetails;
        }

        public EmployeePdfModel GetEmployeePdf(Guid id)
        {
            var user = Get(id);
            return _pdfService.GeneratePdf(user);
        }
    }
}
