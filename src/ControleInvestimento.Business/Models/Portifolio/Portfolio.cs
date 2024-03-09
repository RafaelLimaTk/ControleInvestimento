using ControleInvestimento.Business.Core.Models;

namespace ControleInvestimento.Business.Models.Portifolio;

public class Portfolio : Entity
{
    public decimal TotalInvested { get; private set; }
    public List<Asset.Asset> Assets { get; private set; } = new List<Asset.Asset>();

    public void AddAsset(Asset.Asset asset)
    {
        asset.PortfolioId = this.Id;
        Assets.Add(asset);
        UpdateTotalInvested();
    }

    public void UpdateAsset(Asset.Asset asset)
    {
        Assets.Remove(asset);
        AddAsset(asset);
    }

    public void RemoveAsset(Asset.Asset asset)
    {
        if (Assets.Remove(asset))
        {
            UpdateTotalInvested();
        }
    }

    internal void UpdateTotalInvested()
    {
        TotalInvested = Assets.Sum(a => a.InvestmentStatics.TotalValue);
    }
}
