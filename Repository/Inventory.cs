using SimpleInventoryManagementSystem.Domain;

namespace SimpleInventoryManagementSystem.Repository;

public class Inventory
{
    public List<Product> Products { get; init; } = [];
}