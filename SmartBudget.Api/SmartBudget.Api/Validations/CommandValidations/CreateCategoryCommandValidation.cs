using FluentValidation;
using SmartBudget.Api.Features.Commands.CategoryQueries;

namespace SmartBudget.Api.Validations.CommandValidations;

public class CreateCategoryCommandValidation : AbstractValidator<CreateCategoryCommand>
{
    public CreateCategoryCommandValidation()
    {
        RuleFor(x => x.Name)
            .NotEmpty()
            .WithMessage("Name is required.")
            .MaximumLength(255)
            .WithMessage("Name must not exceed 255 characters.");
        RuleFor(x => x.TransactionType)
            .IsInEnum()
            .WithMessage("TransactionType must be either Income or Expense.");
    }
}
