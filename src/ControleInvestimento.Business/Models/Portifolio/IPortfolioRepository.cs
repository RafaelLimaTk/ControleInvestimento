using ControleInvestimento.Business.Core.Data;

namespace ControleInvestimento.Business.Models.Portifolio;

public interface IPortfolioRepository : IRepository<Portfolio>
{
    Task<Portfolio> GetPortfolioWithAssets(Guid portfolioId);
}
