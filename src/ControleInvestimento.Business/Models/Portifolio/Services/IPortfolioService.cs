namespace ControleInvestimento.Business.Models.Portifolio.Services;

public interface IPortfolioService : IDisposable
{
    Task Add(Portfolio portfolio);
    Task<Portfolio> GetPortfolioWithAssets(Guid portfolioId);
}
