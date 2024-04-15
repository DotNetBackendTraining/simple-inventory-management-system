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

    public async Task<IEnumerable<Product>> GetAllProductsAsync()
    {
        const string sql = "SELECT * FROM Products";
        await using var reader = await _dataSource.ExecuteQueryAsync(sql, new List<SqlParameter>());

        var products = new List<Product>();
        while (reader.Read())
        {
            products.Add(_mapper.MapToDomain(reader));
        }

        return products;
    }

    public async Task<Product?> GetProductByNameAsync(string productName)
    {
        const string sql = "SELECT * FROM Products WHERE Name = @Name";
        var parameters = new List<SqlParameter>
        {
            new("@Name", productName)
        };
        await using var reader = await _dataSource.ExecuteQueryAsync(sql, parameters);
        return reader.Read() ? _mapper.MapToDomain(reader) : null;
    }

    public async Task DeleteProductByNameAsync(string productName)
    {
        const string sql = "DELETE FROM Products WHERE Name = @Name";
        var parameters = new List<SqlParameter>
        {
            new("@Name", productName)
        };
        await _dataSource.ExecuteNonQueryAsync(sql, parameters);
    }

    public async Task AddProductAsync(Product product)
    {
        const string sql = "INSERT INTO Products (Name, Price, Quantity) VALUES (@Name, @Price, @Quantity)";
        var parameters = _mapper.MapToParameters(product);
        await _dataSource.ExecuteNonQueryAsync(sql, parameters);
    }
}