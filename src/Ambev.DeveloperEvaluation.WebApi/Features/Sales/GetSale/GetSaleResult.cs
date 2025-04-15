namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.GetSale;

public class GetSaleResult
{
    public Guid Id { get; set; }
    public string Code { get; set; } = string.Empty;
    public decimal TotalAmount { get; set; }
    public DateTime CreatedAt { get; set; }
}