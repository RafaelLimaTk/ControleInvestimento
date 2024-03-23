namespace ControleInvestimento.Business.Models.Asset.Services;

public interface IAssetService : IDisposable
{
    Task<IEnumerable<Asset>> GetAll();
    Task<Asset> GetById(Guid id);
    Task<Asset> GetAssetWithInvestmentStatics(Guid id);
    Task Add(Asset asset);
    Task Remove(Guid id);
    Task Update(Asset asset);
}
