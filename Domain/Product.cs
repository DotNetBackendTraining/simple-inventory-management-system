namespace SimpleInventoryManagementSystem.Domain;

public class Product(string name, decimal price, int quantity)
{
    public string Name { get; set; } = name;
    public decimal Price { get; set; } = price;
    public int Quantity { get; set; } = quantity;

    public override string ToString() => $"Product: {Name}, {Price} dollar(s), {Quantity} item(s)";
}