namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.GetAllSales;

public class GetAllSalesResponse
{
    public Guid Id { get; set; }
    public string? SaleNumber { get; set; }
    public decimal TotalAmount { get; set; }
    public DateTime SaleDate { get; set; }
    public string? Customer { get; set; }
}
