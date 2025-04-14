using Ambev.DeveloperEvaluation.Domain.Entities.Sales;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Sales.Events;

public class SaleCreatedEvent : INotification
{
    public Sale Sale { get; }

    public SaleCreatedEvent(Sale sale)
    {
        Sale = sale;
    }
}
