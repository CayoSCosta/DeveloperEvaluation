namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.UpdateSales;

public class UpdateSaleRequest
{
    public Guid Id { get; set; }
    public DateTime SaleDate { get; set; }
    public string? Customer { get; set; }
    public string? Branch { get; set; }
}
