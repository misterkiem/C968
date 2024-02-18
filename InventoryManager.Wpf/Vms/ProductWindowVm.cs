using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using InventoryManager.Wpf.Messages;
using InventoryModels;
using System.Collections.ObjectModel;
using System.Windows.Data;

namespace InventoryManager.Wpf.Vms;

public partial class ProductWindowVm : ObservableObject
{
    WindowType WindowType { get; set; }

    public string WindowTitle => WindowType switch
    {
        WindowType.AddWindow => "Add Product",
        WindowType.ModifyWindow => "Modify Product",
        _ => string.Empty
    };

    Inventory _inventory;

    [ObservableProperty]
    InventoryItemCardVm _cardVm;

    [ObservableProperty]
    InventorySearchBarVm _searchBarVm;
    [ObservableProperty]
    Part? _partToAdd;
    [ObservableProperty]
    ListCollectionView _partsView;

    [ObservableProperty]
    Part? _partToDelete;

    Product _product => (Product)CardVm.Item;

    public ObservableCollection<Part> AssociatedParts { get; }

    public ProductWindowVm(OpenWindowMessage message, Inventory inventory)
    {
        _inventory = inventory;
        PartsView = new ListCollectionView(inventory.AllParts);
        SearchBarVm = new(PartsView);


        var type = message.WindowType;
        WindowType = type;
        if (type == WindowType.AddWindow)
        {
            CardVm = new(inventory.GetNextProductId());
            AssociatedParts = new();
            return;
        }

        var product = (Product)message.SelectedItem!;
        CardVm = new(product);
        AssociatedParts = product.AssociatedParts;
    }

    [RelayCommand]
    void Save()
    {
        switch (WindowType)
        {
            case WindowType.AddWindow:
                _inventory.AddProduct(_product);
                break;
            case WindowType.ModifyWindow:
                _inventory.UpdateProduct(_product.Id, _product);
                break;
            default:
                break;
        }
        Messenger.Send(new CloseProductWindowMessage());

    }

    [RelayCommand]
    void Cancel() { Messenger.Send(new CloseProductWindowMessage()); }

    [RelayCommand]
    void DeletePart()
    {
        if (PartToDelete is null) return;
        _product.RemoveAssociatedPart(PartToDelete);
    }

    [RelayCommand]
    void AddPart()
    {
        if (PartToAdd is null) return;
        _product.AddAssociatedPart(PartToAdd);
    }
}
