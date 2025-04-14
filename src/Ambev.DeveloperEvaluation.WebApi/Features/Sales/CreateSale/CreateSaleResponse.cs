namespace Ambev.DeveloperEvaluation.Features.Sales.CreateSale;

public class CreateSaleResponse
{
    public Guid Id { get; set; }
    public string Client { get; set; } = string.Empty;
    public string Branch { get; set; } = string.Empty;
    public decimal TotalAmount { get; set; }
    public DateTime SaleDate { get; set; }
}
