using ControleInvestimento.Business.Core.Models;
using ControleInvestimento.Business.Models.Portifolio;

namespace ControleInvestimento.Business.Models.Asset;

public class Asset : Entity
{
    public string Name { get; private set; }
    public InvestmentCategory Category { get; private set; }
    public List<Transaction.Transaction> Transactions { get; private set; } = new List<Transaction.Transaction>();
    public InvestmentStatics InvestmentStatics { get; private set; }
    public Guid PortfolioId { get; set; }
    public Portfolio Portfolio { get; set; }

    public Asset() { }

    public Asset(string name, InvestmentCategory category, Guid portfolioId)
    {
        Name = name;
        Category = category;
        PortfolioId = portfolioId;
        InvestmentStatics = new InvestmentStatics();
    }

    public void AddTransaction(Transaction.Transaction transaction)
    {
        transaction.AssociateAsset(Id);

        Transactions.Add(transaction);
        UpdateInvestmentStatics(transaction);
        GetAveragePrice();
    }

    public void GetAveragePrice()
    {
        var totalQuantity = 0;
        decimal totalCost = 0;

        foreach (var transaction in Transactions.Where(t => t.IsBuy))
        {
            totalQuantity += transaction.Quantity;
            totalCost += transaction.Price * transaction.Quantity;
        }

        var averagePrice = totalQuantity > 0 ? totalCost / totalQuantity : 0;
        InvestmentStatics.SetAveragePrice(averagePrice);
    }

    internal void UpdateInvestmentStatics(Transaction.Transaction transaction)
    {
        InvestmentStatics.AssociateAsset(Id);

        ValueTotalForBuyAsset(transaction);
    }

    internal void ValueTotalForBuyAsset(Transaction.Transaction transaction)
    {
        if (!transaction.IsBuy) return;

        var valor = transaction.CalculateTransaction();
        InvestmentStatics.AddToTotalValue(valor);
    }
}
