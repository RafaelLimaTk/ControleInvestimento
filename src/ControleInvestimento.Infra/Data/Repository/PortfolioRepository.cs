using ControleInvestimento.Business.Models.Portifolio;
using ControleInvestimento.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace ControleInvestimento.Infra.Data.Repository;

public class PortfolioRepository : Repository<Portfolio>, IPortfolioRepository
{
    public PortfolioRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
    {
    }

    public async Task<Portfolio> GetPortfolioWithAssets(Guid portfolioId)
#pragma warning disable CS8603 // Possível retorno de referência nula.
        => await _applicationDbContext.Portfolios
                             .Include(p => p.Assets)
                             .ThenInclude(a => a.InvestmentStatics)
                             .FirstOrDefaultAsync(p => p.Id == portfolioId);
#pragma warning restore CS8603 // Possível retorno de referência nula.
}
