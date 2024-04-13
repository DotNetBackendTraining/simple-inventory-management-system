// See https://aka.ms/new-console-template for more information

using SimpleInventoryManagementSystem.Domain;
using SimpleInventoryManagementSystem.Interfaces;
using SimpleInventoryManagementSystem.Repository;

IProductRepository inventory = new ProductRepository();

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

    switch (input)
    {
        case "1":
            AddProduct();
            break;
        case "2":
            DisplayProducts();
            break;
        case "3":
            FindAndDisplayProduct();
            break;
        case "4":
            FindAndEditProduct();
            break;
        case "5":
            FindAndDeleteProduct();
            break;
        default:
            return 0;
    }
}

void AddProduct()
{
    var product = EnterAndValidateProduct();
    inventory.AddProduct(product);
}

void FindAndDisplayProduct()
{
    var product = FindProduct();
    Console.WriteLine(product == null ? "Product not found!" : product);
}

void FindAndEditProduct()
{
    var product = FindProduct();
    if (product == null)
    {
        Console.WriteLine("Product not found!");
        return;
    }

    Console.WriteLine("Please enter new product information.");
    var newProduct = EnterAndValidateProduct();
    inventory.DeleteProductByName(product.Name);
    inventory.AddProduct(newProduct);
}

void FindAndDeleteProduct()
{
    var product = FindProduct();
    if (product == null)
    {
        Console.WriteLine("Product not found!");
        return;
    }

    inventory.DeleteProductByName(product.Name);
}

void DisplayProducts()
{
    var number = 1;
    foreach (var product in inventory.GetAllProducts())
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

    return valid ? new Product(name, price, quantity) : null;
}

Product EnterAndValidateProduct()
{
    var product = EnterProduct();
    while (product == null)
    {
        Console.WriteLine("Invalid information!");
        product = EnterProduct();
    }

    return product;
}

Product? FindProduct()
{
    Console.WriteLine("Name:");
    var name = Console.In.ReadLine() ?? string.Empty;
    return string.IsNullOrEmpty(name) ? null : inventory.GetProductByName(name);
}