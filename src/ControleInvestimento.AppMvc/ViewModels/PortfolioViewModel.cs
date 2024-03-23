namespace ControleInvestimento.AppMvc.ViewModels;

public class PortfolioViewModel
{
    public Guid Id { get; set; }
    public decimal TotalInvested { get; set; }
    public List<AssetViewModel> Assets { get; set; } = new List<AssetViewModel>();
}