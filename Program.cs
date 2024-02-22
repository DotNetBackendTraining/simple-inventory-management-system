// See https://aka.ms/new-console-template for more information

using SimpleInventoryManagementSystem.Domain;
using SimpleInventoryManagementSystem.Repository;

var inventory = new Inventory();

while (true)
{
    Console.WriteLine("""
                      Please select an option:
                      1. Add product to inventory
                      2. Display all products
                      else. Exit
                      """);
    var input = Console.In.ReadLine();

    switch (input)
    {
        case "1":
            AddProduct();
            break;
        case "2":
            DisplayProducts();
            break;
        default:
            return 0;
    }
}

void AddProduct()
{
    Product? product;
    do
    {
        product = EnterProduct();
    } while (product == null);

    inventory.Products.Add(product);
}

void DisplayProducts()
{
    var number = 1;
    foreach (var product in inventory.Products)
    {
        Console.WriteLine($"[{number++}] {product}");
    }
}

Product? EnterProduct()
{
    Console.WriteLine("Name:");
    var name = Console.In.ReadLine() ?? string.Empty;
    var valid = !string.IsNullOrEmpty(name);

    Console.WriteLine("Price:");
    valid &= int.TryParse(Console.In.ReadLine(), out var price);

    Console.WriteLine("Quantity:");
    valid &= int.TryParse(Console.In.ReadLine(), out var quantity);

    if (valid) return new Product(name, price, quantity);
    Console.WriteLine("Invalid information!");
    return null;
}