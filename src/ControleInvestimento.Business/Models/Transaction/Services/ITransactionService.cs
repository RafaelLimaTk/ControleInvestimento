namespace ControleInvestimento.Business.Models.Transaction.Services;

public interface ITransactionService : IDisposable
{
    Task Add(Transaction transaction);
}
