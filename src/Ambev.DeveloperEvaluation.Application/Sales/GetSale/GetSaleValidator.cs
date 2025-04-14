using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Sales.GetSale;

public class GetSaleValidator : AbstractValidator<GetSaleCommand>
{
    public class GetSaleCommandValidator : AbstractValidator<GetSaleCommand>
    {
        public GetSaleCommandValidator()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("Sale ID must be provided.");
        }
    }
}
