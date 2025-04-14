using Ambev.DeveloperEvaluation.Application.Sales.Events;
using Ambev.DeveloperEvaluation.Domain.Events.SalesEvents.SalesItem;
using Ambev.DeveloperEvaluation.Domain.Events.SalesEvents;

namespace Ambev.DeveloperEvaluation.ORM.Logging;

public static class EventLogger
{
    private const string LogFilePath = "Logs/events.txt";

    public static void LogSaleCreated(Domain.Events.SalesEvents.SaleCreated @event)
    {
        Log($"[SALE CREATED] SaleId: {@event.SaleId}, Date: {@event.SaleCreateDate}");
    }

    public static void LogSaleModified(SaleModified @event)
    {
        Log($"[SALE MODIFIED] SaleId: {@event.SaleId}, Date: {@event.Date}");
    }

    public static void LogSaleCancelled(SaleCancelled @event)
    {
        Log($"[SALE CANCELLED] SaleId: {@event.SaleId}");
    }

    public static void LogItemCancelled(ItemCancelled @event)
    {
        Log($"[ITEM CANCELLED] SaleId: {@event.SaleId}, ProductId: {@event.ProductId}");
    }

    private static void Log(string message)
    {
        var fullPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, LogFilePath);
        Directory.CreateDirectory(Path.GetDirectoryName(fullPath)!);
        File.AppendAllText(fullPath, $"{DateTime.Now:yyyy-MM-dd HH:mm:ss} - {message}\n");
    }
}
