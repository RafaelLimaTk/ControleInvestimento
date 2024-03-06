using ControleInvestimento.Business.Models.Transaction;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ControleInvestimento.Infra.Data.EntitiesConfiguration;

public class TransactionConfiguration : IEntityTypeConfiguration<Transaction>
{
    public void Configure(EntityTypeBuilder<Transaction> builder)
    {
        builder.HasKey(t => t.Id);

        builder.Property(t => t.Date)
                .IsRequired();

        builder.Property(t => t.Quantity)
                .IsRequired();

        builder.Property(t => t.Price)
                .IsRequired()
                .HasColumnType("decimal(18, 2)");

        builder.Property(t => t.IsBuy)
                .IsRequired();

        builder.HasOne(t => t.Asset)
                .WithMany(a => a.Transactions)
                .HasForeignKey(t => t.AssetId);

        builder.ToTable("Transacao");
    }
}
