using SimpleInventoryManagementSystem.Domain;
using SimpleInventoryManagementSystem.Interfaces;

namespace SimpleInventoryManagementSystem.Controller;

public class UserController : IUserController
{
    private readonly IProductRepository _repository;
    public UserController(IProductRepository repository) => _repository = repository;

    public void AddProduct()
    {
        var product = EnterAndValidateProduct();
        _repository.AddProduct(product);
    }

    public void FindAndDisplayProduct()
    {
        var product = FindProduct();
        Console.WriteLine(product == null ? "Product not found!" : product);
    }

    public void FindAndEditProduct()
    {
        var product = FindProduct();
        if (product == null)
        {
            Console.WriteLine("Product not found!");
            return;
        }

        Console.WriteLine("Please enter new product information.");
        var newProduct = EnterAndValidateProduct();
        _repository.DeleteProductByName(product.Name);
        _repository.AddProduct(newProduct);
    }

    public void FindAndDeleteProduct()
    {
        var product = FindProduct();
        if (product == null)
        {
            Console.WriteLine("Product not found!");
            return;
        }

        _repository.DeleteProductByName(product.Name);
    }

    public void DisplayProducts()
    {
        var number = 1;
        foreach (var product in _repository.GetAllProducts())
        {
            Console.WriteLine($"[{number++}] {product}");
        }
    }

    private Product? EnterProduct()
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

    private Product EnterAndValidateProduct()
    {
        var product = EnterProduct();
        while (product == null)
        {
            Console.WriteLine("Invalid information!");
            product = EnterProduct();
        }

        return product;
    }

    private Product? FindProduct()
    {
        Console.WriteLine("Name:");
        var name = Console.In.ReadLine() ?? string.Empty;
        return string.IsNullOrEmpty(name) ? null : _repository.GetProductByName(name);
    }
}