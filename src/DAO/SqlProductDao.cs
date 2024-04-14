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

    public IEnumerable<Product> GetAllProducts()
    {
        const string sql = "SELECT * FROM Products";
        using var reader = _dataSource.ExecuteQuery(sql, new List<SqlParameter>());

        var products = new List<Product>();
        while (reader.Read())
        {
            products.Add(_mapper.MapToDomain(reader));
        }

        return products;
    }

    public Product? GetProductByName(string productName)
    {
        const string sql = "SELECT * FROM Products WHERE Name = @Name";
        var parameters = new List<SqlParameter>
        {
            new("@Name", productName)
        };
        using var reader = _dataSource.ExecuteQuery(sql, parameters);
        return reader.Read() ? _mapper.MapToDomain(reader) : null;
    }

    public void DeleteProductByName(string productName)
    {
        const string sql = "DELETE FROM Products WHERE Name = @Name";
        var parameters = new List<SqlParameter>
        {
            new("@Name", productName)
        };
        _dataSource.ExecuteNonQuery(sql, parameters);
    }

    public void AddProduct(Product product)
    {
        const string sql = "INSERT INTO Products (Name, Price, Quantity) VALUES (@Name, @Price, @Quantity)";
        var parameters = _mapper.MapToParameters(product);
        _dataSource.ExecuteNonQuery(sql, parameters);
    }
}