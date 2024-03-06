using ControleInvestimento.Business.Models.Transaction;
using ControleInvestimento.Infra.Data.Context;

namespace ControleInvestimento.Infra.Data.Repository;

public class TransactionRepository : Repository<Transaction>, ITransactionRepository
{
    public TransactionRepository(ApplicationDbContext context) : base(context)
    {
    }
}
