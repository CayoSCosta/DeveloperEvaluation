using Ambev.DeveloperEvaluation.Application.Sales.UpdateSale;
using Ambev.DeveloperEvaluation.Domain.Repositories.Sales;
using AutoMapper;
using MediatR;

public class UpdateSaleHandler : IRequestHandler<UpdateSaleCommand, UpdateSaleResult>
{
    private readonly ISalesRepository _repository;
    private readonly IMapper _mapper; // Supondo que você precise de um mapper

    public UpdateSaleHandler(ISalesRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<UpdateSaleResult> Handle(UpdateSaleCommand request, CancellationToken cancellationToken)
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

        return new UpdateSaleResult(sale.Id);
    }
}
