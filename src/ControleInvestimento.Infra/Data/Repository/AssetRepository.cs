using ControleInvestimento.Business.Models.Asset;
using ControleInvestimento.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace ControleInvestimento.Infra.Data.Repository;

public class AssetRepository : Repository<Asset>, IAssetRepository
{
    private readonly ApplicationDbContext _context;
    public AssetRepository(ApplicationDbContext context) : base(context)
    {
        _context = context;
    }

    public Asset GetAssetWithInvestmentStaticsAndTransaction(Guid assetId)
    {
        return _context.Assets
            .Include(a => a.InvestmentStatics)
            .Include(a => a.Transactions)
            .FirstOrDefault(a => a.Id == assetId);
    }
}
