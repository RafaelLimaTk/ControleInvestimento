using ControleInvestimento.AppMvc.ViewModels;
using ControleInvestimento.Business.Models.Asset;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace ControleInvestimento.AppMvc.Helpers;

[HtmlTargetElement("*", Attributes = "assets, portfolio-total-value")]
public class InvestmentDiversificationTagHelper : TagHelper
{
    [HtmlAttributeName("assets")]
    public List<AssetViewModel> Assets { get; set; }

    [HtmlAttributeName("portfolio-total-value")]
    public decimal PortfolioTotalValue { get; set; }

    private static readonly Dictionary<InvestmentCategory, string> CategoryColors = new Dictionary<InvestmentCategory, string>
    {
        { InvestmentCategory.Stocks, "primary" },
        { InvestmentCategory.REITs, "secundary" },
        { InvestmentCategory.ETFs, "info" },
    };

    public override void Process(TagHelperContext context, TagHelperOutput output)
    {
        output.TagName = "div";
        output.Attributes.SetAttribute("class", "card bg-light rounded shadow");

        var diversification = CalculateDiversification(Assets);

        var content = $@"
                <div class='card-body'>
                    <h5 class='card-title'>Diversificação do Portfólio</h5>";

        foreach (var item in diversification)
        {
            var colorClass = CategoryColors.TryGetValue(item.Category, out var color) ? color : "bg-primary";
            content += $@"
                    <div class='progress mb-3'>
                        <div class='progress-bar bg-{colorClass}' role='progressbar' style='width: {item.Percentage}%;' aria-valuenow='{item.Percentage}' aria-valuemin='0' aria-valuemax='100'>{item.Category}</div>
                    </div>";
        }

        content += @"
                </div>";

        output.Content.SetHtmlContent(content);
    }

    private List<DiversificationItem> CalculateDiversification(List<AssetViewModel> assets)
    {
        var diversification = new List<DiversificationItem>();

        if (PortfolioTotalValue <= 0)
            throw new InvalidOperationException("O valor total do portfólio deve ser maior que zero.");

        foreach (var category in Enum.GetValues(typeof(InvestmentCategory)).Cast<InvestmentCategory>())
        {
            var categoryValueSum = assets.Where(a => a.Category == category).Sum(a => a.InvestmentStatics.TotalValue);
            var percentage = (categoryValueSum / PortfolioTotalValue) * 100;

            diversification.Add(new DiversificationItem
            {
                Category = category,
                Percentage = Math.Round(percentage)
            });
        }

        return diversification;
    }

    private class DiversificationItem
    {
        public InvestmentCategory Category { get; set; }
        public decimal Percentage { get; set; }
    }
}
