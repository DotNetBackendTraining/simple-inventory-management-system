using SimpleInventoryManagementSystem.Domain;

namespace SimpleInventoryManagementSystem.Repository;

public class Inventory
{
    public List<Product> Products { private get; init; } = [];

    public IEnumerable<Product> GetAllProducts() => Products;

    public Product? GetProductByName(string productName) =>
        Products.FirstOrDefault(p => p.Name == productName);

    public void DeleteProductByName(string productName) =>
        Products.RemoveAll(p => p.Name == productName);

    public void AddProduct(Product product) =>
        Products.Add(product);
}