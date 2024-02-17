using InventoryModels;
using System.Windows;

namespace InventoryManager.Wpf.Views;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{ 
    Inventory inventory = SampleData.SampleInventory;

    public MainWindow()
    {
        DataContext = new Vms.MainWindowVm(inventory);
        InitializeComponent();
    }
}