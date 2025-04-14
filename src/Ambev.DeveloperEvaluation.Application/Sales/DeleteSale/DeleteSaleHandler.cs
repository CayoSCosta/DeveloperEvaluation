using Ambev.DeveloperEvaluation.Domain.Repositories.Sales;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Sales.DeleteSale;

public class DeleteSaleHandler : IRequestHandler<DeleteSaleCommand, Unit>
{
    private readonly ISalesRepository _repository;

    public DeleteSaleHandler(ISalesRepository repository)
    {
        _repository = repository;
    }

    public async Task<Unit> Handle(DeleteSaleCommand request, CancellationToken cancellationToken)
    {
        var sale = await _repository.GetByIdAsync(request.SaleId, cancellationToken);

        if (sale == null)
            throw new KeyNotFoundException($"Sale with ID {request.SaleId} not found.");

        await _repository.DeleteAsync(sale.Id, cancellationToken);

        return Unit.Value;
    }
}
