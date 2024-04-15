using SimpleInventoryManagementSystem.Controller;
using SimpleInventoryManagementSystem.DAO;
using SimpleInventoryManagementSystem.Interfaces;
using SimpleInventoryManagementSystem.Repository;

namespace SimpleInventoryManagementSystem;

public static class Configuration
{
    public static IUserController BuildUserController()
    {
        return new UserController(new ProductRepository(new MemoryProductDao()));
    }
}