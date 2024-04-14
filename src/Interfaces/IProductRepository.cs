using SimpleInventoryManagementSystem.Domain;

namespace SimpleInventoryManagementSystem.Interfaces;

public interface IProductRepository
{
    IEnumerable<Product> GetAllProducts();
    Product? GetProductByName(string productName);
    void DeleteProductByName(string productName);
    void AddProduct(Product product);
}