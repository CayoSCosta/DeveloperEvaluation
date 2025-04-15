using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.UpdateSales;

public class UpdateSaleRequestValidator : AbstractValidator<UpdateSaleRequest>
{
    public UpdateSaleRequestValidator()
    {
        RuleFor(x => x.Id).NotEmpty().WithMessage("Sale Id is required.");
        RuleFor(x => x.SaleDate).NotEmpty().WithMessage("Sale Date is required.");
        RuleFor(x => x.Customer).NotEmpty().WithMessage("Customer is required.");
        RuleFor(x => x.Branch).NotEmpty().WithMessage("Branch is required.");
    }
}

