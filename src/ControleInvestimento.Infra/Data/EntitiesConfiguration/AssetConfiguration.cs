using ControleInvestimento.Business.Models.Asset;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ControleInvestimento.Infra.Data.EntitiesConfiguration;

public class AssetConfiguration : IEntityTypeConfiguration<Asset>
{
    public void Configure(EntityTypeBuilder<Asset> builder)
    {
        builder.HasKey(a => a.Id);

        builder.Property(a => a.Name)
                .IsRequired()
                .HasMaxLength(100);

        builder.Property(a => a.Category)
                .IsRequired();

        builder.Property(a => a.AveragePrice)
                .IsRequired()
                .HasColumnType("decimal(18, 2)");

        builder.HasMany(a => a.Transactions)
            .WithOne(t => t.Asset)
            .HasForeignKey(t => t.AssetId);

        builder.ToTable("Ativos");
    }
}
