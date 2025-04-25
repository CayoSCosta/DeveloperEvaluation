using Ambev.DeveloperEvaluation.Domain.Entities.Sales;

namespace Ambev.DeveloperEvaluation.Application.Sales.GetAll
{
    public class GetAllSalesResult
    {
        public Guid Id { get; set; }
        public string Customer { get; set; } = string.Empty;
        public string Branch { get; set; } = string.Empty;
        public decimal TotalAmount { get; set; }
        public DateTime SaleDate { get; set; }

        public GetAllSalesResult(Sale sale)
        {
            Id = sale.Id;
            Customer = sale.Customer;
            Branch = sale.Branch;
            TotalAmount = sale.TotalAmount;
            SaleDate = sale.SaleDate;
        }

    }
}
