using Ambev.DeveloperEvaluation.Domain.Entities.Sales;
using Ambev.DeveloperEvaluation.WebApi.Features.Sales.GetAllSales;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.Features.Sales.Create;

public class GetAllSaleProfile : Profile
{
    public GetAllSaleProfile()
    {
        CreateMap<Sale, GetAllSalesResponse>();
    }
}
