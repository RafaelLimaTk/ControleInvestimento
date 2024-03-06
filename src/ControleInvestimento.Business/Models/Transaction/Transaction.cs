using ControleInvestimento.Business.Core.Models;

namespace ControleInvestimento.Business.Models.Transaction;

public class Transaction : Entity
{
    public Guid AssetId { get; set; }
    public DateTime Date { get; set; }
    public int Quantity { get; set; }
    public decimal Price { get; set; }
    public bool IsBuy { get; set; }

    public Asset.Asset Asset { get; set; }

    internal void AssociateAsset(Guid assetId)
    {
        AssetId = assetId;
    }

    internal decimal CalculateTransaction()
    {
        return Quantity * Price;
    }
}
