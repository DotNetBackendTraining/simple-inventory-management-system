using SimpleInventoryManagementSystem.Domain;

namespace SimpleInventoryManagementSystem.Repository;

public class Inventory
{
    public List<Product> Products { get; init; } = [];

    /// <summary>
    /// Gets or sets a product in the inventory by product name.
    /// </summary>
    /// <param name="productName">The name of the product to get or set.</param>
    /// <returns>
    /// The product with the specified name if found; otherwise, null.
    /// When setting a product, if a product with the specified name exists, it will be replaced.
    /// If the product does not exist, it will be added to the inventory.
    /// If the specified value is null and a product with the name exists, the product will be removed from the inventory.
    /// </returns>
    public Product? this[string productName]
    {
        get { return Products.FirstOrDefault(p => p.Name == productName); }
        set
        {
            var index = Products.FindIndex(p => p.Name == productName);
            if (index != -1)
            {
                if (value == null)
                    Products.RemoveAt(index);
                else
                    Products[index] = value;
            }
            else if (value != null)
            {
                Products.Add(value);
            }
        }
    }
}