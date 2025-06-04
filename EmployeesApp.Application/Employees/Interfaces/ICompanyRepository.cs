using EmployeesApp.Domain.Entities;

namespace EmployeesApp.Application.Employees.Interfaces
{
    public interface ICompanyRepository
    {
        Task<Company?> GetAsync(int companyID);
        Task RemoveAsync(int companyID);
    }
}