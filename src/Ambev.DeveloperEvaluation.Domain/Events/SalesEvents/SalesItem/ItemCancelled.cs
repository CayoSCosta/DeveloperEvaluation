namespace Ambev.DeveloperEvaluation.Domain.Events.SalesEvents.SalesItem;

public class ItemCancelled
{
    public Guid SaleId { get; }
    public Guid ProductId { get; }

    public ItemCancelled(Guid saleId, Guid productId)
    {
        SaleId = saleId;
        ProductId = productId;
    }
}
