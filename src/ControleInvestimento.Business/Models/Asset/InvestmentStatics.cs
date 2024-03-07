namespace ControleInvestimento.Business.Models.Asset;

public class InvestmentStatics
{
    public Guid AssetId { get; private set; }
    public decimal AveragePrice { get; private set; }
    public decimal CurrentPrice { get; private set; }
    public decimal TotalInvested { get; private set; }

    public void SetCurrentPrice(decimal currentPrice)
    {
        if (currentPrice == 0) return;

        CurrentPrice = currentPrice;
    }
}
