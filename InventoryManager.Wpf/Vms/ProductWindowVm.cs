using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using InventoryManager.Wpf.Messages;
using InventoryManager.Models;
using System.Collections.ObjectModel;
using System.Windows.Data;
using System.Collections;

namespace InventoryManager.Wpf.Vms;

public partial class ProductWindowVm : ErrorNotifyVm
{
    public ProductWindowVm(OpenWindowMessage message, Inventory inventory)
    {
        _inventory = inventory;
        PartsView = new ListCollectionView(inventory.AllParts);
        SearchBarVm = new(PartsView, inventory.AllParts);

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

    [ObservableProperty]
    private InventoryItemCardVm _cardVm;

    private Inventory _inventory;

    [ObservableProperty]
    private ListCollectionView _partsView;

    [ObservableProperty]
    private Part? _partToAdd;

    [ObservableProperty]
    private Part? _partToDelete;

    [ObservableProperty]
    private InventorySearchBarVm _searchBarVm;
    public ObservableCollection<Part> AssociatedParts { get; }

    public string WindowTitle => WindowType switch
    {
        WindowType.AddWindow => "Add Product",
        WindowType.ModifyWindow => "Modify Product",
        _ => string.Empty
    };

    private WindowType WindowType { get; set; }
    [RelayCommand]
    private void AddPart()
    {
        if (PartToAdd is null) return;
        AssociatedParts.Add(PartToAdd);
    }

    [RelayCommand(CanExecute=nameof(HasNoErrors))]
    private void Save()
    {
        Product product = new(CardVm.GetItem(), AssociatedParts);
        switch (WindowType)
        {
            case WindowType.AddWindow:
                _inventory.AddProduct(product);
                break;

            case WindowType.ModifyWindow:
                _inventory.UpdateProduct(product.Id, product);
                break;

            default:
                break;
        }
        Messenger.Send(new CloseProductWindowMessage());
    }

    [RelayCommand]
    private void Cancel()
    { Messenger.Send(new CloseProductWindowMessage()); }

    [RelayCommand]
    private void DeletePart()
    {
        if (PartToDelete is null) return;
        AssociatedParts.Remove(PartToDelete);
    }

    protected override void OnErrorsChanged(object recipient, ErrorsChangedMessage message)
    {
        base.OnErrorsChanged(recipient, message);
        SaveCommand.NotifyCanExecuteChanged();
    }

}