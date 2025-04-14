namespace Ambev.DeveloperEvaluation.Application.Sales.Events;

public class SaleCreated
{
    public Guid SaleId { get; }
    public DateTime Date { get; }

    public SaleCreated(Guid saleId, DateTime date)
    {
        SaleId = saleId;
        Date = date;
    }
}