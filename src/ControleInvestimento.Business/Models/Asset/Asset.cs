using ControleInvestimento.Business.Core.Models;

namespace ControleInvestimento.Business.Models.Asset;

public class Asset : Entity
{
    public string Name { get; set; }
    public int Quantity { get; set; }
    public InvestmentCategory Category { get; set; }
    public decimal AveragePrice { get; set; }
    public decimal CurrentPrice { get; set; }
    public decimal InitialInvestment { get; set; }
    public decimal TotalBalance { get; set; }
    public decimal CategoryPercentage { get; set; }
    public decimal IdealPercentage { get; set; }
    public decimal IdealValue { get; set; }
}
