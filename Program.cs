// See https://aka.ms/new-console-template for more information

using SimpleInventoryManagementSystem.Common;
using SimpleInventoryManagementSystem.Controller;
using SimpleInventoryManagementSystem.DAO;
using SimpleInventoryManagementSystem.Mapper;
using SimpleInventoryManagementSystem.Repository;

var controller = new UserController(
    new ProductRepository(
        new SqlProductDao(
            new SqlDataSource(Environment.GetEnvironmentVariable("SQL_CONNECTION_STRING") ?? string.Empty),
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
                controller.AddProduct();
                break;
            case "2":
                controller.DisplayProducts();
                break;
            case "3":
                controller.FindAndDisplayProduct();
                break;
            case "4":
                controller.FindAndEditProduct();
                break;
            case "5":
                controller.FindAndDeleteProduct();
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