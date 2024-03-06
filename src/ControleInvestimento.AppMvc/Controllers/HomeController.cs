using ControleInvestimento.AppMvc.Models;
using ControleInvestimento.Business.Models.Asset;
using ControleInvestimento.Business.Models.Asset.Services;
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

        public HomeController(ILogger<HomeController> logger, IAssetService assetService)
        {
            _logger = logger;
            _assetService = assetService;
        }

        public async Task<IActionResult> Index()
        {
            Guid id = Guid.Parse("d73dd1f5-74d2-491f-a843-c8423d20e264");
            var ativoNome = "PETR4";
            var categoria = InvestmentCategory.Stocks;

            var existAtivo = await _assetService.GetById(id);

            if (existAtivo == null)
            {
                var novoAtivo = new Asset(ativoNome, categoria);
                novoAtivo.AddTransaction(DateTime.Now, 20, 40, true);
                await _assetService.Add(novoAtivo);
            }
            else
            {
                existAtivo.AddTransaction(DateTime.Now, 60, 20, true);

                await _assetService.Add(existAtivo); 
            }

            return View();
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