using SimpleInventoryManagementSystem.Domain;

namespace SimpleInventoryManagementSystem.Interfaces;

public interface IProductRepository
{
    IAsyncEnumerable<Product> GetAllProductsAsync();
    Task<Product?> GetProductByNameAsync(string productName);
    Task DeleteProductByNameAsync(string productName);
    Task AddProductAsync(Product product);
}