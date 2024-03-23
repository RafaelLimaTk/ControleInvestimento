using ControleInvestimento.Business.Core.Notifications;
using ControleInvestimento.Business.Core.Services;
using ControleInvestimento.Business.Models.Asset.Validations;

namespace ControleInvestimento.Business.Models.Asset.Services;

public class AssetService : BaseService, IAssetService
{
    private readonly IAssetRepository _assetRepository;
    public AssetService(IAssetRepository assetRepository, INotifier notifier) : base(notifier)
    {
        _assetRepository = assetRepository;
    }

    public async Task<IEnumerable<Asset>> GetAll()
    {
        return await _assetRepository.GetAll();
    }

    public async Task<Asset> GetById(Guid id)
    {
        return await _assetRepository.GetById(id);
    }

    public async Task<Asset> GetAssetWithInvestmentStatics(Guid id)
    {
        return await _assetRepository.GetAssetWithInvestmentStaticsAndTransaction(id);
    }

    public async Task Add(Asset asset)
    {
        if (!ExecuteValidation(new AssetValidation(), asset)) return;

        await _assetRepository.Add(asset);
    }

    public async Task Update(Asset asset)
    {
        if (!ExecuteValidation(new AssetValidation(), asset)) return;

        await _assetRepository.Update(asset);
    }

    public async Task Remove(Guid id)
    {
        await _assetRepository.Remove(id);
    }

    public void Dispose()
    {
        _assetRepository?.Dispose();
    }
}
