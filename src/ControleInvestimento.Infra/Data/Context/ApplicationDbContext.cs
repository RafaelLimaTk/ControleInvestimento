using ControleInvestimento.Business.Models.Asset;
using ControleInvestimento.Business.Models.Portifolio;
using ControleInvestimento.Business.Models.Transaction;
using Microsoft.EntityFrameworkCore;

namespace ControleInvestimento.Infra.Data.Context;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) 
        : base(options)
    { }

    public DbSet<Asset> Assets { get; set; }
    public DbSet<Transaction> Transactions { get; set; }
    public DbSet<InvestmentStatics> InvestmentStatics { get; set; }
    public DbSet<Portfolio> Portfolios { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        foreach (var property in modelBuilder.Model.GetEntityTypes()
            .SelectMany(e => e.GetProperties()
                .Where(e => e.ClrType == typeof(string))))
        {
            if (property.GetMaxLength() == null)
            {
                property.SetMaxLength(120);
            }
        }

        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);

        foreach (var relationship in modelBuilder.Model.GetEntityTypes()
            .SelectMany(e => e.GetForeignKeys()))
        {
            relationship.DeleteBehavior = DeleteBehavior.ClientSetNull;
        }
    }
}
