using System.Data.SqlClient;
using SimpleInventoryManagementSystem.Domain;
using SimpleInventoryManagementSystem.Interfaces;

namespace SimpleInventoryManagementSystem.DAO;

public class SqlProductDao : IProductDao
{
    private readonly ISqlDataSource _dataSource;
    private readonly ISqlProductMapper _mapper;

    public SqlProductDao(ISqlDataSource dataSource, ISqlProductMapper mapper)
    {
        _dataSource = dataSource;
        _mapper = mapper;
    }

    public Task<IEnumerable<Product>> GetAllProductsAsync()
    {
        const string sql = "SELECT * FROM Products";
        using var reader = _dataSource.ExecuteQuery(sql, new List<SqlParameter>());

        var products = new List<Product>();
        while (reader.Read())
        {
            products.Add(_mapper.MapToDomain(reader));
        }

        return Task.FromResult(products.AsEnumerable());
    }

    public Task<Product?> GetProductByNameAsync(string productName)
    {
        const string sql = "SELECT * FROM Products WHERE Name = @Name";
        var parameters = new List<SqlParameter>
        {
            new("@Name", productName)
        };
        using var reader = _dataSource.ExecuteQuery(sql, parameters);
        return Task.FromResult(reader.Read() ? _mapper.MapToDomain(reader) : null);
    }

    public Task DeleteProductByNameAsync(string productName)
    {
        const string sql = "DELETE FROM Products WHERE Name = @Name";
        var parameters = new List<SqlParameter>
        {
            new("@Name", productName)
        };
        _dataSource.ExecuteNonQuery(sql, parameters);
        return Task.CompletedTask;
    }

    public Task AddProductAsync(Product product)
    {
        const string sql = "INSERT INTO Products (Name, Price, Quantity) VALUES (@Name, @Price, @Quantity)";
        var parameters = _mapper.MapToParameters(product);
        _dataSource.ExecuteNonQuery(sql, parameters);
        return Task.CompletedTask;
    }
}