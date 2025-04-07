using FluentValidation;
using SmartBudget.Api.Features.Queries.StatisticsQueries;

namespace SmartBudget.Api.Validations.QueryValidations;

public class GetStatisticsQueryValidation : AbstractValidator<GetStatisticsQuery>
{
    public GetStatisticsQueryValidation()
    {
        RuleFor(x => x.Year)
            .NotEmpty()
            .WithMessage("Year is required.");

        RuleFor(x => x.Month)
            .NotEmpty()
            .WithMessage("Month is required.")
            .InclusiveBetween(1, 12)
            .WithMessage("Month must be between 1 and 12.");

        RuleFor(x => x.TransactionType)
            .NotEmpty()
            .WithMessage("TransactionType is required.")
            .IsInEnum()
            .WithMessage("TransactionType must be a valid enum value.");
    }
}
