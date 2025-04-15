using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.DeleteSales;

public class DeleteSaleValidator : AbstractValidator<DeleteSaleRequest>
{
    public DeleteSaleValidator()
    {
        RuleFor(x => x.Id).NotEmpty().WithMessage("Sale Id is required.");
    }
}

