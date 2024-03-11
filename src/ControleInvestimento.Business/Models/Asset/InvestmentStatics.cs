using ControleInvestimento.Business.Core.Models;

namespace ControleInvestimento.Business.Models.Asset;

public class InvestmentStatics : Entity
{
    public Guid AssetId { get; set; }
    public decimal AveragePrice { get; private set; }
    public decimal CurrentPrice { get; private set; }
    public decimal TotalValue { get; private set; }

    public Asset Asset { get; private set; }

    internal void AssociateAsset(Guid assetId)
    {
        AssetId = assetId;
    }

    internal void SetCurrentPrice(decimal currentPrice)
    {
        if (currentPrice == 0) return;

        CurrentPrice = currentPrice;
    }

    internal void SetAveragePrice(decimal averagePrice)
    {
        if (averagePrice < 0) averagePrice = 0;

        AveragePrice = averagePrice;
        SetCurrentPrice(averagePrice);
    }

    internal void AddToTotalValue(decimal totalValue)
    {
        TotalValue += totalValue;
    }
}
