namespace ControleInvestimento.Business.Models.Asset.Services;

public interface IAssetService : IDisposable
{
    Task<IEnumerable<Asset>> GetAll();
    Task Add(Asset asset);
    Task Remove(Guid id);
    Task Update(Asset asset);
}
