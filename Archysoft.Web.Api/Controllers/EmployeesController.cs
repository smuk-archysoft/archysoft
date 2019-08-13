using System;
using Archysoft.Domain.Model.Model.Employees;
using Archysoft.Domain.Model.Services.Abstract;
using Archysoft.Web.Api.Model;
using Archysoft.Web.Api.Routes;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Archysoft.Web.Api.Controllers
{
    public class EmployeesController : Controller
    {
        private IEmployeesService _employeesService;

        public EmployeesController(IEmployeesService employeesService)
        {
            _employeesService = employeesService;
        }

        [HttpGet]
        [Route(RoutePaths.GetEmployee)]
        public ApiResponse<EmployeeDetailsModel> Get(Guid id)
        {
            EmployeeDetailsModel employee = _employeesService.Get(id);
            return new ApiResponse<EmployeeDetailsModel>(employee);
        }

        [HttpGet]
        [Route(RoutePaths.GetEmployeePdfDocument)]
        public ApiResponse<EmployeePdfModel> GetPdfDocument(Guid id)
        {
            var employeePdf = _employeesService.GetEmployeePdf(id);
            return new ApiResponse<EmployeePdfModel>(employeePdf);
        }
    }
}