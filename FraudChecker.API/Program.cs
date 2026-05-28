// ------------------------------------------------------------------------------------------------
// Application Entry Point
// ------------------------------------------------------------------------------------------------

using FraudChecker.Application.Interfaces;
using FraudChecker.Infrastructure.Database;
using FraudChecker.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// ------------------------------------------------------------------------------------------------
// Services Container
// ------------------------------------------------------------------------------------------------

builder.Services.AddControllers();

builder.Services.AddCors();

builder.Services.AddDbContext<FraudCheckerSQLDBContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("FraudCheckerSQLConnection"));
});

builder.Services.AddScoped<ICompanyRepository, CompanyRepository>();

var app = builder.Build();

// ------------------------------------------------------------------------------------------------
// HTTP Request Pipeline
// ------------------------------------------------------------------------------------------------

app.UseCors(cpb => cpb
    .WithOrigins("http://localhost:4200", "https://localhost:4200")
    .AllowAnyMethod()
    .AllowAnyHeader()
);

app.MapControllers();

app.Run();

// ------------------------------------------------------------------------------------------------