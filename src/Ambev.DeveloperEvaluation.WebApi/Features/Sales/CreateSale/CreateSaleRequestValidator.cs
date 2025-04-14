using Ambev.DeveloperEvaluation.Features.Sales.Create;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.CreateSale;

public class CreateSaleRequestValidator : AbstractValidator<CreateSaleRequest>
{
    public CreateSaleRequestValidator()
    {
        RuleFor(x => x.Customer).NotEmpty();
        RuleFor(x => x.Branch).NotEmpty();
        RuleFor(x => x.Items)
            .NotEmpty().WithMessage("A venda precisa conter ao menos um item.")
            .ForEach(item =>
            {
                item.SetValidator(new CreateSaleItemRequestValidator());
            });
    }
}

public class CreateSaleItemRequestValidator : AbstractValidator<CreateSaleItemRequest>
{
    public CreateSaleItemRequestValidator()
    {
        RuleFor(x => x.ProductName).NotEmpty();
        RuleFor(x => x.Quantity).GreaterThan(0).LessThanOrEqualTo(20);
        RuleFor(x => x.UnitPrice).GreaterThan(0);
    }
}
