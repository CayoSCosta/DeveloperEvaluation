using Ambev.DeveloperEvaluation.Application.Sales.UpdateSale;
using Ambev.DeveloperEvaluation.WebApi.Features.Sales.UpdateSales;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.Features.Sales.Create;

public class UpdateSaleProfile : Profile
{
    public UpdateSaleProfile()
    {
        CreateMap<UpdateSaleRequest, UpdateSaleCommand>();
    }
}
