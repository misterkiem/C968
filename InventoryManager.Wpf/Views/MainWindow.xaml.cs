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
        Messenger.Register<CloseMainWindowMessage>(this, OnCloseWindowMessage);
        DataContext = new MainWindowVm(inventory);
        InitializeComponent();
    }

    private void OnCloseWindowMessage(object recipient, CloseMainWindowMessage message) { Close(); }

    private void OnOpenWindowMessage(object recipient, OpenWindowMessage message)
    {
        var sender = message.Sender;
        if (sender is MainWindowPartCardVm) OpenPartsWindow(message);
        if (sender is MainWindowProductCardVm) OpenProductsWindow(message);
    }

    void OpenPartsWindow(OpenWindowMessage message)
    {
        PartWindowVm vm = new(message, inventory);
        PartWindow window = new(vm);
        window.ShowDialog();
    }

    void OpenProductsWindow(OpenWindowMessage message)
    {
        ProductWindowVm vm = new(message, inventory);
        ProductWindow window = new(vm);
        window.ShowDialog();
    }
}