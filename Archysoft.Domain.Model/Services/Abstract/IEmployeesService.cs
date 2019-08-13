using System;
using Archysoft.Domain.Model.Model.Employees;

namespace Archysoft.Domain.Model.Services.Abstract
{
    public interface IEmployeesService
    {
        EmployeeDetailsModel Get(Guid id);

        EmployeePdfModel GetEmployeePdf(Guid id);
    }
}
