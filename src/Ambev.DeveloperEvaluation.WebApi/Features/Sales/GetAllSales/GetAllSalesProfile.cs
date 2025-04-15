using Ambev.DeveloperEvaluation.Application.Sales.GetAllSale;
using Ambev.DeveloperEvaluation.WebApi.Features.Sales.GetAllSales;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.Features.Sales.Create;

public class GetAllSalesProfile : Profile
{
    public GetAllSalesProfile()
    {
        CreateMap<GetAllSalesRequest, GetAllSalesCommand>();
    }
}
