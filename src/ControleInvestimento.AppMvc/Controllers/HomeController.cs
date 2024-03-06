using ControleInvestimento.AppMvc.Models;
using ControleInvestimento.Business.Models.Asset.Services;
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
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, IAssetService assetService, ITransactionService transactionService)
        {
            _logger = logger;
            _assetService = assetService;
            _transactionService = transactionService;
        }

        public async Task<IActionResult> Index()
        {
            return View();
        }

        public IActionResult AddTransaction(Asset asset, Transaction item)
        {
            ManipulateExistingCart(asset, item);

            return View(nameof(Index));
        }

        private async Task<Asset> GetAsset(Guid id)
        {
            return await _assetService.GetById(id);
        }

        private void ManipulateExistingCart(Asset asset, Transaction transaction)
        {
            asset.AddTransaction(transaction);

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