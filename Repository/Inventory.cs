using SimpleInventoryManagementSystem.Domain;

namespace SimpleInventoryManagementSystem.Repository;

public class Inventory
{
    public List<Product> Products { get; init; } = [];

    public Product? this[string productName]
    {
        get { return Products.FirstOrDefault(p => p.Name == productName); }
    }
}