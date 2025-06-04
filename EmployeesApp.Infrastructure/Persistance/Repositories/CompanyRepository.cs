using EmployeesApp.Application.Employees.Interfaces;
using EmployeesApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeesApp.Infrastructure.Persistance.Repositories
{
    public class CompanyRepository(ApplicationContext context) : ICompanyRepository
    {
        public async Task<Company?> GetAsync(int companyID)
        {
            return await context.Companies
                .AsNoTracking()
                .Include(c => c.Employees) // Include employees if needed
                .FirstOrDefaultAsync(c => c.Id == companyID);
        }

        public async Task RemoveAsync(int companyID)
        {
            var company = await GetAsync(companyID);
            if (company != null)
            {
                context.Companies.Remove(company);
                await context.SaveChangesAsync();
            }
        }
    }
}
