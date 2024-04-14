using System.Data.SqlClient;

namespace SimpleInventoryManagementSystem.Interfaces;

public interface ISqlDataSource
{
    SqlDataReader ExecuteQuery(string sql, IEnumerable<SqlParameter> parameters);
    object ExecuteScalar(string sql, IEnumerable<SqlParameter> parameters);
    void ExecuteNonQuery(string sql, IEnumerable<SqlParameter> parameters);
}