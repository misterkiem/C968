using System.Windows;

namespace InventoryManager.Wpf.Views;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{ 
    public MainWindow()
    {
        DataContext = new Vms.MainWindowVm();
        InitializeComponent();
    }
}