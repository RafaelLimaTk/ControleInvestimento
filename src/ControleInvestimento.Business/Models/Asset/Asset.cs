using ControleInvestimento.Business.Core.Models;
using System.Transactions;

namespace ControleInvestimento.Business.Models.Asset;

public class Asset : Entity
{
    public string Name { get; private set; }
    public InvestmentCategory Category { get; private set; }
    private List<Transaction> _transactions = new List<Transaction>();
    public IEnumerable<Transaction> Transactions => _transactions.AsReadOnly();
    public decimal AveragePrice { get; private set; }

    public Asset() { }

    public Asset(string name, InvestmentCategory category)
    {
        Name = name;
        Category = category;
    }

    public void AddTransaction(DateTime date, int quantity, decimal price, bool isBuy)
    {
        _transactions.Add(new Transaction
        {
            Id = Guid.NewGuid(),
            AssetId = this.Id,
            Date = date,
            Quantity = quantity,
            Price = price,
            IsBuy = isBuy
        });

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

        AveragePrice = totalQuantity > 0 ? totalCost / totalQuantity : 0;
    }

}
