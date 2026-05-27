using FraudChecker.Domain;

namespace FraudChecker.Application.Interfaces;

public interface ICompanyRepository
{
    public Task<Company> CreateAsync(Company company);
    public Task<IReadOnlyList<Company>> ListAllAsync();
    public Task<Company?> GetByIdAsync(int id);
    public Task<Company?> GetByNameAsync(string name);
    public Task<Company> UpdateAsync(Company company,int id);
    public Task DeleteAsync(int id);
}
