using System.Data;
using System.Data.SqlClient;
using SimpleInventoryManagementSystem.Interfaces;

namespace SimpleInventoryManagementSystem.DAO;

public class SqlDataSource : ISqlDataSource
{
    private readonly string _connectionString;
    public SqlDataSource(string connectionString) => _connectionString = connectionString;

    public SqlDataReader ExecuteQuery(string sql, IEnumerable<SqlParameter> parameters)
    {
        var connection = new SqlConnection(_connectionString);
        var command = new SqlCommand(sql, connection);
        command.Parameters.AddRange(parameters.ToArray());
        connection.Open();
        return command.ExecuteReader(CommandBehavior.CloseConnection);
    }

    public object ExecuteScalar(string sql, IEnumerable<SqlParameter> parameters)
    {
        using var connection = new SqlConnection(_connectionString);
        var command = new SqlCommand(sql, connection);
        command.Parameters.AddRange(parameters.ToArray());
        connection.Open();
        return command.ExecuteScalar();
    }

    public void ExecuteNonQuery(string sql, IEnumerable<SqlParameter> parameters)
    {
        using var connection = new SqlConnection(_connectionString);
        var command = new SqlCommand(sql, connection);
        command.Parameters.AddRange(parameters.ToArray());
        connection.Open();
        command.ExecuteNonQuery();
    }
}