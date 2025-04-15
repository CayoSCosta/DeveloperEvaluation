using Ambev.DeveloperEvaluation.Application.Sales.GetAll;
using Ambev.DeveloperEvaluation.Domain.Entities.Sales;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Sales.GetAllSale;

public class GetAllSalesCommand : IRequest<List<GetAllSalesResult>>
{
}
