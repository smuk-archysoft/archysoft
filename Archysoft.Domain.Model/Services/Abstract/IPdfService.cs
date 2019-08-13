using Archysoft.Domain.Model.Model.Employees;
namespace Archysoft.Domain.Model.Services.Abstract
{
    public interface IPdfService
    {
        EmployeePdfModel GeneratePdf(EmployeeDetailsModel user);
    }
}
