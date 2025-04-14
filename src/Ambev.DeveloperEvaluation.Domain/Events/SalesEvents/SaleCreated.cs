using MediatR;

namespace Ambev.DeveloperEvaluation.Domain.Events.SalesEvents;

public class SaleCreated : INotification
{
    public Guid SaleId { get; }
    public DateTime SaleCreateDate { get; }

    public SaleCreated(Guid saleId, DateTime saleCreateDate)
    {
        SaleId = saleId;
        SaleCreateDate = saleCreateDate;
    }
}
