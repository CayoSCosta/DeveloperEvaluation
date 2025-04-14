using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Sales.CreateSale;


public class CreateSaleCommand : IRequest<CreateSaleResult>
{
    public DateTime Date { get; set; }
    public string Customer { get; set; } = null!;
    public string Branch { get; set; } = null!;
    public List<CreateSaleItemRequest> Items { get; set; } = new();
}

