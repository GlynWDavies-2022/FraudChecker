using FraudChecker.Application.Interfaces;
using FraudChecker.Domain;
using FraudChecker.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;

namespace FraudChecker.Infrastructure.Repositories;

public class CompanyRepository(FraudCheckerSQLDBContext context) : ICompanyRepository
{
    public async Task<Company> CreateAsync(Company company)
    {
        var companyCreated = await context.Companies.AddAsync(company);

        await SaveChangesAsync();

        return companyCreated.Entity;
    }
    
    public async Task<IReadOnlyList<Company>> ListAllAsync()
    {
        if (!await context.Companies.AnyAsync())
        {
            return [];
        }

        return await context.Companies.ToListAsync();
    }

    public async Task<Company?> GetByIdAsync(int id)
    {
        if (id <= 0)
        {
            throw new ArgumentException("Invalid company id. Company id must be greater than 0!", nameof(id));
        }

        return await context.Companies.FindAsync(id);
    }

    public async Task<Company?> GetByNameAsync(string name)
    {
        if (string.IsNullOrEmpty(name))
        {
            throw new ArgumentException("Invalid company name. Company name must not be null or empty!", nameof(name));
        }

        return await context.Companies.FirstOrDefaultAsync(company => company.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
    }

    public async Task<Company> UpdateAsync(Company company, int id)
    {
        if (id <= 0)
        {
            throw new ArgumentException("Invalid company id. Company id must be greater than 0!", nameof(id));
        }

        var existingCompany = await context.Companies.FindAsync(id);

        if (existingCompany == null)
        {
            return existingCompany!;
        }

        existingCompany.Name = company.Name;

        await SaveChangesAsync();

        return existingCompany;
    }

    public async Task<Company?> DeleteAsync(int id)
    {
        var companyToDelete = await context.Companies.FindAsync(id);

        if (companyToDelete is null)
        {
            return null!;
        }

        context.Companies.Remove(companyToDelete);

        await context.SaveChangesAsync();

        return companyToDelete;
    }

    public async Task<bool> ExistsAsync(int id)
    {
        if (id <= 0)
        {
            throw new ArgumentException("Invalid company id. Company id must be greater than 0!", nameof(id));
        }

        return await context.Companies.AnyAsync(company => company.Id == id);
    }

    public async Task<bool> SaveChangesAsync()
    {
        return await context.SaveChangesAsync() > 0;
    }

}
