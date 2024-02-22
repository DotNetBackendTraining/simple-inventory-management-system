// See https://aka.ms/new-console-template for more information

using SimpleInventoryManagementSystem.Domain;
using SimpleInventoryManagementSystem.Repository;

var inventory = new Inventory();

while (true)
{
    Console.WriteLine("""
                      Please select an option:
                      1. Add product to inventory
                      else. Exit
                      """);
    var input = Console.In.ReadLine();

    switch (input)
    {
        case "1":
            AddProduct();
            break;
        default:
            return 0;
    }
}

void AddProduct()
{
    Console.WriteLine("Name:");
    var name = Console.In.ReadLine() ?? string.Empty;
    var valid = !string.IsNullOrEmpty(name);

    Console.WriteLine("Price:");
    valid &= int.TryParse(Console.In.ReadLine(), out var price);

    Console.WriteLine("Quantity:");
    valid &= int.TryParse(Console.In.ReadLine(), out var quantity);

    if (!valid)
    {
        Console.WriteLine("Invalid information!");
        return;
    }

    inventory.Products.Add(new Product(name, price, quantity));
}