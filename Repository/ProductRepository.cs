using SimpleInventoryManagementSystem.Domain;

namespace SimpleInventoryManagementSystem.Repository;

public class ProductRepository
{
    private readonly List<Product> _products = [];

    public IEnumerable<Product> GetAllProducts() => _products;

    public Product? GetProductByName(string productName) =>
        _products.FirstOrDefault(p => p.Name == productName);

    public void DeleteProductByName(string productName) =>
        _products.RemoveAll(p => p.Name == productName);

    public void AddProduct(Product product) =>
        _products.Add(product);
}