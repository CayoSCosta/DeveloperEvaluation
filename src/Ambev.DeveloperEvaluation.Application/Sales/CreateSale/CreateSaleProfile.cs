using Ambev.DeveloperEvaluation.Application.Sales.DeleteSale;
using Ambev.DeveloperEvaluation.Domain.Entities.Sales;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.Application.Sales.CreateSale;

public class CreateSaleProfile : Profile
{
    public CreateSaleProfile()
    {
        CreateMap<CreateSaleCommand, Sale>()
            .ConstructUsing(cmd => new Sale(cmd.Date, cmd.Customer, cmd.Branch))
            .AfterMap((cmd, sale) =>
            {
                foreach (var item in cmd.Items)
                {
                    sale.AddItem(item.ProductId, item.ProductName, item.Quantity, item.UnitPrice);
                }
            });
    }
}
