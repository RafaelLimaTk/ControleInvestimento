using ControleInvestimento.Business.Core.Notifications;
using ControleInvestimento.Business.Core.Services;

namespace ControleInvestimento.Business.Models.Portifolio.Services;

public class PortfolioService : BaseService, IPortfolioService
{
    private readonly IPortfolioRepository _portfolioRepository;

    public PortfolioService(INotifier notifier, IPortfolioRepository portfolioRepository) : base(notifier)
    {
        _portfolioRepository = portfolioRepository;
    }

    public async Task Add(Portfolio portfolio)
    {
        await _portfolioRepository.Add(portfolio);
    }

    public void Dispose()
    {
        _portfolioRepository?.Dispose();
    }

    public async Task<Portfolio> GetPortfolioWithAssets(Guid portfolioId)
    {
        return await _portfolioRepository.GetPortfolioWithAssets(portfolioId);
    }
}
