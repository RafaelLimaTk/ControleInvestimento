namespace ControleInvestimento.AppMvc.ViewModels;

public class TransactionViewModel
{
    public Guid Id { get; set; }
    public Guid AssetId { get; private set; }
    public DateTime Date { get; private set; }
    public int Quantity { get; private set; }
    public decimal Price { get; private set; }
    public bool IsBuy { get; private set; }
}
