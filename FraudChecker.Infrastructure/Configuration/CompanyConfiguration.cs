using FraudChecker.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FraudChecker.Infrastructure.Configuration;

public class CompanyConfiguration : IEntityTypeConfiguration<Company>
{
    public void Configure(EntityTypeBuilder<Company> builder)
    {
        builder
            .Property(company => company.Name)
            .IsRequired()
            .HasMaxLength(100);
        
        builder
            .HasData(
                new Company
                {
                    Id = 1,
                    Name = "Apricot Lettings"
                },
                new Company
                {
                    Id = 2,
                    Name = "Banana Lettings"
                },
                new Company
                {
                    Id = 3,
                    Name = "Cherry Lettings"
                },
                new Company
                {
                    Id = 4,
                    Name = "Elderberry Lettings"
                },
                new Company
                {
                    Id = 5,
                    Name = "Fig Lettings"
                },
                new Company
                {
                    Id = 6,
                    Name = "Grape Lettings"
                },
                new Company
                {
                    Id = 7,
                    Name = "Honeydew Lettings"
                },
                new Company
                {
                    Id = 8,
                    Name = "Iceberry Lettings"
                },
                new Company
                {
                    Id = 9,
                    Name = "Jackfruit Lettings"
                },
                new Company
                {
                    Id = 10,
                    Name = "Kiwi Lettings"
                },
                new Company
                {
                    Id = 11,
                    Name = "Lime Lettings"
                },
                new Company
                {
                    Id = 12,
                    Name = "Mango Lettings"
                },
                new Company
                {
                    Id = 13,
                    Name = "Nectarine Lettings"
                },
                new Company
                {
                    Id = 14,
                    Name = "Olive Lettings"
                },
                new Company
                {
                    Id = 15,
                    Name = "Papaya Lettings"
                },
                new Company
                {
                    Id = 16,
                    Name = "Quince Lettings"
                },
                new Company
                {
                    Id = 17,
                    Name = "Raspberry Lettings"
                },
                new Company
                {
                    Id = 18,
                    Name = "Starfruit Lettings"
                },
                new Company
                {
                    Id = 19,
                    Name = "Tangerine Lettings"
                },
                new Company
                {
                    Id = 20,
                    Name = "Ugli Fruit Lettings"
                },
                new Company
                {
                    Id = 21,
                    Name = "Vanilla Lettings"
                },
                new Company
                {
                    Id = 22,
                    Name = "Watermelon Lettings"
                },
                new Company
                {
                    Id = 23,
                    Name = "Ximena Lettings"
                },
                new Company
                {
                    Id = 24,
                    Name = "Yuzu Lettings"
                },
                new Company
                {
                    Id = 25,
                    Name = "Zucchini Lettings"
                }
        );
    }
}
