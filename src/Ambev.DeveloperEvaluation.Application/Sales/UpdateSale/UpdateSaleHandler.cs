using Ambev.DeveloperEvaluation.Domain.Repositories.Sales;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Sales.UpdateSale;

public class UpdateSaleHandler : IRequestHandler<UpdateSaleCommand, Unit>
{
    private readonly ISalesRepository _repository;

    public UpdateSaleHandler(ISalesRepository repository)
    {
        _repository = repository;
    }

    public async Task<Unit> Handle(UpdateSaleCommand request, CancellationToken cancellationToken)
    {
        var sale = await _repository.GetByIdAsync(request.SaleId, cancellationToken);

        if (sale == null)
            throw new KeyNotFoundException($"Sale with ID {request.SaleId} not found.");

        sale.UpdateSaleDetails(request.Date, request.Customer, request.Branch);

        foreach (var item in request.Items)
        {
            sale.UpdateItem(item.ProductId, item.ProductName, item.Quantity, item.UnitPrice);
        }

        await _repository.UpdateAsync(sale, cancellationToken);

        return Unit.Value;
    }
}
