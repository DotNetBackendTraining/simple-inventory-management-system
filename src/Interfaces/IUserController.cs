namespace SimpleInventoryManagementSystem.Interfaces;

public interface IUserController
{
    Task AddProductAsync();
    Task FindAndDisplayProductAsync();
    Task FindAndEditProductAsync();
    Task FindAndDeleteProductAsync();
    Task DisplayProductsAsync();
}