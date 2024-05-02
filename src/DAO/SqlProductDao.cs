using System.Data;
using Dapper;
using SimpleInventoryManagementSystem.Domain;
using SimpleInventoryManagementSystem.Interfaces;

namespace SimpleInventoryManagementSystem.DAO;

public class SqlProductDao : IProductDao
{
    private readonly IDbConnection _connection;

    public SqlProductDao(IDbConnection connection)
    {
        _connection = connection;
    }

    public async Task<IEnumerable<Product>> GetAllProductsAsync()
    {
        const string sql = "SELECT * FROM Products";
        return await _connection.QueryAsync<Product>(sql);
    }

    public async Task<Product?> GetProductByNameAsync(string productName)
    {
        const string sql = "SELECT * FROM Products WHERE Name = @Name";
        var results = await _connection.QueryAsync<Product>(sql, new { Name = productName });
        return results.FirstOrDefault();
    }

    public async Task DeleteProductByNameAsync(string productName)
    {
        const string sql = "DELETE FROM Products WHERE Name = @Name";
        await _connection.ExecuteAsync(sql, new { Name = productName });
    }

    public async Task AddProductAsync(Product product)
    {
        const string sql = "INSERT INTO Products (Name, Price, Quantity) VALUES (@Name, @Price, @Quantity)";
        await _connection.ExecuteAsync(sql, product);
    }
}