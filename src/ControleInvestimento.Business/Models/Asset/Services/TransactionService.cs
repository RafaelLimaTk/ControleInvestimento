using ControleInvestimento.Business.Core.Notifications;
using ControleInvestimento.Business.Core.Services;

namespace ControleInvestimento.Business.Models.Asset.Services;

public class TransactionService : BaseService, ITransactionService
{
    private readonly ITransactionRepository _transactionRepository;
    public TransactionService(INotifier notifier, ITransactionRepository transactionRepository) : base(notifier)
    {
        _transactionRepository = transactionRepository;
    }

    public async Task Add(Transaction transaction)
    {
        await _transactionRepository.Add(transaction);
    }

    public void Dispose()
    {
        _transactionRepository?.Dispose();
    }
}
