using ControleInvestimento.Business.Core.Models;
using ControleInvestimento.Business.Models.Portifolio;

namespace ControleInvestimento.Business.Models.Asset;

public class Asset : Entity
{
    public string Name { get; private set; }
    public InvestmentCategory Category { get; private set; }
    public List<Transaction.Transaction> Transactions { get; private set; }
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
        Transactions = new List<Transaction.Transaction>();
    }

    public void AddTransaction(Transaction.Transaction transaction)
    {
        AssociateTransactionToAsset(transaction);
        Transactions.Add(transaction);

        UpdateInvestmentStatics(transaction);
        GetAveragePrice();
    }

    internal void GetAveragePrice()
    {
        var totalCost = Transactions
            .Where(t => t.IsBuy)
            .Sum(t => t.Price * t.Quantity);

        var totalQuantity = Transactions
            .Where(t => t.IsBuy)
            .Sum(t => t.Quantity);

        var averagePrice = totalQuantity > 0 ? totalCost / totalQuantity : 0;
        InvestmentStatics.SetAveragePrice(averagePrice);
    }

    internal void UpdateInvestmentStatics(Transaction.Transaction transaction)
    {
        AssociateInvestmentStaticsToAsset();
        ValueTotalForBuyAsset(transaction);
    }

    internal void ValueTotalForBuyAsset(Transaction.Transaction transaction)
    {
        if (!transaction.IsBuy) return;

        var valor = transaction.CalculateTransaction();
        InvestmentStatics.AddToTotalValue(valor);
    }

    private void AssociateTransactionToAsset(Transaction.Transaction transaction)
    {
        transaction.AssociateAsset(Id);
    }

    private void AssociateInvestmentStaticsToAsset()
    {
        InvestmentStatics.AssociateAsset(Id);
    }

    public void UpdateTotalInvested()
    {
        InvestmentStatics.SetTotalValue(InvestmentStatics.CurrentPrice * Transactions.Sum(t => t.Quantity));
    }
}
