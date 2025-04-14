using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Sales.CreateSale;

public class CreateSaleValidator : AbstractValidator<CreateSaleCommand>
{
    public CreateSaleValidator()
    {
        RuleFor(x => x.Customer).NotEmpty().WithMessage("Customer is required.");
        RuleFor(x => x.Branch).NotEmpty().WithMessage("Branch is required.");
        RuleFor(x => x.Date).NotEmpty().WithMessage("Date is required.");

        RuleForEach(x => x.Items).SetValidator(new CreateSaleItemValidator());
    }

    private class CreateSaleItemValidator : AbstractValidator<CreateSaleItemRequest>
    {
        public CreateSaleItemValidator()
        {
            RuleFor(x => x.ProductId).NotEmpty();
            RuleFor(x => x.ProductName).NotEmpty();
            RuleFor(x => x.Quantity).GreaterThan(0);
            RuleFor(x => x.UnitPrice).GreaterThan(0);
        }
    }
}
