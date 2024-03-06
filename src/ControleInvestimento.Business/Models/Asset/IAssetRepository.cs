using ControleInvestimento.Business.Core.Data;

namespace ControleInvestimento.Business.Models.Asset;

public interface IAssetRepository : IRepository<Asset>
{
    Task<Asset> GetByIdWithTransaction(Guid id);
}
