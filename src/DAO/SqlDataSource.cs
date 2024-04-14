using System.Data;
using System.Data.SqlClient;
using SimpleInventoryManagementSystem.Common;
using SimpleInventoryManagementSystem.Interfaces;

namespace SimpleInventoryManagementSystem.DAO;

public class SqlDataSource : ISqlDataSource
{
    private readonly string _connectionString;
    public SqlDataSource(string connectionString) => _connectionString = connectionString;

    public SqlDataReader ExecuteQuery(string sql, IEnumerable<SqlParameter> parameters)
    {
        try
        {
            var connection = new SqlConnection(_connectionString);
            var command = new SqlCommand(sql, connection);
            command.Parameters.AddRange(parameters.ToArray());
            connection.Open();
            return command.ExecuteReader(CommandBehavior.CloseConnection);
        }
        catch (SqlException ex)
        {
            throw new SqlDataException("An error occurred executing SQL query.", ex);
        }
    }

    public object ExecuteScalar(string sql, IEnumerable<SqlParameter> parameters)
    {
        try
        {
            using var connection = new SqlConnection(_connectionString);
            var command = new SqlCommand(sql, connection);
            command.Parameters.AddRange(parameters.ToArray());
            connection.Open();
            return command.ExecuteScalar();
        }
        catch (SqlException ex)
        {
            throw new SqlDataException("An error occurred executing SQL scalar query.", ex);
        }
    }

    public void ExecuteNonQuery(string sql, IEnumerable<SqlParameter> parameters)
    {
        try
        {
            using var connection = new SqlConnection(_connectionString);
            var command = new SqlCommand(sql, connection);
            command.Parameters.AddRange(parameters.ToArray());
            connection.Open();
            command.ExecuteNonQuery();
        }
        catch (SqlException ex)
        {
            throw new SqlDataException("An error occurred executing SQL non-query.", ex);
        }
    }
}