using Ambev.DeveloperEvaluation.Application.Sales.CreateSale;
using Ambev.DeveloperEvaluation.Application.Sales.GetSale;
using Ambev.DeveloperEvaluation.WebApi.Features.Sales.GetSale;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.Features.Sales.Create;

public class CreateSaleProfile : Profile
{
    public CreateSaleProfile()
    {
        CreateMap<CreateSaleRequest, CreateSaleCommand>();
        //CreateMap<CreateSaleItemRequest, CreateSaleItemCommand>();
        CreateMap<GetSaleRequest, GetSaleCommand>();
        CreateMap<GetSaleCommandResult, GetSaleResponse>();

    }
}
