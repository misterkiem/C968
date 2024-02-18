using InventoryModels;
using System.Windows;
using InventoryManager.Wpf.Vms;
using InventoryManager.Wpf.Messages;

namespace InventoryManager.Wpf.Views;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{ 
    Inventory inventory = SampleData.SampleInventory;

    public MainWindow()
    {
        Messenger.Register<OpenWindowMessage>(this, OnOpenWindowMessage);
        DataContext = new MainWindowVm(inventory);
        InitializeComponent();
    }

    private void OnOpenWindowMessage(object recipient, OpenWindowMessage message)
    {
        switch (message.ItemType)
        {
            case InventoryItemType.Part:
                OpenPartsWindow(message);
                break;
            case InventoryItemType.Product:
                OpenProductsWindow(message);
                break;
            default:
                break;
        }
    }

    void OpenPartsWindow(OpenWindowMessage message)
    {
        PartWindowVm vm = new(message, inventory);
        PartWindow window = new(vm);
        window.ShowDialog();
    }

    void OpenProductsWindow(OpenWindowMessage message)
    {
        WindowType type = message.WindowType;
        Product? product = message.SelectedItem as Product;
    }
}