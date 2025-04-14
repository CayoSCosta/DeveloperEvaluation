namespace Ambev.DeveloperEvaluation.Domain.Events.SalesEvents;

public class SaleModified
{
    public Guid SaleId { get; }
    public DateTime Date { get; }

    public SaleModified(Guid saleId, DateTime date)
    {
        SaleId = saleId;
        Date = date;
    }
}
