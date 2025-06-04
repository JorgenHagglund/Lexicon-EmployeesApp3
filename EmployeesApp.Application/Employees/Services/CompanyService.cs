using EmployeesApp.Application.Employees.Interfaces;

namespace EmployeesApp.Application.Employees.Services;

public class CompanyService(IUnitOfWork unitOfWork) : ICompanyService
{
    public async Task DeleteAsync(int companyID)
    {
        var company = await unitOfWork.Companies.GetAsync(companyID) ?? 
            throw new ArgumentException($"Company with ID {companyID} does not exist.");

        foreach (var employee in company.Employees)
        {
            await unitOfWork.Employees.RemoveAsync(employee.Id);
        }
        await unitOfWork.Companies.RemoveAsync(companyID);
        await unitOfWork.PersistAllAsync();

    }
}