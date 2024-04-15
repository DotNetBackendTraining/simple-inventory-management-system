using SimpleInventoryManagementSystem.Domain;
using SimpleInventoryManagementSystem.Interfaces;

namespace SimpleInventoryManagementSystem.DAO;

public class MemoryProductDao : IProductDao
{
    private readonly List<Product> _products = [];

    public async IAsyncEnumerable<Product> GetAllProductsAsync()
    {
        foreach (var product in _products)
        {
            yield return product;
        }
    }

    public Task<Product?> GetProductByNameAsync(string productName)
    {
        return Task.FromResult(_products.FirstOrDefault(p => p.Name == productName));
    }

    public Task DeleteProductByNameAsync(string productName)
    {
        _products.RemoveAll(p => p.Name == productName);
        return Task.CompletedTask;
    }

    public Task AddProductAsync(Product product)
    {
        _products.Add(product);
        return Task.CompletedTask;
    }
}