using SimpleInventoryManagementSystem.Domain;
using SimpleInventoryManagementSystem.Interfaces;

namespace SimpleInventoryManagementSystem.Repository;

public class ProductRepository : IProductRepository
{
    private readonly IProductDao _productDao;
    public ProductRepository(IProductDao productDao) => _productDao = productDao;

    public IAsyncEnumerable<Product> GetAllProductsAsync() =>
        _productDao.GetAllProductsAsync();

    public async Task<Product?> GetProductByNameAsync(string productName) =>
        await _productDao.GetProductByNameAsync(productName);

    public async Task DeleteProductByNameAsync(string productName) =>
        await _productDao.DeleteProductByNameAsync(productName);

    public async Task AddProductAsync(Product product) =>
        await _productDao.AddProductAsync(product);
}