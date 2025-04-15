using Ambev.DeveloperEvaluation.Application.Sales.CreateSale;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.Features.Sales.Create;

public class CreateSaleProfile : Profile
{
    public CreateSaleProfile()
    {
        CreateMap<CreateSaleRequest, CreateSaleCommand>();
        //CreateMap<CreateSaleItemRequest, CreateSaleItemCommand>();
        //CreateMap<GetSaleRequest, GetSaleCommand>();
        //CreateMap<WebApi.Features.Sales.GetSale.GetSaleResult, GetSaleResponse>();
        //CreateMap<Sale, GetAllSalesResponse>();
        //CreateMap<UpdateSaleRequest, UpdateSaleCommand>();
        //CreateMap<DeleteSaleRequest, DeleteSaleCommand>();
    }
}
