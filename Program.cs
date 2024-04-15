// See https://aka.ms/new-console-template for more information

using SimpleInventoryManagementSystem.Common;
using SimpleInventoryManagementSystem.Controller;
using SimpleInventoryManagementSystem.DAO;
using SimpleInventoryManagementSystem.Mapper;
using SimpleInventoryManagementSystem.Repository;

var connectionString = Environment.GetEnvironmentVariable("SQL_CONNECTION_STRING");
if (connectionString == null)
{
    Console.WriteLine("SQL_CONNECTION_STRING environmental variable was not found");
    return -1;
}

var controller = new UserController(
    new ProductRepository(
        new SqlProductDao(
            new SqlDataSource(connectionString),
            new SqlProductMapper()
        ))
);

while (true)
{
    Console.WriteLine("""
                      Please select an option:
                      1. Add product to inventory
                      2. Display all products
                      3. Find and display a product
                      4. Find and edit a product
                      5. Find and delete a product
                      else. Exit
                      """);
    var input = Console.In.ReadLine();
    try
    {
        switch (input)
        {
            case "1":
                await controller.AddProductAsync();
                break;
            case "2":
                await controller.DisplayProductsAsync();
                break;
            case "3":
                await controller.FindAndDisplayProductAsync();
                break;
            case "4":
                await controller.FindAndEditProductAsync();
                break;
            case "5":
                await controller.FindAndDeleteProductAsync();
                break;
            default:
                return 0;
        }
    }
    catch (PrintableException ex)
    {
        Console.WriteLine(ex);
    }
}