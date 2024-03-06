using ControleInvestimento.Business.Core.Models;

namespace ControleInvestimento.Business.Models.Asset;

public class Transaction : Entity
{
    public Guid AssetId { get; set; }
    public virtual Asset? Asset { get; set; }
    public DateTime Date { get; set; }
    public int Quantity { get; set; }
    public decimal Price { get; set; }
    public bool IsBuy { get; set; }
}
