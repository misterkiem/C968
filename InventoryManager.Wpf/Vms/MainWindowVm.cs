﻿using CommunityToolkit.Mvvm.ComponentModel;
using InventoryManager.Wpf.Services;
using InventoryModels;
using System.ComponentModel;
using System.Windows.Data;

namespace InventoryManager.Wpf.Vms;

public partial class MainWindowVm : ObservableObject
{
    IDialogService dialogService = new DialogService();
    public Inventory Inventory { get; set; }
    public MainWindowPartCardVm PartsCardVm { get; }
    public MainWindowProductCardVm ProductsCardVm { get; }

    [ObservableProperty]
    Part? _selectedPart;

    [ObservableProperty]
    Product? _selectedProduct;

    public MainWindowVm(Inventory inventory)
    {
        Inventory = inventory;
        PartsCardVm = new(dialogService, Inventory);
        ProductsCardVm = new(dialogService, new ListCollectionView(Inventory.Products));
    }
}
