namespace Ambev.DeveloperEvaluation.Domain.Events.SalesEvents;

public class SaleCancelled
{
    public Guid SaleId { get; }

    public SaleCancelled(Guid saleId)
    {
        SaleId = saleId;
    }
}
