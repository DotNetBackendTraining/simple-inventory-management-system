using System.Data.SqlClient;
using SimpleInventoryManagementSystem.Domain;
using SimpleInventoryManagementSystem.Interfaces;

namespace SimpleInventoryManagementSystem.Mapper;

public class SqlProductMapper : ISqlProductMapper
{
    public Product MapToDomain(SqlDataReader dataReader) => new()
    {
        Id = dataReader.GetInt32(dataReader.GetOrdinal("ID")),
        Name = dataReader.GetString(dataReader.GetOrdinal("Name")),
        Price = dataReader.GetDecimal(dataReader.GetOrdinal("Price")),
        Quantity = dataReader.GetInt32(dataReader.GetOrdinal("Quantity"))
    };

    public SqlParameter[] MapToParameters(Product product) => new SqlParameter[]
    {
        new("@ID", product.Id),
        new("@Name", product.Name),
        new("@Price", product.Price),
        new("@Quantity", product.Quantity)
    };
}