using CommunityToolkit.Mvvm.ComponentModel;
using InventoryManager.Wpf.Messages;
using InventoryManager.Models;
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

    [NotifyPropertyChangedFor(nameof(Min))]
    [NotifyPropertyChangedFor(nameof(Max))]
    [ObservableProperty]
    private int inStock;

    [NotifyPropertyChangedFor(nameof(InStock))]
    [NotifyPropertyChangedFor(nameof(Max))]
    [ObservableProperty]
    private int _min;

    [NotifyPropertyChangedFor(nameof(InStock))]
    [NotifyPropertyChangedFor(nameof(Min))]
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
            if (prop == nameof(Min)) { return CheckMin(); }
            if (prop == nameof(Max)) { return CheckMin(); }
            return string.Empty;
        }
    }
    private string CheckStock()
    {
        if (Min <= InStock && InStock <= Max) return string.Empty;
        return $"Inventory out of range ({Min}-{Max})";
    }

    private string CheckMin()
    {   if (Min <= InStock && Min <= Max) return string.Empty;
        return "Min too high";

    }

    private string CheckMax()
    {
        if (Max >= InStock && Max >= Min) return string.Empty;
        return "Max too low";
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