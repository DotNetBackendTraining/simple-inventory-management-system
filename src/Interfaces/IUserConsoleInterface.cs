namespace SimpleInventoryManagementSystem.Interfaces;

public interface IUserConsoleInterface
{
    Task AddProductAsync();
    Task FindAndDisplayProductAsync();
    Task FindAndEditProductAsync();
    Task FindAndDeleteProductAsync();
    Task DisplayProductsAsync();
}