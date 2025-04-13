namespace Ambev.DeveloperEvaluation.Domain.Entities.Sales;

public class Sale
{
    public Guid Id { get; set; }
    public string SaleNumber { get; set; } = default!;
    public DateTime SaleDate { get; set; }
    public string Customer { get; set; } = default!;
    public string Branch { get; set; } = default!;
    public List<SaleItem> Items { get; set; } = new();
    public bool IsCancelled { get; set; }

    public decimal TotalAmount => Items.Sum(item => item.TotalAmount);

    public void Cancel()
    {
        IsCancelled = true;
        foreach (var item in Items)
            item.Cancel();
    }
}
