using SimpleInventoryManagementSystem.Domain;

namespace SimpleInventoryManagementSystem.Interfaces;

public interface IProductDao
{
    IAsyncEnumerable<Product> GetAllProductsAsync();
    Task<Product?> GetProductByNameAsync(string productName);
    Task DeleteProductByNameAsync(string productName);
    Task AddProductAsync(Product product);
}