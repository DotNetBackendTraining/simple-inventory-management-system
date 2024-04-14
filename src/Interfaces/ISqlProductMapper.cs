using System.Data.SqlClient;
using SimpleInventoryManagementSystem.Domain;

namespace SimpleInventoryManagementSystem.Interfaces;

public interface ISqlProductMapper
{
    Product MapToDomain(SqlDataReader dataReader);
    SqlParameter[] MapToParameters(Product product);
}