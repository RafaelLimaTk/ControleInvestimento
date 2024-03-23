using ControleInvestimento.Business.Core.Models;

namespace ControleInvestimento.Business.Models.Portifolio;

public class Portfolio : Entity
{
    public decimal TotalInvested { get; private set; }
    public decimal TotalVariation { get; private set; }
    public decimal TotalVariationPercentage { get; private set; }
    public List<Asset.Asset> Assets { get; private set; } = new List<Asset.Asset>();

    public void AddAsset(Asset.Asset asset)
    {
        asset.PortfolioId = this.Id;
        Assets.Add(asset);
        UpdateTotalInvested();
        UpdateTotalVariation();
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
            UpdateTotalVariation();
        }
    }

    internal void UpdateTotalInvested()
    {
        TotalInvested = Assets.Sum(a => a.InvestmentStatics.TotalValue);
    }

    internal void UpdateTotalVariation()
    {
        decimal initialTotalInvested = TotalInvested;
        decimal currentTotalInvested = CalculateCurrentTotalInvested();
        TotalVariation = currentTotalInvested - initialTotalInvested;

        TotalVariationPercentage = initialTotalInvested != 0 ? (TotalVariation / initialTotalInvested) * 100 : 0;
    }

    private decimal CalculateCurrentTotalInvested()
    {
        decimal currentTotalInvested = Assets.Sum(a => a.InvestmentStatics.TotalValue);
        return currentTotalInvested;
    }  
}
