﻿using CommunityToolkit.Mvvm.ComponentModel;
using InventoryModels;
using System.ComponentModel;
using System.Windows.Data;

namespace InventoryManager.Wpf.Vms;

public partial class MainWindowVm : ObservableObject
{
    public Inventory Inventory { get; set; }
    public MainWindowCardVm PartsCardVm { get; } 
    public MainWindowCardVm ProductsCardVm { get; }

    [ObservableProperty]
    Part? _selectedPart;

    [ObservableProperty]
    Product? _selectedProduct;

    public MainWindowVm(Inventory inventory)
    {
        Inventory = inventory;
        PartsCardVm = new(new(Inventory.AllParts)) { CardTitle = "Parts", IdHeader = "Part ID" };
        ProductsCardVm = new(new(Inventory.Products)) { CardTitle = "Products", IdHeader = "Product ID" };
    }
}
