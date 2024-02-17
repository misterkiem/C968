using InventoryManager.Wpf.Vms;
using InventoryModels;
using System.Windows;

namespace InventoryManager.Wpf.Views
{
    /// <summary>
    /// Interaction logic for PartCard.xaml
    /// </summary>
    public partial class PartWindow : Window
    {
        public PartWindow(PartWindowVm vm)
        {
            DataContext = vm;
            InitializeComponent();
        }
    }
}
