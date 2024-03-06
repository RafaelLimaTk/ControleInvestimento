using ControleInvestimento.Business.Models.Asset;
using System.ComponentModel.DataAnnotations;

namespace ControleInvestimento.AppMvc.ViewModels;

public class AssetViewModel
{
    public Guid Id { get; set; }

    [Required(ErrorMessage = "O nome do ativo é obrigatório.")]
    public string Name { get; set; }

    [Required(ErrorMessage = "A quantidade é obrigatória.")]
    [Range(1, int.MaxValue, ErrorMessage = "A quantidade deve ser maior que zero.")]
    public int Quantity { get; set; }

    [Required(ErrorMessage = "A categoria do investimento é obrigatória.")]
    public InvestmentCategory Category { get; set; }

    [Required(ErrorMessage = "O preço médio é obrigatório.")]
    [Range(0.01, double.MaxValue, ErrorMessage = "O preço médio deve ser maior que zero.")]
    public decimal AveragePrice { get; set; }

    [Required(ErrorMessage = "O preço atual é obrigatório.")]
    [Range(0.01, double.MaxValue, ErrorMessage = "O preço atual deve ser maior que zero.")]
    public decimal CurrentPrice { get; set; }

    [Required(ErrorMessage = "O investimento inicial é obrigatório.")]
    [Range(0.01, double.MaxValue, ErrorMessage = "O investimento inicial deve ser maior que zero.")]
    public decimal InitialInvestment { get; set; }

    [Required(ErrorMessage = "O saldo total é obrigatório.")]
    [Range(0.01, double.MaxValue, ErrorMessage = "O saldo total deve ser maior que zero.")]
    public decimal TotalBalance { get; set; }

    public decimal CategoryPercentage { get; set; }

    public decimal IdealPercentage { get; set; }

    public decimal IdealValue { get; set; }
}
