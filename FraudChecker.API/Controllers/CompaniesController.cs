using FraudChecker.Application.Interfaces;
using FraudChecker.Domain;
using Microsoft.AspNetCore.Mvc;

namespace FraudChecker.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CompaniesController(ICompanyRepository repository) : BaseAPIController
{
    [HttpGet]
    public async Task<ActionResult<IReadOnlyList<Company>>> ListAllAsync()
    {
        var companies = await repository.ListAllAsync();

        return Ok(companies);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Company?>> GetByIdAsync(int id)
    {
        if (id <= 0)
        {
            return BadRequest("Invalid company ID. Company ID must be greater than 0.");
        }

        var company = await repository.GetByIdAsync(id);

        if (company == null)
        {
            return NotFound($"Company with ID {id} could not be found.");
        }

        return Ok(company);
    }
}
