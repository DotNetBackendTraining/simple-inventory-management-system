using SimpleInventoryManagementSystem.Domain;
using SimpleInventoryManagementSystem.Interfaces;

namespace SimpleInventoryManagementSystem.Repository;

public class ProductRepository : IProductRepository
{
    private readonly IProductDao _productDao;
    public ProductRepository(IProductDao productDao) => _productDao = productDao;

    public IEnumerable<Product> GetAllProducts() => _productDao.GetAllProducts();

    public Product? GetProductByName(string productName) => _productDao.GetProductByName(productName);

    public void DeleteProductByName(string productName) => _productDao.DeleteProductByName(productName);

    public void AddProduct(Product product) => _productDao.AddProduct(product);
}