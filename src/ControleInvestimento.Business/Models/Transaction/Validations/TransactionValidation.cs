using FluentValidation;

namespace ControleInvestimento.Business.Models.Transaction.Validations;

public class TransactionValidation : AbstractValidator<Transaction>
{
    public TransactionValidation()
    {
        RuleFor(t => t.Price)
            .NotEmpty().WithMessage("O preço é obrigatório.")
            .GreaterThan(0).WithMessage("O preço deve ser maior que zero.");

        RuleFor(t => t.Quantity)
            .NotEmpty().WithMessage("O quantidade é obrigatório.")
            .GreaterThan(0).WithMessage("A quantidade deve ser maior que zero.");

        RuleFor(t => t.AssetId).NotEmpty().WithMessage("O ID do produto é obrigatório.");
    }
}
