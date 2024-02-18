using CommunityToolkit.Mvvm.ComponentModel;
using InventoryModels;

namespace InventoryManager.Wpf.Vms;

public partial class InventoryItemCardVm : ObservableObject
{
    [ObservableProperty]
    InventoryItem _item;

    public InventoryItemCardVm(InventoryItem? item)
    {
        if (item is null) Item = new();
        else Item = new(item);
    }

    public InventoryItemCardVm(int id)
    {
        Item = new() { Id = id };
    }

}
