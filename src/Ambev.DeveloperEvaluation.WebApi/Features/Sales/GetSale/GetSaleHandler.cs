using Ambev.DeveloperEvaluation.Application.Sales.GetSale;
using MediatR;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.GetSale;

public class GetSaleHandler : IRequestHandler<GetSaleCommand, GetSaleCommandResult>
{
    private readonly ISaleRepository _saleRepository;

    public GetSaleHandler(ISaleRepository saleRepository)
    {
        _saleRepository = saleRepository;
    }

    public async Task<GetSaleCommandResult> Handle(GetSaleCommand request, CancellationToken cancellationToken)
    {
        var sale = await _saleRepository.GetByIdAsync(request.Id, cancellationToken);

        if (sale == null)
            throw new KeyNotFoundException("Sale not found.");

        return new GetSaleCommandResult
        {
            Id = sale.Id,
            Code = sale.Code,
            TotalAmount = sale.TotalAmount,
            CreatedAt = sale.CreatedAt
        };
    }
}