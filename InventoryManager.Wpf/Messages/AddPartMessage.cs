using InventoryManager.Models;

namespace InventoryManager.Wpf.Messages;

public class AddPartMessage
{
    public Part Part { get; set; }
    public AddPartMessage(Part part) => Part = part;
}
