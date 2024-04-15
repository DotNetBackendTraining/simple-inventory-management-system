using MongoDB.Driver;
using SimpleInventoryManagementSystem.Domain;
using SimpleInventoryManagementSystem.Interfaces;

namespace SimpleInventoryManagementSystem.DAO;

public class BsonProductDao : IProductDao
{
    private readonly IMongoCollection<Product> _collection;
    public BsonProductDao(IMongoCollection<Product> collection) => _collection = collection;

    public async IAsyncEnumerable<Product> GetAllProductsAsync()
    {
        using var cursor = await _collection.FindAsync(_ => true);
        while (await cursor.MoveNextAsync())
        {
            foreach (var product in cursor.Current)
            {
                yield return product;
            }
        }
    }

    public async Task<Product?> GetProductByNameAsync(string productName)
    {
        return await _collection.Find(p => p.Name == productName).FirstOrDefaultAsync();
    }

    public async Task DeleteProductByNameAsync(string productName)
    {
        await _collection.DeleteOneAsync(p => p.Name == productName);
    }

    public async Task AddProductAsync(Product product)
    {
        await _collection.InsertOneAsync(product);
    }
}