using SimpleInventoryManagementSystem.Domain;
using SimpleInventoryManagementSystem.Interfaces;

namespace SimpleInventoryManagementSystem.Controller;

public class UserController : IUserController
{
    private readonly IProductRepository _repository;
    public UserController(IProductRepository repository) => _repository = repository;

    public async Task AddProductAsync()
    {
        var product = await EnterAndValidateProductAsync();
        await _repository.AddProductAsync(product);
    }

    public async Task FindAndDisplayProductAsync()
    {
        var product = await FindProductAsync();
        Console.WriteLine(product == null ? "Product not found!" : product);
    }

    public async Task FindAndEditProductAsync()
    {
        var product = await FindProductAsync();
        if (product == null)
        {
            Console.WriteLine("Product not found!");
            return;
        }

        Console.WriteLine("Please enter new product information.");
        var newProduct = await EnterAndValidateProductAsync();
        await _repository.DeleteProductByNameAsync(product.Name);
        await _repository.AddProductAsync(newProduct);
    }

    public async Task FindAndDeleteProductAsync()
    {
        var product = await FindProductAsync();
        if (product == null)
        {
            Console.WriteLine("Product not found!");
            return;
        }

        await _repository.DeleteProductByNameAsync(product.Name);
    }

    public async Task DisplayProductsAsync()
    {
        var number = 1;
        await foreach (var product in _repository.GetAllProductsAsync())
        {
            Console.WriteLine($"[{number++}] {product}");
        }
    }

    private async Task<Product?> EnterProductAsync()
    {
        Console.WriteLine("Name:");
        var name = await Console.In.ReadLineAsync() ?? string.Empty;
        var valid = !string.IsNullOrEmpty(name);

        Console.WriteLine("Price:");
        valid &= int.TryParse(await Console.In.ReadLineAsync(), out var price);

        Console.WriteLine("Quantity:");
        valid &= int.TryParse(await Console.In.ReadLineAsync(), out var quantity);

        return valid
            ? new Product
            {
                Name = name,
                Price = price,
                Quantity = quantity
            }
            : null;
    }

    private async Task<Product> EnterAndValidateProductAsync()
    {
        var product = await EnterProductAsync();
        while (product == null)
        {
            Console.WriteLine("Invalid information!");
            product = await EnterProductAsync();
        }

        return product;
    }

    private async Task<Product?> FindProductAsync()
    {
        Console.WriteLine("Name:");
        var name = await Console.In.ReadLineAsync() ?? string.Empty;
        return string.IsNullOrEmpty(name) ? null : await _repository.GetProductByNameAsync(name);
    }
}