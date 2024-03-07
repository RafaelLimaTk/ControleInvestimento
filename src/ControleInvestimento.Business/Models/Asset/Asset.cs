using ControleInvestimento.Business.Core.Models;

namespace ControleInvestimento.Business.Models.Asset;

public class Asset : Entity
{
    public string Name { get; private set; }
    public InvestmentCategory Category { get; private set; }
    public List<Transaction.Transaction> Transactions { get; set; } = new List<Transaction.Transaction>();
    public InvestmentStatics InvestmentStatics { get; set; }

    public Asset() { }

    public Asset(string name, InvestmentCategory category)
    {
        Name = name;
        Category = category;
    }

    public void AddTransaction(Transaction.Transaction transaction)
    {
        transaction.AssociateAsset(Id);

        Transactions.Add(transaction);
        GetAveragePrice();
    }

    public void GetAveragePrice()
    {
        int totalQuantity = 0;
        decimal totalCost = 0;

        foreach (var transaction in Transactions.Where(t => t.IsBuy))
        {
            totalQuantity += transaction.Quantity;
            totalCost += transaction.Price * transaction.Quantity;
        }

        InvestmentStatics.AveragePrice = totalQuantity > 0 ? totalCost / totalQuantity : 0;
    }

    public void SetCurrentPrice(decimal currentPrice)
    {
        InvestmentStatics.SetCurrentPrice(currentPrice);
    }
}
