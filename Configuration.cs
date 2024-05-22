using MongoDB.Driver;
using SimpleInventoryManagementSystem.Controller;
using SimpleInventoryManagementSystem.DAO;
using SimpleInventoryManagementSystem.Domain;
using SimpleInventoryManagementSystem.Interfaces;
using SimpleInventoryManagementSystem.Repository;

namespace SimpleInventoryManagementSystem;

public static class Configuration
{
    public static IUserConsoleInterface BuildUserController()
    {
        return new UserConsoleInterface(new ProductRepository(BuildProductDao()));
    }

    private static IProductDao BuildProductDao()
    {
        var connectionString = Environment.GetEnvironmentVariable("MONGODB_CONNECTION_STRING");
        if (connectionString == null)
        {
            throw new IOException("MONGODB_CONNECTION_STRING environmental variable was not found");
        }

        var client = new MongoClient(connectionString);
        var database = client.GetDatabase("Inventory");
        var productsCollection = database.GetCollection<Product>("Products");

        return new BsonProductDao(productsCollection);
    }
}