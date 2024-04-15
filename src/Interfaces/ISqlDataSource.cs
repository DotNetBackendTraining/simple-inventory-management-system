using System.Data.SqlClient;

namespace SimpleInventoryManagementSystem.Interfaces;

public interface ISqlDataSource
{
    Task<SqlDataReader> ExecuteQueryAsync(string sql, IEnumerable<SqlParameter> parameters);
    Task<object?> ExecuteScalarAsync(string sql, IEnumerable<SqlParameter> parameters);
    Task ExecuteNonQueryAsync(string sql, IEnumerable<SqlParameter> parameters);
}