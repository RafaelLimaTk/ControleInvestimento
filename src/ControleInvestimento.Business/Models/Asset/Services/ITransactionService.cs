namespace ControleInvestimento.Business.Models.Asset.Services;

public interface ITransactionService : IDisposable
{
    Task Add(Transaction transaction);
}
