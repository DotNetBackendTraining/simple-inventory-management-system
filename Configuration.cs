using SimpleInventoryManagementSystem.Controller;
using SimpleInventoryManagementSystem.DAO;
using SimpleInventoryManagementSystem.Interfaces;
using SimpleInventoryManagementSystem.Repository;

namespace SimpleInventoryManagementSystem;

public static class Configuration
{
    public static IUserConsoleInterface BuildUserController()
    {
        return new UserConsoleInterface(new ProductRepository(new MemoryProductDao()));
    }
}