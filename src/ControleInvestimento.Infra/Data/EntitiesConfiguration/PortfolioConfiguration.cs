using ControleInvestimento.Business.Models.Portifolio;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ControleInvestimento.Infra.Data.EntitiesConfiguration;

public class PortfolioConfiguration : IEntityTypeConfiguration<Portfolio>
{
    public void Configure(EntityTypeBuilder<Portfolio> builder)
    {
        builder.HasKey(p => p.Id);

        builder.Property(p => p.TotalInvested)
            .HasColumnType("decimal(18,2)");

        builder.Property(p => p.TotalVariation)
            .HasColumnType("decimal(18,2)");

        builder.Property(p => p.TotalVariationPercentage)
            .HasColumnType("decimal(18,2)");

        builder.HasMany(p => p.Assets)
            .WithOne(p => p.Portfolio)
            .HasForeignKey(p => p.PortfolioId);

        builder.ToTable("Portifolio");
    }
}
