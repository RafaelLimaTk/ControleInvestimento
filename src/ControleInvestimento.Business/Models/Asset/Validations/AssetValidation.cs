using FluentValidation;

namespace ControleInvestimento.Business.Models.Asset.Validations;

public class AssetValidation : AbstractValidator<Asset>
{
    public AssetValidation()
    {
        RuleFor(x => x.Name).NotEmpty().WithMessage("Nome é requirido.");
        RuleFor(x => x.AveragePrice).GreaterThan(0).WithMessage("O preço médio deve ser maior que zero.");
    }
}
