using FluentValidation;
using SmartBudget.Api.Features.Commands.CategoryCommands;

namespace SmartBudget.Api.Validations.CommandValidations;

public class UpdateCategoryCommandValidator : AbstractValidator<UpdateCategoryCommand>
{
    public UpdateCategoryCommandValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty()
            .WithMessage("Id is required.");
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
