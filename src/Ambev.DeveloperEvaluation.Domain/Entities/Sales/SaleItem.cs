namespace Ambev.DeveloperEvaluation.Domain.Entities.Sales;
public class SaleItem
{
    public SaleItem(Guid productId, string productName, int quantity, decimal unitPrice)
    {
        Id = Guid.NewGuid();
        ProductId = productId;
        ProductName = productName;
        Quantity = quantity;
        UnitPrice = unitPrice;
        ApplyDiscount();
    }

    public Guid Id { get; set; }
    public Guid ProductId { get; set; }
    public string ProductName { get; set; } = default!;
    public int Quantity { get; set; }
    public decimal UnitPrice { get; set; }
    public decimal Discount { get; set; }
    public bool IsCancelled { get; private set; }

    public decimal TotalAmount => UnitPrice * Quantity - Discount;

    public void ApplyDiscount()
    {
        //De 10 a 20 itens: 20 % de desconto
        if (Quantity >= 10 && Quantity <= 20) //
            Discount = UnitPrice * Quantity * 0.20m;
        ///4 ou mais itens: 10% de desconto
        else if (Quantity >= 4) 
            Discount = UnitPrice * Quantity * 0.10m;
        else
            Discount = 0;
    }

    public void Cancel()
    {
        IsCancelled = true;
    }

    public void Update(string productName, int quantity, decimal unitPrice)
    {
        ProductName = productName;
        Quantity = quantity;
        UnitPrice = unitPrice;
    }
}
