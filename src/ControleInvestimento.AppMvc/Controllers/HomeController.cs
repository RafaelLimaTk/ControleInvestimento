using AutoMapper;
using ControleInvestimento.AppMvc.Models;
using ControleInvestimento.AppMvc.ViewModels;
using ControleInvestimento.Business.Models.Asset;
using ControleInvestimento.Business.Models.Asset.Services;
using ControleInvestimento.Business.Models.Portifolio;
using ControleInvestimento.Business.Models.Portifolio.Services;
using ControleInvestimento.Business.Models.Transaction;
using ControleInvestimento.Business.Models.Transaction.Services;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Asset = ControleInvestimento.Business.Models.Asset.Asset;

namespace ControleInvestimento.AppMvc.Controllers
{
    public class HomeController : Controller
    {
        private readonly IAssetService _assetService;
        private readonly ITransactionService _transactionService;
        private readonly IPortfolioService _portfolioService;
        private readonly ILogger<HomeController> _logger;
        private readonly IMapper _mapper;

        public HomeController(ILogger<HomeController> logger,
                                IAssetService assetService,
                                ITransactionService transactionService,
                                IPortfolioService portfolioService, IMapper mapper)
        {
            _logger = logger;
            _assetService = assetService;
            _transactionService = transactionService;
            _portfolioService = portfolioService;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var portfolioWithAssets = await _portfolioService.GetPortfolioWithAssets(Guid.Parse("7c5c6310-51d8-4ad5-bd9d-914909e74ea3"));

            return View(_mapper.Map<PortfolioViewModel>(portfolioWithAssets));
        }

        private async Task<Asset> GetAsset(Guid id)
        {
            return await _assetService.GetById(id);
        }

        [HttpPost]
        public async Task<IActionResult> AddAssetTransaction()
        {
            var portfolioWithAssets = await _portfolioService.GetPortfolioWithAssets(Guid.Parse("7c5c6310-51d8-4ad5-bd9d-914909e74ea3"));
            var asset = new Asset("MXRF11", InvestmentCategory.REITs, Guid.Parse("7c5c6310-51d8-4ad5-bd9d-914909e74ea3"));
            asset.AddTransaction(new Transaction(100, 10, true));

            try
            {
                portfolioWithAssets.AddAsset(asset);
                await _assetService.Add(asset);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error adding transaction");
            }

            return (Redirect(nameof(Index)));
        }

        [HttpPost]
        public async Task<IActionResult> UpdateTransaction()
        {
            var portfolioWithAssets = await _portfolioService.GetPortfolioWithAssets(Guid.Parse("7c5c6310-51d8-4ad5-bd9d-914909e74ea3"));
            var assetById = await _assetService.GetAssetWithInvestmentStatics(Guid.Parse("971c8fc4-92f4-4f8b-849e-ae6898d2e94d"));
            var transaction = new Transaction(55, 19, true);

            try
            {
                assetById.UpdateTotalInvested();
                assetById.AddTransaction(transaction);
                portfolioWithAssets.UpdateAsset(assetById);

                await _transactionService.Add(transaction);
                await _assetService.Update(assetById);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error ao atualizar o ativo");
            }

            return (Redirect(nameof(Index)));
        }
        
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}