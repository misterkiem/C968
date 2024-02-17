using InventoryModels;

namespace InventoryManager.Wpf.Messages;
public class AddProductMessage
{
    public Product Product { get; set; }
    public AddProductMessage(Product product) => Product = product;
}
