namespace EmployeesApp.Application.Employees.Interfaces
{
    public interface ICompanyService
    {
        Task DeleteAsync(int companyID);
    }
}