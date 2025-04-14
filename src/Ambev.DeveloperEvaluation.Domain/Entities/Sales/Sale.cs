using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Ambev.DeveloperEvaluation.Domain.Entities.Sales;

public class Sale
{
    public Sale(DateTime date, string customer, string branch)
    {
        Id = Guid.NewGuid();
        SaleDate = date;
        Customer = customer;
        Branch = branch;
    }


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

    public void AddItem(Guid productId, string productName, int quantity, decimal unitPrice)
    {
        Items.Add(new SaleItem(productId, productName, quantity, unitPrice));
    }
    public void UpdateItem(Guid productId, string productName, int quantity, decimal unitPrice)
    {
        var item = Items.FirstOrDefault(i => i.ProductId == productId);
        if (item != null)
        {
            item.Update(productName, quantity, unitPrice);
        }
    }

    public void UpdateSaleDetails(DateTime date, string customer, string branch)
    {
        SaleDate = date;
        Customer = customer;
        Branch = branch;
    }

}
