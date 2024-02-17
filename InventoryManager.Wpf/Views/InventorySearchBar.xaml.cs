using System.Windows;
using System.Windows.Controls;
using InventoryManager.Wpf.Vms;

namespace InventoryManager.Wpf.Views
{
    /// <summary>
    /// Interaction logic for SearchBar.xaml
    /// </summary>
    public partial class InventorySearchBar : UserControl
    {
        public InventorySearchBarVm Vm
        {
            get { return (InventorySearchBarVm)GetValue(VmProperty); }
            set { SetValue(VmProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Vm.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty VmProperty =
            DependencyProperty.Register("Vm", typeof(InventorySearchBarVm), typeof(InventorySearchBar), new PropertyMetadata(null));

        public InventorySearchBar()
        {
            InitializeComponent();
        }
    }
}
