using Ambev.DeveloperEvaluation.Domain.Entities.Sales;

namespace Ambev.DeveloperEvaluation.Application.Sales.GetSale
{
    public class GetSaleResult
    {
        public Guid SaleId { get; set; }
        public DateTime Date { get; set; }
        public string Customer { get; set; }
        public string Branch { get; set; }
        public List<GetSaleItemResult> Items { get; set; }

        public GetSaleResult(Sale sale)
        {
            SaleId = sale.Id;
            Date = sale.SaleDate;
            Customer = sale.Customer;
            Branch = sale.Branch;
            Items = sale.Items.Select(item => new GetSaleItemResult
            {
                ProductId = item.ProductId,
                ProductName = item.ProductName,
                Quantity = item.Quantity,
                UnitPrice = item.UnitPrice
            }).ToList();
        }
    }
}

//public class GetSaleResult
//{
//    public Guid SaleId { get; set; }
//    public DateTime Date { get; set; }
//    public string Customer { get; set; }
//    public string Branch { get; set; }
//    public List<GetSaleItemResult> Items { get; set; } = new();
//}

//public class GetSaleItemResult
//{
//    public Guid ProductId { get; set; }
//    public string ProductName { get; set; }
//    public int Quantity { get; set; }
//    public decimal UnitPrice { get; set; }
//}

//public class GetSaleResult
//{
//    public Guid Id { get; set; }
//    public string Code { get; set; } = string.Empty;
//    public decimal TotalAmount { get; set; }
//    public DateTime CreatedAt { get; set; }
//}