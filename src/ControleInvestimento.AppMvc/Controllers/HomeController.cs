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
            var portfolioWithAssets = await _portfolioService.GetPortfolioWithAssets(Guid.Parse("14e3df8e-e45b-44f1-99a3-0e003265b6fc"));

            return View(_mapper.Map<PortfolioViewModel>(portfolioWithAssets));
        }

        public IActionResult AddTransaction(Asset asset, Transaction item, Portfolio portfolio)
        {
            ManipulateExistingCart(asset, item, portfolio);

            return View(nameof(Index));
        }

        private async Task<Asset> GetAsset(Guid id)
        {
            return await _assetService.GetById(id);
        }

        private void ManipulateExistingCart(Asset asset, Transaction transaction, Portfolio portfolio)
        {
            try
            {
                asset.AddTransaction(transaction);
                portfolio.UpdateAsset(asset);

                _assetService.Update(asset);
                _transactionService.Add(transaction);
            }
            catch (Exception ex)
            {

                throw;  
            }
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