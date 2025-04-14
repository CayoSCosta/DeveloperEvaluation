using Ambev.DeveloperEvaluation.Application.Sales.GetSale;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Sales.GetAllSale;

public class GetAllSalesCommand : IRequest<List<GetSaleResult>>
{
}
