using ControleInvestimento.Business.Models.Asset;
using ControleInvestimento.Infra.Data.Context;

namespace ControleInvestimento.Infra.Data.Repository;

public class TransactionRepository : Repository<Transaction>, ITransactionRepository
{
    public TransactionRepository(ApplicationDbContext context) : base(context)
    {
    }
}
