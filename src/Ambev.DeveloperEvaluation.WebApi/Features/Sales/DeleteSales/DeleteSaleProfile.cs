using Ambev.DeveloperEvaluation.Application.Sales.DeleteSale;
using Ambev.DeveloperEvaluation.WebApi.Features.Sales.DeleteSales;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.Features.Sales.Create;

public class DeleteSaleProfile : Profile
{
    public DeleteSaleProfile()
    {
        CreateMap<DeleteSaleRequest, DeleteSaleCommand>();
    }
}
