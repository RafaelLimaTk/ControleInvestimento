using ControleInvestimento.Business.Models.Asset;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ControleInvestimento.Infra.Data.EntitiesConfiguration;

public class AssetConfiguration : IEntityTypeConfiguration<Asset>
{
    public void Configure(EntityTypeBuilder<Asset> builder)
    {
        builder.Property(a => a.Name)
                .IsRequired()
                .HasMaxLength(100);

        builder.Property(a => a.Quantity)
                .IsRequired();

        builder.Property(a => a.Category)
                .IsRequired();

        builder.Property(a => a.AveragePrice)
                .IsRequired();

        builder.Property(a => a.CurrentPrice)
                .IsRequired();

        builder.Property(a => a.InitialInvestment)
                .IsRequired();

        builder.Property(a => a.TotalBalance)
                .IsRequired();

        builder.Property(a => a.CategoryPercentage)
                .IsRequired();

        builder.Property(a => a.IdealPercentage)
                .IsRequired();

        builder.Property(a => a.IdealValue)
                .IsRequired();

        builder.ToTable("Ativos");
    }
}
