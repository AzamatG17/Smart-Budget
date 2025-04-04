using FluentValidation;
using SmartBudget.Api.Features.Commands.TransactionCommands;

namespace SmartBudget.Api.Validations.CommandValidations;

public class UpdateTransactionCommandValidation : AbstractValidator<UpdateTransactionCommand>
{
    public UpdateTransactionCommandValidation()
    {
        RuleFor(x => x.Id)
            .NotEmpty()
            .WithMessage("Id is required.");
        RuleFor(x => x.Amount)
            .NotEmpty()
            .WithMessage("Amount is required.")
            .GreaterThan(0)
            .WithMessage("Amount must be greater than 0.");
        RuleFor(x => x.Date)
            .NotEmpty()
            .WithMessage("Date is required.")
            .LessThanOrEqualTo(DateTime.Now)
            .WithMessage("Date must be less than or equal to today.");
        RuleFor(x => x.CategoryId)
            .NotEmpty()
            .WithMessage("CategoryId is required.");
    }
}
