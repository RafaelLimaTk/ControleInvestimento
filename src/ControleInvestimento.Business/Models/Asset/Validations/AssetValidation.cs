using FluentValidation;

namespace ControleInvestimento.Business.Models.Asset.Validations;

public class AssetValidation : AbstractValidator<Asset>
{
    public AssetValidation()
    {
        RuleFor(a => a.Name).NotEmpty().WithMessage("Nome é requirido.");

        RuleFor(a => a.InvestmentStatics.CurrentPrice)
            .GreaterThan(0)
            .WithMessage("O preço atual deve ser maior que zero.");
    }
}
