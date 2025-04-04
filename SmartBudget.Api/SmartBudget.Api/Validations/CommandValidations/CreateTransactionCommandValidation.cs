using FluentValidation;
using SmartBudget.Api.Features.Commands.TransactionCommands;

namespace SmartBudget.Api.Validations.CommandValidations;

public class CreateTransactionCommandValidation : AbstractValidator<CreateTransactionCommand>
{
    public CreateTransactionCommandValidation()
    {
        RuleFor(x => x.Amount)
            .NotEmpty()
            .WithMessage("Amount is required.")
            .GreaterThan(0)
            .WithMessage("Amount must be greater than 0.");

        RuleFor(x => x.CategoryId)
            .NotEmpty()
            .WithMessage("CategoryId is required.");
    }
}
