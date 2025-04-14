using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Sales.UpdateSale;

public class UpdateSaleCommandValidator : AbstractValidator<UpdateSaleCommand>
{
    public UpdateSaleCommandValidator()
    {
        RuleFor(x => x.SaleId).NotEmpty().WithMessage("Sale ID must be provided.");
        RuleFor(x => x.Date).NotEmpty().WithMessage("Sale date is required.");
        RuleFor(x => x.Customer).NotEmpty().WithMessage("Customer is required.");
        RuleFor(x => x.Branch).NotEmpty().WithMessage("Branch is required.");
    }
}
