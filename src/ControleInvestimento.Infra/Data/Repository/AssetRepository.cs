using ControleInvestimento.Business.Core.Data;
using ControleInvestimento.Business.Models.Asset;
using ControleInvestimento.Infra.Data.Context;

namespace ControleInvestimento.Infra.Data.Repository;

public class AssetRepository : Repository<Asset>, IAssetRepository
{
    public AssetRepository(ApplicationDbContext context) : base(context) { }
}
