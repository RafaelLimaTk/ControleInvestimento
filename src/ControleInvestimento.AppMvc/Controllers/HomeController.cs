using ControleInvestimento.AppMvc.Models;
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

        public HomeController(ILogger<HomeController> logger,
                                IAssetService assetService,
                                ITransactionService transactionService,
                                IPortfolioService portfolioService)
        {
            _logger = logger;
            _assetService = assetService;
            _transactionService = transactionService;
            _portfolioService = portfolioService;
        }

        public async Task<IActionResult> Index()
        {
            //var portfolio = await _portfolioService.GetPortfolioWithAssets(Guid.Parse("f3d4c190-e12a-4975-87da-4e3d39980fa4"));

            //var asset = new Asset("LEVE3", InvestmentCategory.Stocks, portfolio.Id);
            //asset.AddTransaction(new Transaction(asset.Id, 58, 37.81m, true));

            //portfolio.AddAsset(asset);

            //await _assetService.Add(asset);

            //var asset = _assetService.GetAssetWithInvestmentStatics(Guid.Parse("58480655-45e3-4f20-a120-324f08e94b44"));
            //var transacao = new Transaction(asset.Id, 13, 32.74m, true);
            //ManipulateExistingCart(asset, transacao, portfolio);

            return View();
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
            asset.AddTransaction(transaction);
            portfolio.UpdateAsset(asset);

            _assetService.Update(asset);
            _transactionService.Add(transaction);
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