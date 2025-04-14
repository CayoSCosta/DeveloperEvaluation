using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Sales.Events;

public class SaleCreatedEventHandler : INotificationHandler<SaleCreatedEvent>
{
    public Task Handle(SaleCreatedEvent notification, CancellationToken cancellationToken)
    {        
        Console.WriteLine($"Sale {notification.Sale.Id} created!");
        return Task.CompletedTask;
    }
}
