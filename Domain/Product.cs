namespace SimpleInventoryManagementSystem.Domain;

public class Product(string name, int price, int quantity)
{
    public string Name { get; set; } = name;
    public int Price { get; set; } = price;
    public int Quantity { get; set; } = quantity;
}