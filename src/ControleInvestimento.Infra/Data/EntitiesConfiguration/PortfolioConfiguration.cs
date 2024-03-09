using ControleInvestimento.Business.Models.Asset;
using ControleInvestimento.Business.Models.Portifolio;
using ControleInvestimento.Business.Models.Transaction;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ControleInvestimento.Infra.Data.EntitiesConfiguration;

public class PortfolioConfiguration : IEntityTypeConfiguration<Portfolio>
{
    public void Configure(EntityTypeBuilder<Portfolio> builder)
    {
        builder.HasKey(p => p.Id);

        builder.HasMany(p => p.Assets)
            .WithOne(p => p.Portfolio)
            .HasForeignKey(p => p.PortfolioId);

        builder.ToTable("Portifolio");
    }
}
