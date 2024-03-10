using ControleInvestimento.Business.Core.Models;
using ControleInvestimento.Business.Models.Asset;

namespace ControleInvestimento.Business.Models.Transaction;

public class Transaction : Entity
{
    public Guid AssetId { get; private set; }
    public DateTime Date { get; private set; }
    public int Quantity { get; private set; }
    public decimal Price { get; private set; }
    public bool IsBuy { get; private set; }

    public Asset.Asset Asset { get; set; }

    public Transaction() { }

    public Transaction(int quantity, decimal price, bool isBuy)
    {
        Date = DateTime.Now;
        Quantity = quantity;
        Price = price;
        IsBuy = isBuy;
    }

    internal void AssociateAsset(Guid assetId)
    {
        AssetId = assetId;
    }

    internal decimal CalculateTransaction()
    {
        return Quantity * Price;
    }
}
