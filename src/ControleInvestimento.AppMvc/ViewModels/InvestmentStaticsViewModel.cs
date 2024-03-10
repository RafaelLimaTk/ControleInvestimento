namespace ControleInvestimento.AppMvc.ViewModels;

public class InvestmentStaticsViewModel
{
    public Guid Id { get; set; }
    public decimal AveragePrice { get; set; }
    public decimal CurrentPrice { get; set; }
    public decimal TotalValue { get; set; }
}
