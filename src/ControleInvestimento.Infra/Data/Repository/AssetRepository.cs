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

    public async Task<Asset> GetByIdWithTransaction(Guid id)
    {
        return await _context.Assets
            .Include(a => a.Transactions)
            .FirstOrDefaultAsync(a => a.Id == id);
    }
}
