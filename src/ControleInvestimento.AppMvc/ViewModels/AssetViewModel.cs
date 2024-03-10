using ControleInvestimento.Business.Models.Asset;

namespace ControleInvestimento.AppMvc.ViewModels;

public class AssetViewModel
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public InvestmentCategory Category { get; set; }
    public List<TransactionViewModel> Transactions { get; set; } = new List<TransactionViewModel>();
    public InvestmentStaticsViewModel InvestmentStatics { get; set; }
}
