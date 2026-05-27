using FraudChecker.Domain;
using Microsoft.EntityFrameworkCore;

namespace FraudChecker.Infrastructure.Database;

public class FraudCheckerSQLDBContext(DbContextOptions options) : DbContext(options)
{
    public DbSet<Company> Companies { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
    }
}
