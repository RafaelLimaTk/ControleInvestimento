using FluentValidation;

namespace ControleInvestimento.Business.Models.Asset.Validations;

public class AssetValidation : AbstractValidator<Asset>
{
    public AssetValidation()
    {
        RuleFor(x => x.Name).NotEmpty().WithMessage("Nome é requirido.");
        RuleFor(x => x.Quantity).GreaterThan(0).WithMessage("Quantidade deve ser maior que zero.");
        RuleFor(x => x.AveragePrice).GreaterThan(0).WithMessage("O preço médio deve ser maior que zero.");
        RuleFor(x => x.CurrentPrice).GreaterThan(0).WithMessage("O preço atual precisa ser maior que zero.");
        RuleFor(x => x.InitialInvestment).GreaterThan(0).WithMessage("O investimento inicial deve ser maior que zero.");
    }
}
