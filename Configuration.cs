using System.Data.SqlClient;
using SimpleInventoryManagementSystem.Controller;
using SimpleInventoryManagementSystem.DAO;
using SimpleInventoryManagementSystem.Interfaces;
using SimpleInventoryManagementSystem.Repository;

namespace SimpleInventoryManagementSystem;

public static class Configuration
{
    public static IUserConsoleInterface BuildUserController()
    {
        return new UserConsoleInterface(
            new ProductRepository(
                new SqlProductDao(
                    GetSqlConnection()
                )
            )
        );
    }

    private static SqlConnection GetSqlConnection()
    {
        var connectionString = Environment.GetEnvironmentVariable("SQL_CONNECTION_STRING");
        if (connectionString == null)
        {
            throw new IOException("SQL_CONNECTION_STRING environmental variable was not found");
        }

        return new SqlConnection(connectionString);
    }
}