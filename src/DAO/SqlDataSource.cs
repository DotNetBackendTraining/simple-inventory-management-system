using System.Data;
using System.Data.SqlClient;
using SimpleInventoryManagementSystem.Common;
using SimpleInventoryManagementSystem.Interfaces;

namespace SimpleInventoryManagementSystem.DAO;

public class SqlDataSource : ISqlDataSource
{
    private readonly string _connectionString;
    public SqlDataSource(string connectionString) => _connectionString = connectionString;

    public async Task<SqlDataReader> ExecuteQueryAsync(string sql, IEnumerable<SqlParameter> parameters)
    {
        try
        {
            var connection = new SqlConnection(_connectionString);
            var command = new SqlCommand(sql, connection);
            command.Parameters.AddRange(parameters.ToArray());
            await connection.OpenAsync();
            return await command.ExecuteReaderAsync(CommandBehavior.CloseConnection);
        }
        catch (SqlException ex)
        {
            throw new SqlDataException("An error occurred executing SQL query.", ex);
        }
    }

    public async Task<object?> ExecuteScalarAsync(string sql, IEnumerable<SqlParameter> parameters)
    {
        try
        {
            await using var connection = new SqlConnection(_connectionString);
            var command = new SqlCommand(sql, connection);
            command.Parameters.AddRange(parameters.ToArray());
            await connection.OpenAsync();
            return await command.ExecuteScalarAsync();
        }
        catch (SqlException ex)
        {
            throw new SqlDataException("An error occurred executing SQL scalar query.", ex);
        }
    }

    public async Task ExecuteNonQueryAsync(string sql, IEnumerable<SqlParameter> parameters)
    {
        try
        {
            await using var connection = new SqlConnection(_connectionString);
            var command = new SqlCommand(sql, connection);
            command.Parameters.AddRange(parameters.ToArray());
            await connection.OpenAsync();
            await command.ExecuteNonQueryAsync();
        }
        catch (SqlException ex)
        {
            throw new SqlDataException("An error occurred executing SQL non-query.", ex);
        }
    }
}