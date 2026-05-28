using FraudChecker.API.Controllers;
using FraudChecker.Application.Interfaces;
using FraudChecker.Domain;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace FraudChecker.API.Tests.Controllers;

public class CompaniesControllerTests
{
    private readonly Mock<ICompanyRepository> _mockRepository;

    private readonly CompaniesController _controller;

    public CompaniesControllerTests()
    {
        _mockRepository = new Mock<ICompanyRepository>();

        _controller = new CompaniesController(_mockRepository.Object);
    }

    [Fact]
    public async Task ListAllAsync_ReturnsOkResult_WithListOfCompanies()
    {
        // Arrange

        var companies = new List<Company>
        {
            new() { Id = 1, Name = "Apricot Lettings" },
            new() { Id = 2, Name = "Banana Rentals" },
            new() { Id = 3, Name = "Cherry Rentals" }
        };

        _mockRepository
            .Setup(repository => repository.ListAllAsync())
            .ReturnsAsync(companies);

        // Act

        var result = await _controller.ListAllAsync();

        // Assert

        var okResult = Assert.IsType<OkObjectResult>(result.Result);

        var returnedCompanies = Assert.IsType<IReadOnlyList<Company>>(okResult.Value, exactMatch: false);

        Assert.Equal(3, returnedCompanies.Count);
    }
}
