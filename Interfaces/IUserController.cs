namespace SimpleInventoryManagementSystem.Interfaces;

public interface IUserController
{
    void AddProduct();
    void FindAndDisplayProduct();
    void FindAndEditProduct();
    void FindAndDeleteProduct();
    void DisplayProducts();
}