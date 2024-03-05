using ControleInvestimento.Business.Core.Models;
using ControleInvestimento.Business.Core.Notifications;
using FluentValidation;
using FluentValidation.Results;

namespace ControleInvestimento.Business.Core.Services;

public abstract class BaseService
{
    private readonly INotifier _notifier;
    public BaseService(INotifier notifier)
    {
        _notifier = notifier;
    }

    protected void Notify(ValidationResult validationResult)
    {
        foreach (var error in validationResult.Errors)
        {
            NotifyError(error.ErrorMessage);
        }
    }

    protected void NotifyError(string message)
    {
        _notifier.Handle(new Notification(message));
    }

    protected bool ExecuteValidation<TV, TE>(TV validation, TE entity) where TV : AbstractValidator<TE> where TE : Entity
    {
        var validator = validation.Validate(entity);

        if (validator.IsValid) return true;

        Notify(validator);

        return false;
    }
}
