using ControleInvestimento.Business.Core.Notifications;
using ControleInvestimento.Business.Core.Services;
using ControleInvestimento.Business.Models.Transaction.Validations;

namespace ControleInvestimento.Business.Models.Transaction.Services;

public class TransactionService : BaseService, ITransactionService
{
    private readonly ITransactionRepository _transactionRepository;
    public TransactionService(INotifier notifier, ITransactionRepository transactionRepository)
        : base(notifier)
    {
        _transactionRepository = transactionRepository;
    }

    public async Task Add(Transaction transaction)
    {
        if (!ExecuteValidation(new TransactionValidation(), transaction)) return;

        await _transactionRepository.Add(transaction);
    }

    public void Dispose()
    {
        _transactionRepository?.Dispose();
    }
}
