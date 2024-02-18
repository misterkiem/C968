using CommunityToolkit.Mvvm.ComponentModel;
using InventoryManager.Wpf.Messages;
using InventoryModels;
using System.ComponentModel;

namespace InventoryManager.Wpf.Vms;

public partial class InventoryItemCardVm : ObservableObject, IDataErrorInfo
{
    [ObservableProperty]
    private int _id;

    [ObservableProperty]
    private string _name = string.Empty;

    [ObservableProperty]
    private decimal price;

    [ObservableProperty]
    private int inStock;

    [NotifyPropertyChangedFor(nameof(InStock))]
    [ObservableProperty]
    private int _min;

    [NotifyPropertyChangedFor(nameof(InStock))]
    [ObservableProperty]
    private int _max;
    public InventoryItemCardVm(InventoryItem? item) => InitItem(item);

    public InventoryItemCardVm(int id) => Id = id;

    public InventoryItem GetItem()
    {
        return new InventoryItem()
        {
            Id = Id,
            Name = Name,
            Price = Price,
            InStock = InStock,
            Min = Min,
            Max = Max
        };
    }

    public string Error => string.Empty;

    public string this[string prop]
    {
        get
        {
            if (prop == nameof(InStock)) { return CheckStock(); }
            return null;
        }
    }
    private string CheckStock()
    {
        if (Min <= InStock && InStock <= Max) return null;
        return $"Inventory out of range ({Min}-{Max})";
    }

    private void InitItem(InventoryItem? item)
    {
        if (item is null) return;
        Id = item.Id;
        Name = item.Name;
        Price = item.Price;
        InStock = item.InStock;
        Min = item.Min;
        Max = item.Max;
    }
}