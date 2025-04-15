using Ambev.DeveloperEvaluation.Application.Sales.GetSale;
using Ambev.DeveloperEvaluation.Domain.Entities.Sales;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.Application.Sales.GetAllSale;

public class GetAllSalesProfile : Profile
{
    public GetAllSalesProfile()
    {
        CreateMap<Sale, GetSaleResult>()
            .ForMember(dest => dest.SaleId, opt => opt.MapFrom(src => src.Id));
    }
}