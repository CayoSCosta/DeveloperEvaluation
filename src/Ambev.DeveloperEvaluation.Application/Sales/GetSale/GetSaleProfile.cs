using AutoMapper;
using Ambev.DeveloperEvaluation.Domain.Entities.Sales;

namespace Ambev.DeveloperEvaluation.Application.Sales.GetSale;

public class GetSaleProfile : Profile
{
    public GetSaleProfile()
    {
        CreateMap<Sale, GetSaleResult>()
            .ForMember(dest => dest.SaleId, opt => opt.MapFrom(src => src.Id));

        CreateMap<SaleItem, GetSaleItemResult>();
    }
}
