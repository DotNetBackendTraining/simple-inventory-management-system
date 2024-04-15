namespace SimpleInventoryManagementSystem.Domain;

public class Product
{
    public required string Name { get; set; }
    public required decimal Price { get; set; }
    public required int Quantity { get; set; }

    public override string ToString() => $"Product: {Name}, {Price} dollar(s), {Quantity} item(s)";
}